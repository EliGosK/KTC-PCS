using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Data;
using EVOFramework.Database;
using CommonLib;
using System.Data;
using SystemMaintenance.UIDataModel;
using SystemMaintenance.DTO;
using EVOFramework;
using SystemMaintenance.DAO;

namespace SystemMaintenance.Oracle.DAO
{
    internal class MenuDAO : IMenuDAO
    {
        private readonly Database m_database = Common.CurrentDatabase;

        #region Constructor
        public MenuDAO() { }

        public MenuDAO(Database db)
        {
            this.m_database = db;
        }
        #endregion


        public string GetMenuSetCDFromUser(string USER_ACCOUNT)
        {

            string strSql = "SELECT T.MENU_SET_CD FROM TZ_USER_MS T WHERE T.USER_ACCOUNT=:USER_ACCOUNT";
            DataRequest req = new DataRequest(strSql);
            req.Parameters.Add("USER_ACCOUNT", DataType.VarChar, USER_ACCOUNT);
            return Convert.ToString(m_database.ExecuteScalar(req));
        }

        /// <summary>
        /// Get list of MenuSub from specific user code.
        /// </summary>
        /// <param name="USER_ACCOUNT"></param>
        /// <param name="DEF_LANG"></param>
        /// <returns></returns>
        public List<MenuSub> GetAllMenuSubFromUser(NZString USER_ACCOUNT, NZString DEF_LANG)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT ");
            sb.AppendLine("    MNU_SUB.MENU_SUB_CD,");
            sb.AppendLine("    MNU_SUB.MENU_SUB_NAME, ");
            sb.AppendLine(String.Format("    {0}FNZ_GET_MENU_SUB_DESC(MNU_SUB.MENU_SUB_CD, USR.LANG_CD, :I_DEF_LANG) MENU_SUB_DESC,",
                (m_database.Credential.Provider == DatabaseProvider.SQLSERVER) ? "dbo." : string.Empty));
            sb.AppendLine("    MNU_SUB.IMAGE_CD,");
            sb.AppendLine("     WF.WF_ID WORKFLOW_ID");
            sb.AppendLine(" FROM ");
            sb.AppendLine("   TZ_USER_MS USR");
            sb.AppendLine("     INNER JOIN TZ_MENU_SET_DETAIL_MS MNU_DTL    ");
            sb.AppendLine("        ON MNU_DTL.MENU_SET_CD = USR.MENU_SET_CD");

            sb.AppendLine("     INNER JOIN TZ_MENU_SUB_MS MNU_SUB");
            sb.AppendLine("        ON MNU_SUB.MENU_SUB_CD = MNU_DTL.MENU_SUB_CD");

            sb.AppendLine("     LEFT JOIN TZ_MENU_SUB_WF WF");
            sb.AppendLine("         ON MNU_SUB.MENU_SUB_CD = WF.MENU_SUB_CD");

            sb.AppendLine(" WHERE USR.USER_ACCOUNT = :I_USER_ACCOUNT");
            sb.AppendLine(" ORDER BY ");
            sb.AppendLine("   MNU_DTL.DISP_SEQ, MNU_SUB.MENU_SUB_CD");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("I_USER_ACCOUNT", DataType.VarChar, USER_ACCOUNT.Value);
            req.Parameters.Add("I_DEF_LANG", DataType.VarChar, DEF_LANG.Value);
            return m_database.ExecuteForList<MenuSub>(req);
        }

        /// <summary>
        /// Get all menu item that underly on specific MenuSub.
        /// </summary>
        /// <param name="MENU_SUB_CD"></param>
        /// <returns></returns>
        public List<MenuSubItemDTO> GetAllMenuSubItem(string MENU_SUB_CD, string USER_ACCOUNT)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT ");
            sb.AppendLine("   ITEM.MENU_SUB_CD ");
            sb.AppendLine("   ,ITEM.SCREEN_CD ");
            sb.AppendLine("   ,ITEM.DISP_SEQ ");
            sb.AppendLine("   ,ITEM.CRT_BY ");
            sb.AppendLine("   ,ITEM.CRT_DATE ");
            sb.AppendLine("   ,ITEM.CRT_MACHINE ");
            sb.AppendLine("   ,ITEM.UPD_BY ");
            sb.AppendLine("   ,ITEM.UPD_DATE ");
            sb.AppendLine("   ,ITEM.UPD_MACHINE ");
            sb.AppendLine(" FROM TZ_MENU_SUB_ITEM_MS ITEM");
            sb.AppendLine(" WHERE ITEM.MENU_SUB_CD = :MENU_SUB_CD");
            sb.AppendLine(" ORDER BY ");
            sb.AppendLine("   ITEM.DISP_SEQ");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("MENU_SUB_CD", DataType.VarChar, MENU_SUB_CD);

            return m_database.ExecuteForList<MenuSubItemDTO>(req);
        }

        public DataTable GetScreenFavorite(string USER_ACCOUNT)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT FAV.SCREEN_CD ");
            sb.AppendLine(" FROM TZ_FAVORITE FAV ");
            sb.AppendLine(" WHERE FAV.USER_ACCOUNT = :USER_ACCOUNT ");
            sb.AppendLine(" ORDER BY FAV.SEQ ");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("USER_ACCOUNT", DataType.NVarChar, USER_ACCOUNT);

            return m_database.ExecuteQuery(req);
        }

        public int GetLastFavoriteSeq(string USER_ACCOUNT)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT NVL(MAX(FAV.SEQ), 0) + 1 ");
            sb.AppendLine(" FROM TZ_FAVORITE FAV ");
            sb.AppendLine(" WHERE FAV.USER_ACCOUNT = :USER_ACCOUNT");
            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("USER_ACCOUNT", DataType.VarChar, USER_ACCOUNT);

            return Convert.ToInt32(m_database.ExecuteScalar(req));
        }

        public void AddNewFavorite(string USER_ACCOUNT, string SCREEN_CD)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" INSERT INTO TZ_FAVORITE FAV ");
            sb.AppendLine(" VALUES(:USER_ACCOUNT, :SCREEN_CD, :SEQ) ");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("USER_ACCOUNT", DataType.VarChar, USER_ACCOUNT);
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, SCREEN_CD);
            req.Parameters.Add("SEQ", DataType.Number, GetLastFavoriteSeq(USER_ACCOUNT));


            m_database.ExecuteNonQuery(req);
        }

        public void DeleteFavorite(string USER_ACCOUNT, string SCREEN_CD)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" DELETE FROM TZ_FAVORITE  ");
            sb.AppendLine(" WHERE USER_ACCOUNT = :USER_ACCOUNT ");
            sb.AppendLine(" AND SCREEN_CD =  :SCREEN_CD ");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("USER_ACCOUNT", DataType.VarChar, USER_ACCOUNT);
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, SCREEN_CD);

            m_database.ExecuteNonQuery(req);
        }
    }
}
