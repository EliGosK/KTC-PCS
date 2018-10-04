using EVOFramework.Database;

namespace EVOFramework
{
    /// <summary>
    /// Application Context Manager of System.
    /// </summary>
    public static class ApplicationContextManager
    {
        #region Variables        
        /// <summary>
        /// Initialize this variable for own datasource load message description.
        /// </summary>
        private static IMessageLoader m_messageLoader;        
        #endregion

        #region Methods 
        /// <summary>
        /// Initialize this variable for own datasource load message description.
        /// </summary>
        public static void RegisterMessageLoader(IMessageLoader messageLoader) {
            m_messageLoader = messageLoader;
        }

        /// <summary>
        /// Release message loader.
        /// </summary>
        public static void UnregisterMessageLoader()
        {
            m_messageLoader = null;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Get MessageLoader.
        /// </summary>
        public static IMessageLoader MessageLoader
        {
            get
            {
                return m_messageLoader;
            }
        }

        

        #endregion

    }
}
