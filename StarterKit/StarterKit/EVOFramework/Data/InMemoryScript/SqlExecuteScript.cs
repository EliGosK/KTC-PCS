using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVOFramework.Data
{
    public class SqlExecuteScript : BaseExecuteScript<SqlExecute>
    {
        #region Variables
        #endregion

        #region Constructor
        public SqlExecuteScript() {            
        }
        #endregion

        #region Properties
        
        #endregion        

        #region Overriden method
        public override void Add(SqlExecute item)
        {
            item.Parent = this;
            base.Add(item);
        }

        public override bool Remove(SqlExecute item)
        {
            item.Parent = null;
            return base.Remove(item);
        }
        #endregion
    }
}
