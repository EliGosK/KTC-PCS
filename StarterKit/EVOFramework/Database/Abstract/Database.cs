using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using EVOFramework.Data;

namespace EVOFramework.Database
{
    public abstract class Database
    {
        #region Fields
        internal IDbTransaction m_IDbTransaction = null;
        internal IDbConnection m_IDbConnection = null;
        internal bool m_bKeepConnection = false;
        internal TransactionState m_transactionState = TransactionState.IDLE;
        internal DatabaseCredential m_databaseCredential = null;
        internal IDataTypeConverter m_dataTypeConverter = new OracleDataTypeConverter();

        internal string m_strOleDbConnectionString;

        public static int m_iDefaultCommandTimeout;



        #endregion

        #region Contructor
        internal Database(DatabaseCredential credential)
        {
            this.m_databaseCredential = credential;
        }
        #endregion

        #region Properties
        internal IDbConnection DBConnection
        {
            get { return this.m_IDbConnection; }
            set { this.m_IDbConnection = value; }
        }
        internal IDbTransaction DBTransaction
        {
            get { return this.m_IDbTransaction; }
            set { this.m_IDbTransaction = value; }
        }

        public virtual DatabaseCredential Credential
        {
            get { return this.m_databaseCredential; }
            set
            {
                this.m_databaseCredential = value;
                this.m_IDbConnection.ConnectionString = value.ConnectionString;
            }
        }

        /// <summary>
        /// Get connection state
        /// </summary>
        public virtual ConnectionState DBConnectionState
        {
            get { return this.m_IDbConnection.State; }
        }

        /// <summary>
        /// Get transaction state
        /// </summary>
        public virtual TransactionState DBTransactionState
        {
            get { return this.m_transactionState; }
            private set { this.m_transactionState = value; }
        }

