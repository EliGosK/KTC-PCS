using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rubik.DTO;
using Rubik.DAO;
using EVOFramework;

namespace Rubik.BIZ
{
    public class DealingConstraintBIZ
    {
        public DealingConstraintDTO LoadDealingConstraint(NZString Process)
        {
            DealingConstraintDAO dao = new DealingConstraintDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadByPK(null, Process);
        }

        public List<DealingConstraintDTO> LoadConstraintByValue(NZString ConstraintName, NZInt ConstraintFlag)
        {
            DealingConstraintDAO dao = new DealingConstraintDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadByConstraint(null, ConstraintName, ConstraintFlag);
        }

    }
}
