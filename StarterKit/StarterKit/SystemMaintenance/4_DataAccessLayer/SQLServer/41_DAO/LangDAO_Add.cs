using System.Text;
using EVOFramework.Database;

namespace SystemMaintenance.SQLServer.DAO
{
    partial class LangDAO
    {
        /// <summary>
        /// Load system default language.
        /// </summary>
        /// <param name="database">Alternative database connection.</param>
        /// <returns></returns>
        public string LoadSystemDefautLanguage(Database database) {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("   SELECT T_LANG.LANG_CD ");
            sb.AppendLine("   FROM (SELECT T.CHAR_DATA ");
            sb.AppendLine("       FROM TZ_SYS_CONFIG T ");
            sb.AppendLine("      WHERE T.SYS_GROUP_ID = 'ZZ' ");
            sb.AppendLine("        AND T.SYS_KEY = 'DEF_LANG') T_SYS ");
            sb.AppendLine("   INNER JOIN TZ_LANG_MS T_LANG ON T_SYS.CHAR_DATA = T_LANG.LANG_CD; ");

            Database db = UseDatabase(database);
            DataRequest req = new DataRequest(sb.ToString());
            object objLangCD = db.ExecuteScalar(req);
            if (objLangCD == null)
                return "en-EN";

            return objLangCD.ToString();
        }

        /// <summary>
        /// Load screen description by given language code.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="screenCD"></param>
        /// <param name="langCD"></param>
        /// <returns>Screen description.</returns>
        public string LoadScreenDescriptionByLangCD(Database database, string screenCD, string langCD)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("   SELECT T.SCREEN_DESC ");
            sb.AppendLine("   FROM TZ_SCREEN_LANG_MS T ");
            sb.AppendLine("   WHERE T.SCREEN_CD = :SCREEN_CD ");
            sb.AppendLine("     AND T.LANG_CD = :LANG_CD ");

            Database db = UseDatabase(database);
            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("SCREEN_CD", DataType.NVarChar, screenCD);
            req.Parameters.Add("LANG_CD", DataType.NVarChar, langCD);

            object objLangCD = db.ExecuteScalar(req);
            if (objLangCD == null)
                return string.Empty;

            return objLangCD.ToString();

        }
    }
}
