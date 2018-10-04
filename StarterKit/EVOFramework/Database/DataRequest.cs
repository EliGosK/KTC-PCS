using System;
using System.Data;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EVOFramework.Database
{
    [Serializable()]
    public sealed class DataRequest : IDisposable
    {
        private string m_strCommandText = String.Empty;
        private CommandType m_commandType = CommandType.Text;
        private string m_strResultTableName = String.Empty;
        private ParameterCollection m_parameters = new ParameterCollection();
        private int m_iTimeout = 0;


        public DataRequest() { }
        public DataRequest(string commandText)
        {
            this.m_strCommandText = commandText;
        }

        /// <summary>
        /// Get or set Command text.
        /// </summary>
        public string CommandText
        {
            get { return this.m_strCommandText; }
            set { this.m_strCommandText = value; }
        }

        /// <summary>
        /// Get or set Command Type.
        /// </summary>
        public CommandType CommandType
        {
            get { return this.m_commandType; }
            set { this.m_commandType = value; }
        }

        /// <summary>
        /// Get or set Result Table Name.
        /// </summary>
        public string ResultTableName
        {
            get { return this.m_strResultTableName; }
            set { this.m_strResultTableName = value; }
        }

        /// <summary>
        /// Get or set ParameterCollection
        /// </summary>
        public ParameterCollection Parameters
        {
            get { return this.m_parameters; }
            set { this.m_parameters = value; }
        }

        public int Timeout
        {
            get { return m_iTimeout; }
            set { m_iTimeout = value; }
        }

        public void PrintOut()
        {
            throw new Exception("Implementation doesn't write");
        }

        /// <summary>
        /// Serialize own object to binary.
        /// </summary>
        /// <returns></returns>
        public byte[] SerializeObject()
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(memStream, this);
            memStream.Close();

            return memStream.ToArray();
        }

        public static DataRequest DeserializeObject(byte[] binary)
        {
            MemoryStream memStream = new MemoryStream(binary);
            BinaryFormatter bformatter = new BinaryFormatter();
            DataRequest req = bformatter.Deserialize(memStream) as DataRequest;
            return req;
        }

        /// <summary>
        /// Allows an <see cref="T:System.Object"/> to attempt to free resources and perform other cleanup operations before the <see cref="T:System.Object"/> is reclaimed by garbage collection.
        /// </summary>
        ~DataRequest()
        {
            m_parameters.Clear();
            ((IDisposable)this).Dispose();
        }

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion


    }
}
