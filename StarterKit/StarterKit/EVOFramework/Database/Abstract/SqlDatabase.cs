using System;
using System.Data.SqlClient;
using System.Data;
using EVOFramework.Data;

namespace EVOFramework.Database
{
    /// <summary>
    /// Sealed class.
    /// </summary>
    public sealed class SqlDatabase : Database
    {


        public SqlDatabase(DatabaseCredential credential)
            : base(credential)
        {
            this.DBTransaction = null;
            this.DBConnection = new SqlConnection();
            this.DBConnection.ConnectionString = credential.ConnectionString;
            this.KeepConnection = false;
            //ใช้การแปลง DataType ของ SQLServer
            this.DataTypeConverter = new SqlDataTypeConverter();

            this.m_strOleDbConnectionString = credential.OleDbConnectionString;

        }

        #region Implement abstract methods
        internal override void CopyParameters(IDbCommand command, DataRequest request)
        {
            SqlParameter Param = null;
            Parameter DbParam = null;

            command.Parameters.Clear();
            for (int i = 0; i < request.Parameters.Count; i++)
            {
                DbParam = request.Parameters[i];
                Param = new SqlParameter();
                Param.ParameterName = DbParam.Name;
                Param.Direction = DbParam.Direction;
                Param.Size = DbParam.Size;

                if (DbParam.Value == null)
                    Param.Value = DBNull.Value;
                else
                    Param.Value = DbParam.Value;

                if (DbParam.DataType != DataType.Default)
                    Param.SqlDbType = (SqlDbType)this.DataTypeConverter.ConvertToProvider(DbParam.DataType);

                command.Parameters.Add(Param);
            }
        }

        /// <summary>
        /// สร้าง instance ของ OracleCommand
        /// ถ้ามีการเปิด Transaction ก็จะรวม Transaction ไว้ด้วย
        /// รวมทั้งคัดลอก Parameter ทั้งหมดใน DataRequest มาเก็บไว้ใน OracleCommand ด้วย
        /// </summary>
        /// <param name="request">DataRequest</param>
        /// <returns>OracleCommand</returns>
        internal override IDbCommand CreateCommand(DataRequest request)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = (SqlConnection)this.DBConnection;
            command.CommandText = this.ParseCommandText(request.CommandText, "@");
            command.CommandType = request.CommandType;

            if (request.Timeout > 0)
            {
                command.CommandTimeout = request.Timeout;
            }
            else
            {
                command.CommandTimeout = Database.m_iDefaultCommandTimeout;
            }

            CopyParameters(command, request);

            if (DBTransactionState == TransactionState.PROCESSING)
                command.Transaction = (SqlTransaction)DBTransaction;

            return command;
        }

        /// <summary>
        /// Create new instance of connection
        /// </summary>
        /// <returns>IDbConnection</returns>
        public override IDbConnection CreateConnection()
        {
            return new SqlConnection(m_databaseCredential.ConnectionString);
        }

        /// <summary>
        /// Create new instance of Database
        /// </summary>
        /// <returns></returns>
        public override Database CreateNewDatabase()
        {
            return new SqlDatabase(this.m_databaseCredential);
        }
        #endregion

        #region Overriden Methods

