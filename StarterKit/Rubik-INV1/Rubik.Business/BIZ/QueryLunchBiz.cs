using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Rubik.DAO;
using Rubik.DTO;

namespace Rubik.BIZ
{
    public class QueryLunchBiz
    {
        public DataSet ExecuteSQLCommand(QueryLunchDTO dto)
        {
            DataSet dsResult = null;

            QueryLunchDAO dao = new QueryLunchDAO(CommonLib.Common.CurrentDatabase);

            dsResult = dao.ExecuteSQLCommand(dto);

            return dsResult;
        }


        public DataTable GetQueryList()
        {
            DataTable dtResult = null;


            QueryLunchDAO dao = new QueryLunchDAO(CommonLib.Common.CurrentDatabase);

            dtResult = dao.GetQueryList();


            return dtResult;
        }
    }
}
