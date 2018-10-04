using System;

namespace EVOFramework
{
    /// <summary>
    /// Message
    /// </summary>
    public class Message
    {

        #region Variables

        /// <summary>
        /// Empty arguments
        /// </summary>
        public readonly static object[] EmptyArguments = new object[0];

        private readonly string m_messageCode = String.Empty;
        private string m_messageDescription = String.Empty;
        private object[] m_objParameters = EmptyArguments;
        #endregion

        #region Constructor
        /// <summary>
        /// Input message code, and then it will auto retrieve message description from current datasource.
        /// </summary>
        /// <param name="messageCode"></param>
        /// <param name="args">Arguments for placeholder.</param>
        public Message(string messageCode, object[] args)
        {            
            this.m_messageCode = messageCode;
            this.m_objParameters = args ?? EmptyArguments;
            RetrieveMessageDescription();
        }
        /// <summary>
        /// Input message code, and then it will auto retrieve message description from current datasource.
        /// </summary>
        /// <param name="messageCode"></param>
        public Message(string messageCode) : this(messageCode, EmptyArguments) { }

        /// <summary>
        /// Define custom message code and message description. It will not load from database.
        /// </summary>
        /// <param name="messageCode"></param>
        /// <param name="messageDescription"></param>
        /// <param name="args">Arguments for placeholder.</param>
        public Message(string messageCode, string messageDescription, object[] args)            
        {
            this.m_messageCode = messageCode;
            this.m_messageDescription = messageDescription;            
            this.m_objParameters = args ?? EmptyArguments;            
        }
        /// <summary>
        /// Define custom message code and message description. It will not load from database.
        /// </summary>
        /// <param name="messageCode"></param>
        /// <param name="messageDescription"></param>
        public Message(string messageCode, string messageDescription) : this(messageCode, messageDescription, EmptyArguments) { }

        #endregion

        #region Properties

        /// <summary>
        /// Get or set message code.
        /// </summary>
        public string MessageCode
        {
            get { return m_messageCode; }
        }

        /// <summary>
        /// Get or set message description.
        /// </summary>
        public string MessageDescription
        {
            get { return String.Format(m_messageDescription, m_objParameters); }
        }

        #endregion

        #region Private method
        /// <summary>
        /// Load message description from current message code.
        /// </summary>
        private void RetrieveMessageDescription() {
            if (m_messageCode == null || m_messageCode.Trim() == String.Empty) {
                m_messageDescription = String.Empty;
                return;
            }

            // Load message description.
            if (ApplicationContextManager.MessageLoader != null) {
                m_messageDescription = ApplicationContextManager.MessageLoader.LoadDecription(m_messageCode);
            } else {
                m_messageDescription = ResourceBundle.APP_CONTEXT.S_MESSAGE_LOADER_UNREGISTERED;
            }
        }
        #endregion

        #region Static method
        /// <summary>
        /// Retrieve message description from given message code.
        /// </summary>
        /// <param name="messageCode">Specific message code.</param>
        /// <returns></returns>
        public static Message LoadMessage(string messageCode) {
            return new Message(messageCode);
        }

        public static Message LoadMessage(string messageCode, object[] args) {
            return new Message(messageCode, args);
        }
        #endregion
    }   
}
