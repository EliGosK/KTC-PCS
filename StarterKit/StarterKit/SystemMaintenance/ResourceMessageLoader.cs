using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;

namespace SystemMaintenance
{
    /// <summary>
    /// Load message from internal resource
    /// </summary>
    public class ResourceMessageLoader : IMessageLoader
    {
        #region IMessageLoader Members

        /// <summary>
        /// Load message description
        /// </summary>
        /// <param name="msgCode">Message Code.</param>        
        /// <returns>Description.</returns>
        public string LoadDecription(string msgCode)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
