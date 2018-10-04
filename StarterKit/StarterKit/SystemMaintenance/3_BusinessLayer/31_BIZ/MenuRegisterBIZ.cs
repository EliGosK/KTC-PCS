using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SystemMaintenance.Oracle.DAO;
using SystemMaintenance.DTO;
using EVOFramework;
using EVOFramework.Database;

namespace SystemMaintenance.BIZ
{
    public class MenuRegisterBIZ
    {
        #region Save functions
        /// <summary>
        /// Update menu item sequence.
        /// </summary>
        /// <param name="menuSubCD"></param>
        /// <param name="screenCD"></param>
        /// <param name="newSequence"></param>
        /// <returns></returns>
        public int UpdateMenuItemSequence(NZString menuSubCD, NZString screenCD, NZInt newSequence)
        {
            MenuSubItemDAO dao = new MenuSubItemDAO(CommonLib.Common.CurrentDatabase);
            return dao.UpdateSequence(null, menuSubCD, screenCD, CommonLib.Common.CurrentUserInfomation.UserCD, CommonLib.Common.CurrentUserInfomation.Machine, newSequence);
        }

        /// <summary>
        /// Swap display sequence of Menu Item.
        /// </summary>
        /// <param name="sourceMenuSubCD"></param>
        /// <param name="sourceScreenCD"></param>
        /// <param name="destMenuSubCD"></param>
        /// <param name="destScreenCD"></param>
        public void SwapDisplaySequence(NZString sourceMenuSubCD, NZString sourceScreenCD, NZString destMenuSubCD, NZString destScreenCD)
        {
            Database db = CommonLib.Common.CurrentDatabase;
            MenuSubItemDAO daoMenuSubItem = new MenuSubItemDAO(CommonLib.Common.CurrentDatabase);
            try
            {
                db.KeepConnection = true;
                db.BeginTransaction();

                MenuSubItemDTO fromMenuSubItem = daoMenuSubItem.LoadByPK(null, sourceMenuSubCD, sourceScreenCD);
                MenuSubItemDTO toMenuSubItem = daoMenuSubItem.LoadByPK(null, destMenuSubCD, destScreenCD);

                NZString UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                NZString UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

                daoMenuSubItem.UpdateSequence(null, sourceMenuSubCD, sourceScreenCD, UPD_BY, UPD_MACHINE, toMenuSubItem.DISP_SEQ);
                daoMenuSubItem.UpdateSequence(null, destMenuSubCD, destScreenCD, UPD_BY, UPD_MACHINE, fromMenuSubItem.DISP_SEQ);

                db.Commit();
            }
            catch
            {
                db.Rollback();
                throw;
            }
            finally
            {
                if (db.DBConnectionState == ConnectionState.Open)
                    db.Close();
            }

        }
        #endregion
    }
}
