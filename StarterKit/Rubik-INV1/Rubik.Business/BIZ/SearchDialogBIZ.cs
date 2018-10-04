using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Rubik.DAO;
using EVOFramework.Database;

namespace Rubik.BIZ
{
    public class SearchDialogBIZ
    {
        public DataTable searchData(string argStoredProcedure, ParameterCollection argParameters)
        {
            DataTable ret = null;

            SearchDialogDAO dao = new SearchDialogDAO(CommonLib.Common.CurrentDatabase);
            ret = dao.searchData(argStoredProcedure, argParameters);

            return ret;
        }
    }
}
