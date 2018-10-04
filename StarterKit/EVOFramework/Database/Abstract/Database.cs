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
        /// ����� Transaction
        /// </summary>
        public virtual void BeginTransaction()
        {
            ////��ʹ��ô��Թ��� Transaction  �����е�ͧ��˹� �Դ/�Դ Connection �ͧ
            ////���ͧ�ҡ Transaction ���繵�ͧ���� Connection ��������ʹ
            ////�֧���繵�ͧ�ѧ�Ѻ����˹� KeepConnection �� True
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
        /// ����� Transaction
        /// </summary>
        public virtual void BeginTransaction(IsolationLevel isolationLevel)
        {
            //��ʹ��ô��Թ��� Transaction  �����е�ͧ��˹� �Դ/�Դ Connection �ͧ
            //���ͧ�ҡ Transaction ���繵�ͧ���� Connection ��������ʹ
            //�֧���繵�ͧ�ѧ�Ѻ����˹� KeepConnection �� True
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
        /// �Դ Connection
        /// </summary>
        public virtual void Open()
        {
            m_IDbConnection.Open();
        }

        /// <summary>
        /// �Դ Connection
        /// </summary>
        public virtual void Close()
        {
            m_IDbConnection.Close();
        }

        /// <summary>
        /// �� CommandText ���������ٻẺ����� SQL ��� Provider �ͧ���� Database
        /// </summary>
        /// <param name="commandText">SQL Statement</param>
        /// <param name="parameterSymbol">�ѭ�ѡɳ���й���᷹ Parameter � SQL Command</param>
        /// <returns>SQL Statement belong to Provider</returns>
        internal virtual string ParseCommandText(string commandText, string parameterSymbol)
        {
            //Default parameter symbol ���  "@"
            //Example : 
            // SELECT * FROM M_ITEM T
            // WHERE T.ITEM = @ITEM  
            //   AND T.VENDOR = '@C101'
            //㹡óչ����� Parameter ������� ��� @ITEM  
            //��ǹ @C101 ����� Parameter ���� �� Single-Quote ��ͺ�֧�������� String


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

                if (bQuoteEnclose)  // ���ʶҹТͧ Quote �ѧ�Դ����
                {
                    switch (current_char)
                    {
                        case '\'':
                            //�� Single-Quote ����á  
                            //��ͤ�����ѧ�ҡ��� ���� String
                            //�лԴ�����Ҩ���ҹ�� Single-Quote ��ǶѴ�
                            bQuoteEnclose = false;

                            //�� Single-Quote
                            sb.Append(current_char);
                            break;
                        case ':':  // ����;��ش������鹢ͧ Parameter
                            bParameterEnclose = false;
                            //���ѭ�ѡɳ�ͧ Parameter ��� Provider ����к�
                            sbBuffer.Append(parameterSymbol);
                            break;
                        default:
                            if (bParameterEnclose) // ���ʶҹТͧ Parameter �ѧ�Դ����
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
                else  // ���ʶҹТͧ Quote �Դ
                {
                    switch (current_char)
                    {
                        case '\'':
                            //�� Single-Quote ����á  
                            //��ͤ�����ѧ�ҡ��� ���� String
                            //�лԴ�����Ҩ���ҹ�� Single-Quote ��ǶѴ�
                            bQuoteEnclose = true;

                            //�� Single-Quote
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
        /// �Ѵ�͡ Parameter �ҡ ParameterCollection � DataRequest
        /// </summary>
        /// <param name="command">Command �Ѻ�������� Parameter</param>
        /// <param name="request">DataRequest ����� Parameter ���ФѴ�͡ŧ Command</param>
        /// <returns>IDbCommand ���Ѵ�͡ Parameter ����</returns>
        internal abstract void CopyParameters(IDbCommand command, DataRequest request);

        /// <summary>
        /// ���ҧ����� DbCommand
        /// �����ӡ���ŧ Parameter ���������ٻẺ���������� ��� Provider ����˹�
        /// ��觤���觹��е�ͧ �к� CommandType ��� Transaction (�����)
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
