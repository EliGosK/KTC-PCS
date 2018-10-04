using System;
using System.Text;
using System.IO;
using EVOFramework.Win32.API;

namespace EVOFramework.IO
{
    /// <summary>
    /// 
    /// </summary>
    public class IniFile : IDisposable
    {
        #region Variables
        private string m_path = String.Empty;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path"></param>
        /// <exception cref="DirectoryNotFoundException"><c>DirectoryNotFoundException</c>.</exception>
        public IniFile(string path) {
            string dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir))
                throw new DirectoryNotFoundException(String.Format("Not found directory: \"{0}\"", dir));
            
            this.m_path = path;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Write key and value into file.
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Write(string section, string key, string value) {
            return Kernel32.WritePrivateProfileString(section, key, value, m_path);
        }

        /// <summary>
        /// Read value from file.
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public string Read(string section, string key, string defaultValue) {            
            StringBuilder strReturned = new StringBuilder(1024);            
            int nSizeRead = Kernel32.GetPrivateProfileString(section, key, defaultValue, strReturned, strReturned.Capacity, m_path);
            return strReturned.ToString();
        }
        #endregion


        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            m_path = String.Empty;
        }
        #endregion
    }
}
