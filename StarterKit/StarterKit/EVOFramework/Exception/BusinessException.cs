using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVOFramework
{
    /// <summary>
    /// Business Exception.
    /// </summary>
    public class BusinessException : Exception
    {
        private readonly ErrorItem m_error;

        public BusinessException(ErrorItem error)
            : this(error, null) {}

        public BusinessException(ErrorItem error, Exception innerException)
            : this(error, string.Empty, innerException) {
            this.m_error = error;
        }

        public BusinessException(ErrorItem error, string message, Exception innerException) 
            : base(message, innerException) {
            m_error = error; 
        }

        public ErrorItem Error {
            get { return m_error; }
        }
    }
}
