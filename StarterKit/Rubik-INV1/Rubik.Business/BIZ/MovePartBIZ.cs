using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EVOFramework;
using Rubik.DAO;
using CommonLib;

namespace Rubik.BIZ {
    public class MovePartBIZ 
    {
        public DataTable LoadMovePartList(NZDateTime DateBegin, NZDateTime DateEnd, bool IncludeOldData) {

            MovePartDAO dao = new MovePartDAO(Common.CurrentDatabase);
            return dao.LoadMovePartList(DateBegin, DateEnd, IncludeOldData);
        }


    }
}
