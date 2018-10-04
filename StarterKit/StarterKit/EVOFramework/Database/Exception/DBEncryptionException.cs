using System;


namespace EVOFramework.Database
{
    public class DBEncryptionException : Exception
    {
        private string m_message = string.Empty;

        public DBEncryptionException(string message)
        {
            this.m_message = message;            
        }        
        
        public override string Message
        {
            get
            {
                return this.m_message;
            }
        }
    }
}
