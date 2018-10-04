using EVOFramework.Data;

namespace EVOFramework
{
    /// <summary>
    /// All of Internal Messaage.
    /// </summary>
    public static class ResourceBundle
    {
        /// <summary>
        /// Common string constant.
        /// </summary>
        public class ALL {
            public const string S_INVALID_CAST_TYPE = "Cannot cast type from {0} to {1}";
            public const string S_CANNOT_USE_DB = "Cannot determine to use database.";
            public const string S_NOT_FOUND_MESSAGE_CODE = "Cannot access message code: {0} on language: {1}";            
        }        

        public class APP_CONTEXT {
            public const string S_MESSAGE_LOADER_UNREGISTERED = "MessageLoader is not register into ApplicationContextManager.";
        }
        
        /// <summary>
        /// System Messages.
        /// </summary>
        public class MESSAGES {
            /// <summary>
            /// SYS00001: Cannot connect to database.
            /// </summary>
            public static MapKeyValue<string, string> SYS00001 = new MapKeyValue<string, string>("SYS00001", @"Cannot connect to database. Please contact Admin to check system.");

        }
    }
}
