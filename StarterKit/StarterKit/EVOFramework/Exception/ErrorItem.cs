using System.Collections.Generic;
using EVOFramework.Windows.Forms;


namespace EVOFramework
{
    /// <summary>
    /// Validate result.
    /// </summary>
    public class ErrorItem
    {
        #region Variables
        private readonly IControlIdentify m_controlIdentify;
        private readonly Message m_message;
        #endregion

        #region Constructor

        public ErrorItem(IControlIdentify controlIdentify,  string messageCode)
        {
            m_controlIdentify = controlIdentify;
            m_message = new Message(messageCode);            
        }
        public ErrorItem(IControlIdentify controlIdentify, string messageCode, object[] args) {
            m_controlIdentify = controlIdentify;
            m_message = new Message(messageCode, args);
        }

        public ErrorItem(IControlIdentify controlIdentify, string messageCode, string messageDescription)
        {
            m_controlIdentify = controlIdentify;
            m_message = new Message(messageCode, messageDescription);
        }

        public ErrorItem(IControlIdentify controlIdentify, string messageCode, string messageDescription, object[] args) {
            m_controlIdentify = controlIdentify;
            m_message = new Message(messageCode, messageDescription, args); 
        }
        

        #endregion

        #region Properties

        

        /// <summary>
        /// Get or set owner control identify.
        /// </summary>
        public IControlIdentify ControlIdentify {
            get { return m_controlIdentify; }            
        }

        /// <summary>
        /// Get message structure.
        /// </summary>
        public Message Message {
            get { return m_message; }
        }


        #endregion

        /// <summary>
        /// Focus on trap control.
        /// </summary>
        /// <returns>Return false if can't access object. Othwerise return true.</returns>
        public bool FocusOnControl()
        {
            if (m_controlIdentify == null)
            {
                return false;
            }
            m_controlIdentify.FocusOnControl();
            return true;
        }
    }

    /// <summary>
    /// Validate result collection.
    /// </summary>
    public class ErrorList : List<ErrorItem>
    {

    }


}
