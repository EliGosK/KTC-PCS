using System;
using EVOFramework.Windows.Forms;
using EVOFramework.Data;
using System.Collections.Generic;

namespace EVOFramework
{
    /// <summary>
    /// Validate exception.
    /// </summary>
    public class ValidateException : ApplicationException
    {
        /// <summary>
        /// Error validate list.
        /// </summary>
        private readonly List<ErrorItem> m_errorList = new List<ErrorItem>();        

        #region Constructor

        public ValidateException() {            
        }

        public ValidateException(string message) 
            : base(message) {         
        }

        public ValidateException(string message, Exception innerException) 
            : base(message, innerException) {
        }

        #endregion

        #region " Error "
        #region Add Error
        public void AddError(ErrorItem errorItem) {
            if (errorItem == null)
                return;

            m_errorList.Add(errorItem);
        }

        public void AddError(IControlIdentify controlIdentify, string messageCode) {
            ErrorItem errorItem = new ErrorItem(controlIdentify, messageCode);
            m_errorList.Add(errorItem);
        }

        public void AddError(IControlIdentify controlIdentify, string messageCode, string messageDescription)
        {
            ErrorItem errorItem = new ErrorItem(controlIdentify, messageCode, messageDescription);
            m_errorList.Add(errorItem);
        }
        #endregion

        public void ClearError() {
            m_errorList.Clear();
        }

        #region AddError with condition
        public void AddErrorWithCondition(bool isError, ErrorItem errorItem)
        {
            if (isError)
                AddError(errorItem);
        }

        public void AddErrorWithCondition(bool isError, IControlIdentify controlIdentify, string messageCode)
        {
            if (isError)
                AddError(controlIdentify, messageCode);
        }

        public void AddErrorWithCondition(bool isError, IControlIdentify controlIdentify, string messageCode, string messageDescription)
        {
            if (isError)
                AddError(controlIdentify, messageCode, messageDescription);
        }
        #endregion
        #endregion

        /// <summary>
        /// Get validate error results.
        /// </summary>
        public List<ErrorItem> ErrorResults {
            get { return m_errorList;}
        }

        /// <summary>
        /// If has some validate error result, it will throw exception.
        /// </summary>
        /// <exception cref="ValidateException"><c>ValidateException</c>.</exception>
        public void ThrowIfHasError() {
            if (m_errorList.Count > 0) 
                throw this;
        }

        /// <summary>
        /// Use for throw single error item.
        /// </summary>
        /// <param name="errorItem"></param>
        /// <exception cref="EVOFramework.ValidateException"><c>ValidateException</c>.</exception>
        public static void ThrowErrorItem(ErrorItem errorItem) {
            ValidateException validateException = new ValidateException();
            validateException.AddError(errorItem);
            validateException.ThrowIfHasError();
        }
    }    
}