        /// <summary>
        /// Get or set KeepConnection
        /// </summary>
        public virtual bool KeepConnection
        {
            get { return this.m_bKeepConnection; }
            set { this.m_bKeepConnection = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual IDataTypeConverter DataTypeConverter
        {
            get { return this.m_dataTypeConverter; }
            set { this.m_dataTypeConverter = value; }
        }


        public virtual string ConnectionString
        {
            get
            {
                if (m_IDbConnection != null)
                {
                    return m_IDbConnection.ConnectionString;
                }
                else
                {
                    return "";
                }
            }
        }

        public virtual string OleDbConnectionString
        {
            get
            {
                return this.m_strOleDbConnectionString;
            }
        }



        #endregion

        #region Transaction Process

        /// <summary>
        /// เริ่ม Transaction
        /// </summary>
        public virtual void BeginTransaction()
        {
            ////ตลอดการดำเนินการ Transaction  ผู้ใช้จะต้องกำหนด เปิด/ปิด Connection เอง
            ////เนื่องจาก Transaction จำเป็นต้องใช้ตัว Connection ตัวเดิมตลอด
            ////จึงจำเป็นต้องบังคับให้กำหนด KeepConnection เป็น True
            //if (!KeepConnection)
            //    throw new ApplicationException("Before begin new transaction, you should set KeepConnection be true");

            //if (this.m_IDbTransaction != null)
            //    throw new ApplicationException("Please commit or rollback transaction before begin new transaction");

            //DBTransactionState = TransactionState.PROCESSING;

            //if (DBConnectionState == ConnectionState.Closed)
            //    Open();

            //m_IDbTransaction = m_IDbConnection.BeginTransaction();

            BeginTransaction(IsolationLevel.Serializable);
        }

        /// <summary>
        /// เริ่ม Transaction
        /// </summary>
        public virtual void BeginTransaction(IsolationLevel isolationLevel)
        {
            //ตลอดการดำเนินการ Transaction  ผู้ใช้จะต้องกำหนด เปิด/ปิด Connection เอง
            //เนื่องจาก Transaction จำเป็นต้องใช้ตัว Connection ตัวเดิมตลอด
            //จึงจำเป็นต้องบังคับให้กำหนด KeepConnection เป็น True
            if (!KeepConnection)
                throw new ApplicationException("Before begin new transaction, you should set KeepConnection be true");

            if (this.m_IDbTransaction != null)
                throw new ApplicationException("Please commit or rollback transaction before begin new transaction");

            DBTransactionState = TransactionState.PROCESSING;

            if (DBConnectionState == ConnectionState.Closed)
                Open();

            m_IDbTransaction = m_IDbConnection.BeginTransaction(isolationLevel);
        }

        /// <summary>
        /// Commit Transaction
        /// </summary>
        public virtual void Commit()
        {
            m_IDbTransaction.Commit();
            m_IDbTransaction.Dispose();
            m_IDbTransaction = null;
            DBTransactionState = TransactionState.IDLE;
            //Tempolary Restore Keepconn = false for BESCO only
            this.KeepConnection = false;
        }

        /// <summary>
        /// Rollback Transaction
        /// </summary>
        public virtual void Rollback()
        {
            if (m_IDbTransaction != null)
            {
                m_IDbTransaction.Rollback();
                m_IDbTransaction.Dispose();
                m_IDbTransaction = null;
            }

            DBTransactionState = TransactionState.IDLE;
            //Tempolary Restore Keepconn = false for BESCO only
            this.KeepConnection = false;
        }
        #endregion

        #region Virtual methods

        /// <summary>
        /// เปิด Connection
        /// </summary>
        public virtual void Open()
        {
            m_IDbConnection.Open();
        }

        /// <summary>
        /// ปิด Connection
        /// </summary>
        public virtual void Close()
        {
            m_IDbConnection.Close();
        }

        /// <summary>
        /// แปล CommandText ให้อยู่ในรูปแบบคำสั่ง SQL ตาม Provider ของแต่ละ Database
        /// </summary>
        /// <param name="commandText">SQL Statement</param>
        /// <param name="parameterSymbol">สัญลักษณ์ที่จะนำมาแทน Parameter ใน SQL Command</param>
        /// <returns>SQL Statement belong to Provider</returns>
        internal virtual string ParseCommandText(string commandText, string parameterSymbol)
        {
            //Default parameter symbol คือ  "@"
            //Example : 
            // SELECT * FROM M_ITEM T
            // WHERE T.ITEM = @ITEM  
            //   AND T.VENDOR = '@C101'
            //ในกรณีนี้จะมี Parameter ตัวเดียว คือ @ITEM  
            //ส่วน @C101 ไม่เป็น Parameter เพราะ มี Single-Quote ครอบจึงถือว่าเป็น String


            //Tokenizer Lexical
            //Rule :
            // Alphabet ==> A-Z | 0-9
            // Symbol ==> ~!@#$%^&*|_+-/\[]{}
            // * ==> Alphabet | Symbol
            // [Parameter] ==> ":" -> Alphabet -> [Space, CR, LF, Comma, Tab] ==> [FinishState]
            // [String] ==> "'" -> * -> "'" ==> [FinishState]
            // Start check [Parameter] will be close [String].

            StringBuilder sb = new StringBuilder();
            StringBuilder sbBuffer = new StringBuilder();
            bool bQuoteEnclose = true;
            bool bParameterEnclose = true;

            for (int i = 0; i < commandText.Length; i++)
            {
                Char current_char = commandText[i];

                if (bQuoteEnclose)  // ถ้าสถานะของ Quote ยังปิดอยู่
                {
                    switch (current_char)
                    {
                        case '\'':
                            //พบ Single-Quote ตัวแรก  
                            //ข้อความหลังจากนี้ จะเป็น String
                            //จะปิดจนกว่าจะอ่านเจอ Single-Quote ตัวถัดไป
                            bQuoteEnclose = false;

                            //เก็บ Single-Quote
                            sb.Append(current_char);
                            break;
                        case ':':  // เมื่อพบจุดเริ่มต้นของ Parameter
                            bParameterEnclose = false;
                            //เก็บสัญลักษณ์ของ Parameter ตาม Provider ที่ระบุ
                            sbBuffer.Append(parameterSymbol);
                            break;
                        default:
                            if (bParameterEnclose) // ถ้าสถานะของ Parameter ยังปิดอยู่
                            {
                                sb.Append(current_char);
                            }
                            else
                            {
                                switch (current_char)
                                {
                                    case ' ':
                                    case '\r':
                                    case '\n':
                                    case '\t':
                                    case ',':
                                        sb.Append(sbBuffer.ToString());
                                        sb.Append(current_char);
                                        sbBuffer.Remove(0, sbBuffer.Length);
                                        bParameterEnclose = true;
                                        break;
                                    default:
                                        sbBuffer.Append(current_char);
                                        break;
                                }
                            }
                            break;
                    }

                }
                else  // ถ้าสถานะของ Quote เปิด
                {
                    switch (current_char)
                    {
                        case '\'':
                            //พบ Single-Quote ตัวแรก  
                            //ข้อความหลังจากนี้ จะเป็น String
                            //จะปิดจนกว่าจะอ่านเจอ Single-Quote ตัวถัดไป
                            bQuoteEnclose = true;

                            //เก็บ Single-Quote
                            sb.Append(current_char);
                            break;
                        default:
                            sb.Append(current_char);
                            break;

                    }
                }
            }

            sb.Append(sbBuffer.ToString());

            return sb.ToString();
        }
        #endregion

        #region Virtual must implementation
        /// <summary>
        /// Execute data request for list of data transfer object.
        /// It will execute command and parse field into strongly type of DTO.
        /// </summary>
        /// <typeparam name="T">Type of DTO</typeparam>
        /// <param name="request">DataRequest command and parameter.</param>
        /// <returns>List of DTO. If not found data it will return empty list.</returns>
        public virtual List<T> ExecuteForList<T>(DataRequest request) where T : IDataTransferObject
        {
            throw new NotImplementedException("Not Implement");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual IDataReader ExecuteDataReader(DataRequest request)
        {
            throw new NotImplementedException("Not Implement");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual DataSet ExecuteDataSet(DataRequest request)
        {
            throw new NotImplementedException("Not Implement");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual DataTable ExecuteQuery(DataRequest request)
        {
            throw new NotImplementedException("Not Implement");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual int ExecuteNonQuery(DataRequest request)
        {
            throw new NotImplementedException("Not Implement");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual object ExecuteScalar(DataRequest request)
        {
            throw new NotImplementedException("Not Implement");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual DataTable GetSchema(DataRequest request)
        {
            throw new NotImplementedException("Not Implement");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual ParameterCollection ExecutePackage(DataRequest request)
        {
            throw new NotImplementedException("Not Implement");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual ParameterCollection ExecutePackage(string name, Parameter[] parameters)
        {
            throw new NotImplementedException("Not Implement");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual ParameterCollection ExecutePackage(string name, ParameterCollection parameters)
        {
            throw new NotImplementedException("Not Implement");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="rowAffect"></param>
        /// <returns></returns>
        public virtual ParameterCollection ExecutePackage(DataRequest request, out int rowAffect)
        {
            throw new NotImplementedException("Not Implement");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameters"></param>
        /// <param name="rowAffect"></param>
        /// <returns></returns>
        public virtual ParameterCollection ExecutePackage(string name, Parameter[] parameters, out int rowAffect)
        {
            throw new NotImplementedException("Not Implement");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameters"></param>
        /// <param name="rowAffect"></param>
        /// <returns></returns>
        public virtual ParameterCollection ExecutePackage(string name, ParameterCollection parameters, out int rowAffect)
        {
            throw new NotImplementedException("Not Implement");
        }


        #endregion

        #region Abstract methods
        /// <summary>
        /// คัดลอก Parameter จาก ParameterCollection ใน DataRequest
        /// </summary>
        /// <param name="command">Command รับมาเพื่อเก็บ Parameter</param>
        /// <param name="request">DataRequest ที่เก็บ Parameter ที่จะคัดลอกลง Command</param>
        /// <returns>IDbCommand ที่คัดลอก Parameter แล้ว</returns>
        internal abstract void CopyParameters(IDbCommand command, DataRequest request);

        /// <summary>
        /// สร้างตัวแปร DbCommand
        /// ที่ได้ทำการแปลง Parameter ให้อยู่ในรูปแบบที่เหมาะสม ตาม Provider ที่กำหนด
        /// ซึ่งคำสั่งนี้จะต้อง ระบุ CommandType และ Transaction (ถ้าใช้)
        /// </summary>
        /// <param name="request">DataRequest</param>
        /// <returns>IDbCommand</returns>
        internal abstract IDbCommand CreateCommand(DataRequest request);

        /// <summary>
        /// Create new instance of connection
        /// </summary>
        /// <returns></returns>
        public abstract IDbConnection CreateConnection();

        /// <summary>
        /// Create new instance of Database
        /// </summary>
        /// <returns></returns>
        public abstract Database CreateNewDatabase();
        #endregion



    }
}
