using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using EVOFramework.Database;
using Rubik.DTO;

namespace Rubik.DAO
{
    partial class ScreenDetailDynamicDialogLangDAO : BaseDAO
    {
        private Database m_db;

        public ScreenDetailDynamicDialogLangDAO(Database db)
        {
            m_db = db;
        }

        protected Database UseDatabase(Database specificDB)
        {
            if (specificDB != null)
                return specificDB;

            if (this.m_db != null)
                return this.m_db;

            throw new DataAccessException(ResourceBundle.ALL.S_CANNOT_USE_DB);
        }

        public List<ScreenDetailDynamicDialogLangDTO> LoadScreenDetailByLangCD(Database database, string SCREEN_CD, string LANG_CD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" SELECT ");
            sb.AppendLine("   CONTROL_CD");
            sb.AppendLine("   ,LANG_CD");
            sb.AppendLine("   ,SCREEN_CD");
            sb.AppendLine("   ,CONTROL_CAPTION");

            sb.AppendLine(" FROM TZ_SCREEN_DETAIL_DYNAMIC_DLG_LANG_MS ");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("       SCREEN_CD=:SCREEN_CD");
            sb.AppendLine("   AND LANG_CD=:LANG_CD");

            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("LANG_CD", DataType.VarChar, LANG_CD);
            req.Parameters.Add("SCREEN_CD", DataType.VarChar, SCREEN_CD);
            #endregion

            return db.ExecuteForList<ScreenDetailDynamicDialogLangDTO>(req);
        }
    }
}
