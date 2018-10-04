using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;

namespace EVOFramework.Data
{
    public class SqlExecute : IExecutable
    {
        #region Variables
        private SqlExecuteScript m_script = null;
        #endregion

        #region Constructor        

        /// <summary>
        /// This object should be create by SqlExecuteScript.
        /// </summary>
        /// <param name="script"></param>
        public SqlExecute()
        {            
        }        
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public SqlExecuteScript Parent {
            get { return m_script; }
            internal set { m_script = value;}
        }
        #endregion

        #region Implementation of IExecutable

        /// <summary>
        /// Execute operation.
        /// </summary>
        public virtual void Execute() {}

        #endregion
    }
}
