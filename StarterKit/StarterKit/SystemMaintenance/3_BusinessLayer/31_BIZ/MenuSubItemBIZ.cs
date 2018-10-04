using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SystemMaintenance.DTO;
using EVOFramework;
using EVOFramework.Database;
using EVOFramework.Windows.Forms;
using SystemMaintenance.DAO;

namespace SystemMaintenance.BIZ
{
    public class MenuSubItemBIZ
    {
        public List<MenuSubItemDTO> LoadMenuSubItemOfMenuSub(NZString MENU_SUB_CD) {
            IMenuSubItemDAO dao = DAOFactory.CreateMenuSubItemDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadAllMenuSubItemsFromMenuSub(null, MENU_SUB_CD);
        }
        public List<ScreenDTO> LoadAllScreenExcludeOnMenuSub(NZString MENU_SUB_CD) {
            IMenuSubItemDAO dao = DAOFactory.CreateMenuSubItemDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadAllScreenExcludeOnMenuSub(null, MENU_SUB_CD);
        }

        /// <summary>
        /// Load all screen that on the given MenuSubCD and ScreenType must is not  "Dialog", "FindDialog", "Table"
        /// </summary>
        /// <param name="MENU_SUB_CD"></param>
        /// <returns></returns>
        public List<ScreenDTO> LoadAllScreenForRegister(NZString MENU_SUB_CD) {
            IMenuSubItemDAO dao = DAOFactory.CreateMenuSubItemDAO(CommonLib.Common.CurrentDatabase);
            List<ScreenDTO> list = dao.LoadAllScreenExcludeOnMenuSub(null, MENU_SUB_CD);

            for (int i=list.Count - 1; i>= 0; i--) {
                int screenType = list[i].SCREEN_TYPE.NVL(-1);
                if (screenType == (int)eScreenType.Dialog
                    || screenType == (int)eScreenType.FindDialog
                    || screenType == (int)eScreenType.Table
                    )
                    list.Remove(list[i]);
            }

            return list;
        }

        public void AddMenuSubItems(NZString MENU_SUB_CD, params NZString[] SCREEN_CDs) {
            Database db = CommonLib.Common.CurrentDatabase;

            db.KeepConnection = true;
            db.BeginTransaction();
            try
            {
                IMenuSubItemDAO dao = DAOFactory.CreateMenuSubItemDAO(db);
                for (int i = 0; i < SCREEN_CDs.Length; i++)
                {
                    // Get new seq of MenuSubItem;
                    NZInt seq = dao.GetNewSequenceNo(null, MENU_SUB_CD);


                    MenuSubItemDTO data = new MenuSubItemDTO();
                    data.MENU_SUB_CD = MENU_SUB_CD;
                    data.SCREEN_CD = SCREEN_CDs[i];
                    data.DISP_SEQ = seq;
                    data.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                    data.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
                    data.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                    data.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

                    dao.AddNew(null, data);
                }
                db.Commit();

            }
            catch (Exception err)
            {
                db.Rollback();
                throw err;
            }
            finally
            {
                if (db.DBConnectionState == ConnectionState.Open)
                    db.Close();
            }
        }
        public void RemoveMenuSubItems(NZString MENU_SUB_CD, params NZString[] SCREEN_CDs) {
            Database db = CommonLib.Common.CurrentDatabase;

            db.KeepConnection = true;
            db.BeginTransaction();
            try {
                IMenuSubItemDAO dao = DAOFactory.CreateMenuSubItemDAO(db);
                for (int i=0; i<SCREEN_CDs.Length; i++) {
                    dao.Delete(null, MENU_SUB_CD, SCREEN_CDs[i]);
                }                
                db.Commit();

            } catch (Exception err) {
              db.Rollback();
                throw err;
            } finally {
                if (db.DBConnectionState == ConnectionState.Open)
                    db.Close();
            }
        }


    }
}