        /// <summary>
        /// Execute data request for list of data transfer object.
        /// It will execute command and parse field into strongly type of DTO.
        /// </summary>
        /// <typeparam name="T">Type of DTO</typeparam>
        /// <param name="request">DataRequest command and parameter.</param>
        /// <returns>List of DTO. If not found data it will return empty list.</returns>
        /// <exception cref="DataAccessException"><c>DataAccessException</c>.</exception>
        public override System.Collections.Generic.List<T> ExecuteForList<T>(DataRequest request)
        {
            // It will loss performance because:
            //  - first execute to get DataTable.
            //  - second convert dataTable to List.
            try
            {
                DataTable dt = ExecuteQuery(request);
                return DTOUtility.ConvertDataTableToList<T>(dt);
            }
            catch (Exception err)
            {
                DataAccessException ex = new DataAccessException(err.Message, err);
                ex.DataRequest = request;
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">You should set KeepConnection is True</exception>
        /// <exception cref="DataAccessException"><c>DataAccessException</c>.</exception>
        public override IDataReader ExecuteDataReader(DataRequest request)
        {
            //ใช้สำหรับคำสั่ง SELECT เท่านั้น

            //DataReader ทำงานเป็น Non-Connectionless จึงต้องเปิด Connection ไว้เสมอ
            // จนกว่าจะปิด DataReader  จึงจะสามารถปิด Connection ได้
            //ดังนั้นจึงจะต้องกำหนด KeepConnection = True
            if (!KeepConnection)
            {
                throw new ApplicationException("You should set KeepConnection is True");
            }

            //Check if not has transaction
            //if database is begin transaction, Connection must be already Open state.
            if (DBTransactionState == TransactionState.IDLE)
            {
                //Reopen connection
                if (DBConnectionState == ConnectionState.Open)
                    this.Close();
                this.Open();
            }
            try
            {
                SqlCommand cmd = (SqlCommand)CreateCommand(request);
                return cmd.ExecuteReader();
            }
            catch (Exception err)
            {
                DataAccessException ex = new DataAccessException(err.Message, err);
                ex.DataRequest = request;
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">You should set KeepConnection is True</exception>
        /// <exception cref="DataAccessException"><c>DataAccessException</c>.</exception>
        public override int ExecuteNonQuery(DataRequest request)
        {
            //Include Function : UPDATE, INSERT, DELETE
            //Mayby transaction
            if (DBTransactionState == TransactionState.PROCESSING)
            {
                //Transaction ทำงานเป็น Non-Connectionless จึงต้องเปิด Connection ไว้เสมอ
                // จนกว่าจะ Commit / Rollback  จึงจะสามารถปิด Connection ได้
                // ดังนั้นจึงจะต้องกำหนด KeepConnection = True
                if (!KeepConnection)
                {
                    throw new ApplicationException("You should set KeepConnection is True");
                }

                //Connection จะต้อง Open ไว้แล้ว  เนื่องจากมีการใช้ Transaction
            }
            else
            {
                //ถ้าไม่มีการใช้ Transaction จะต้อง ReOpen connection
                if (DBConnectionState == ConnectionState.Open)
                    this.Close();
                this.Open();
            }

            int retCmd = 0;
            //สร้างตัวแปรสำหรับ Execute Command
            SqlCommand cmd = (SqlCommand)CreateCommand(request);

            try
            {
                //Execute Command and return number of affected rows.
                retCmd = cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                //Save db exception
                //byte[] bytes = request.SerializeObject();
                //DBExceptionDAO.AddNew(bytes, ex.StackTrace, ex.Message);

                DataAccessException ex = new DataAccessException(err.Message, err);
                ex.DataRequest = request;
                throw ex;
            }
            finally
            {
                //Close connection when not use transaction and KeepConnection is false.
                if (DBTransactionState == TransactionState.IDLE)
                {
                    if (!KeepConnection)
                        this.Close();
                }
            }
            return retCmd;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">You should set KeepConnection is True</exception>
        /// <exception cref="DataAccessException"><c>DataAccessException</c>.</exception>
        public override DataSet ExecuteDataSet(DataRequest request)
        {
            DataSet resultDS = null;
            SqlDataAdapter adapt = null;

            //คล้ายคำสั่ง ExecuteDataReader  แต่จะเก็บลง DataSet
            //Mayby transaction
            if (DBTransactionState == TransactionState.PROCESSING)
            {
                //Transaction ทำงานเป็น Non-Connectionless จึงต้องเปิด Connection ไว้เสมอ
                // จนกว่าจะ Commit / Rollback  จึงจะสามารถปิด Connection ได้
                // ดังนั้นจึงจะต้องกำหนด KeepConnection = True
                if (!KeepConnection)
                {
                    throw new ApplicationException("You should set KeepConnection is True");
                }

                //Connection จะต้อง Open ไว้แล้ว  เนื่องจากมีการใช้ Transaction
            }
            else
            {
                //ถ้าไม่มีการใช้ Transaction จะต้อง ReOpen connection
                if (DBConnectionState == ConnectionState.Open)
                    this.Close();
                this.Open();
            }

            //Processing
            try
            {
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = (SqlCommand)CreateCommand(request);
                resultDS = new DataSet();
                if (request.ResultTableName == String.Empty)
                    adapt.Fill(resultDS);
                else
                    adapt.Fill(resultDS, request.ResultTableName);
            }
            catch (Exception err)
            {
                DataAccessException ex = new DataAccessException(err.Message, err);
                ex.DataRequest = request;
                throw ex;
            }

            //Close connection when not use transaction and KeepConnection is false.
            if (DBTransactionState == TransactionState.IDLE)
            {
                if (!KeepConnection)
                    this.Close();
            }

            return resultDS;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">You should set KeepConnection to True</exception>
        /// <exception cref="DataAccessException"><c>DataAccessException</c>.</exception>
        public override DataTable ExecuteQuery(DataRequest request)
        {
            DataTable resultDT = null;
            SqlDataAdapter adapt = null;

            //คล้ายคำสั่ง ExecuteDataReader  แต่จะเก็บลง DataSet
            //Mayby transaction
            if (DBTransactionState == TransactionState.PROCESSING)
            {
                //Transaction ทำงานเป็น Non-Connectionless จึงต้องเปิด Connection ไว้เสมอ
                // จนกว่าจะ Commit / Rollback  จึงจะสามารถปิด Connection ได้
                // ดังนั้นจึงจะต้องกำหนด KeepConnection = True
                if (!KeepConnection)
                {
                    throw new ApplicationException("You should set KeepConnection to True");
                }

                //Connection จะต้อง Open ไว้แล้ว  เนื่องจากมีการใช้ Transaction
            }
            else
            {
                if (KeepConnection)
                {
                    if (DBConnectionState == ConnectionState.Closed)
                        this.Open();
                }
                else
                {
                    //ถ้าไม่มีการใช้ Transaction จะต้อง ReOpen connection
                    if (DBConnectionState == ConnectionState.Open)
                        this.Close();
                    this.Open();
                }
            }

            try
            {
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = (SqlCommand)CreateCommand(request);
                resultDT = new DataTable(request.ResultTableName);
                adapt.Fill(resultDT);
            }
            catch (Exception err)
            {
                DataAccessException ex = new DataAccessException(err.Message, err);
                ex.DataRequest = request;
                throw ex;
            }

            //Close connection when not use transaction and KeepConnection is false.
            if (DBTransactionState == TransactionState.IDLE)
            {
                if (!KeepConnection)
                    this.Close();
            }

            return resultDT;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">You should set KeepConnection is True</exception>
        /// <exception cref="DataAccessException"><c>DataAccessException</c>.</exception>
        public override object ExecuteScalar(DataRequest request)
        {
            if (DBTransactionState == TransactionState.PROCESSING)
            {
                //Transaction ทำงานเป็น Non-Connectionless จึงต้องเปิด Connection ไว้เสมอ
                // จนกว่าจะ Commit / Rollback  จึงจะสามารถปิด Connection ได้
                // ดังนั้นจึงจะต้องกำหนด KeepConnection = True
                if (!KeepConnection)
                {
                    throw new ApplicationException("You should set KeepConnection is True");
                }

                //Connection จะต้อง Open ไว้แล้ว  เนื่องจากมีการใช้ Transaction
            }
            else
            {
                //ถ้าไม่มีการใช้ Transaction จะต้อง ReOpen connection
                if (DBConnectionState == ConnectionState.Closed)
                    this.Open();
                //if (DBConnectionState == ConnectionState.Open)
                //    this.Close();
                //this.Open();
            }

            object ret = null;
            try
            {
                SqlCommand cmd = (SqlCommand)CreateCommand(request);
                ret = cmd.ExecuteScalar();
            }
            catch (Exception err)
            {
                DataAccessException ex = new DataAccessException(err.Message, err);
                ex.DataRequest = request;
                throw ex;
            }

            //Close connection when not use transaction and KeepConnection is false.
            if (DBTransactionState == TransactionState.IDLE)
            {
                if (!KeepConnection)
                    this.Close();
            }

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override ParameterCollection ExecutePackage(DataRequest request)
        {
            int iRowAffected = 0;
            return ExecutePackage(request, out iRowAffected);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override ParameterCollection ExecutePackage(string name, Parameter[] parameters)
        {
            int iRowAffected = 0;
            return ExecutePackage(name, parameters, out iRowAffected);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override ParameterCollection ExecutePackage(string name, ParameterCollection parameters)
        {
            int iRowAffected = 0;
            return ExecutePackage(name, parameters, out iRowAffected);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="rowAffect"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">You should set KeepConnection is True</exception>
        /// <exception cref="DataAccessException"><c>DataAccessException</c>.</exception>
        public override ParameterCollection ExecutePackage(DataRequest request, out int rowAffect)
        {
            //เก็บ Parameter ที่มี Direction : IN/OUT , OUT, RETURN
            ParameterCollection ret = new ParameterCollection();

            //เช็คการใช้งาน Transaction
            if (DBTransactionState == TransactionState.PROCESSING)
            {
                //Transaction ทำงานเป็น Non-Connectionless จึงต้องเปิด Connection ไว้เสมอ
                // จนกว่าจะ Commit / Rollback  จึงจะสามารถปิด Connection ได้
                // ดังนั้นจึงจะต้องกำหนด KeepConnection = True
                if (!KeepConnection)
                {
                    throw new ApplicationException("You should set KeepConnection is True");
                }

                //Connection จะต้อง Open ไว้แล้ว  เนื่องจากมีการใช้ Transaction
            }
            else
            {
                //ถ้าไม่มีการใช้ Transaction จะต้อง ReOpen connection
                if (DBConnectionState == ConnectionState.Open)
                    this.Close();
                this.Open();
            }

            request.CommandType = CommandType.StoredProcedure;
            SqlCommand cmd = (SqlCommand)CreateCommand(request);

            try
            {
                rowAffect = cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                //Save db exception
                //byte[] bytes = request.SerializeObject();
                //DBExceptionDAO.AddNew(bytes, ex.StackTrace, ex.Message);

                DataAccessException ex = new DataAccessException(err.Message, err);
                ex.DataRequest = request;
                throw ex;
            }
            finally
            {
                //Close connection when not use transaction and KeepConnection is false.
                if (DBTransactionState == TransactionState.IDLE)
                {
                    if (!KeepConnection)
                        this.Close();
                }
            }

            for (int i = 0; i < request.Parameters.Count; i++)
            {
                switch (request.Parameters[i].Direction)
                {
                    case ParameterDirection.InputOutput:
                    case ParameterDirection.Output:
                    case ParameterDirection.ReturnValue:
                        Parameter p = (Parameter)request.Parameters[i].Clone();
                        p.Value = cmd.Parameters[p.Name].Value;
                        ret.Add(p);
                        break;
                }
            }


            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameters"></param>
        /// <param name="rowAffect"></param>
        /// <returns></returns>
        public override ParameterCollection ExecutePackage(string name, Parameter[] parameters, out int rowAffect)
        {
            DataRequest request = new DataRequest();
            request.CommandText = name;
            request.CommandType = CommandType.StoredProcedure;

            for (int i = 0; i < parameters.Length; i++)
            {
                request.Parameters.Add(parameters[i]);
            }

            return this.ExecutePackage(request, out rowAffect);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameters"></param>
        /// <param name="rowAffect"></param>
        /// <returns></returns>
        public override ParameterCollection ExecutePackage(string name, ParameterCollection parameters, out int rowAffect)
        {
            DataRequest request = new DataRequest();
            request.CommandText = name;
            request.CommandType = CommandType.StoredProcedure;
            request.Parameters = parameters;

            return this.ExecutePackage(request, out rowAffect);
        }
        #endregion
    }
}
