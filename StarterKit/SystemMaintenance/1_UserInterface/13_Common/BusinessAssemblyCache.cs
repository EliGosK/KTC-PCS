using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using EVOFramework.Data;

namespace SystemMaintenance
{
    /// <summary>
    /// <para>BusinessAssembly Cache. So own process will has one instance only!!!.</para>
    /// <para>Before call GetInstance method, should be finish to create database connect.</para>
    /// </summary>
    public class BusinessAssemblyCache
    {
        /// <summary>
        /// Singletion instance.
        /// </summary>
        private static BusinessAssemblyCache m_instance = null;

        /// <summary>
        /// Get list of business assembly which registered on system.
        /// <para>Key: Business ID</para>
        /// <para>Value: Assembly type.</para>
        /// </summary>
        private readonly Map<string, Assembly> m_mapAssembly = new Map<string, Assembly>();

        #region Constructor
        private BusinessAssemblyCache() {
            InitializeBusinessAssembly();
            
        }

        private void InitializeBusinessAssembly() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get singleton static instance.
        /// </summary>
        /// <returns></returns>
        public static BusinessAssemblyCache GetInstance() {
            if (m_instance == null)
                m_instance = new BusinessAssemblyCache();

            return m_instance;
        }
        #endregion
    }
}
