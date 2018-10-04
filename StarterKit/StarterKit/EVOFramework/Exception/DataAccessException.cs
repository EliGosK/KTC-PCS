using System;
using EVOFramework.Database;

namespace EVOFramework
{
    /// <summary>
    /// This Exception should be occurs on Data Access Layer.
    /// </summary>
    public class DataAccessException : Exception
    {        
        private DataRequest m_dataRequest;

        public DataAccessException(string message) : base(message)
        {              
        }
        public DataAccessException(string message, Exception innerException) : base(message, innerException) {
         
        }
        
        /// <summary>
        /// 
        /// </summary>
        public DataRequest DataRequest
        {
            get { return m_dataRequest; }
            set { m_dataRequest = value;}
        }
    }
}
