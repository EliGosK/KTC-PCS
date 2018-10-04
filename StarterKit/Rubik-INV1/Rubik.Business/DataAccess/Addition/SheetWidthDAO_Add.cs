using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;
using EVOFramework;
using Rubik.DTO;

namespace Rubik.DAO
{
    public partial class SheetWidthDAO
    {
        private readonly Database m_db;

        public SheetWidthDAO() { }

        public SheetWidthDAO(Database db)
        {
            this.m_db = db;
        }

        protected Database UseDatabase(Database specificDB)
        {
            if (specificDB != null)
                return specificDB;

            if (this.m_db != null)
                return this.m_db;

            throw new DataAccessException(ResourceBundle.ALL.S_CANNOT_USE_DB);
        }

        public void SaveColumnWidth(Database database, SheetWidthDTO objWidth)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(SheetWidthDTO));
            sb.AppendLine(" INSERT INTO TZ_SCREEN_SHEET_WIDTH_MS (SCREEN_CD,SHEET_ID,COL_INDEX,COL_WIDTH)");
            sb.AppendLine(" VALUES ");
            sb.AppendLine("  (@SCREEN_CD,@SHEET_ID,@COL_INDEX,@COL_WIDTH)");

            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@SCREEN_CD", DataType.VarChar, objWidth.SCREEN_CD.Value);
            req.Parameters.Add("@SHEET_ID", DataType.VarChar, objWidth.SHEET_ID.Value);
            req.Parameters.Add("@COL_INDEX", DataType.Int32, objWidth.COL_INDEX.Value);
            req.Parameters.Add("@COL_WIDTH", DataType.Decimal, objWidth.COL_WIDTH.Value);

            #endregion
            db.ExecuteNonQuery(req);
        }

        public void ClearColumnWidth(Database database, SheetWidthDTO objWidth)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(SheetWidthDTO));
            sb.AppendLine(" DELETE FROM TZ_SCREEN_SHEET_WIDTH_MS ");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  SCREEN_CD=@SCREEN_CD ");
            sb.AppendLine("  AND SHEET_ID=@SHEET_ID");

            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@SCREEN_CD", DataType.VarChar, objWidth.SCREEN_CD.Value);
            req.Parameters.Add("@SHEET_ID", DataType.VarChar, objWidth.SHEET_ID.Value);
            #endregion
            db.ExecuteNonQuery(req);
        }


        public List<SheetWidthDTO> LoadColumnWidth(Database database, SheetWidthDTO objWidth)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(SheetWidthDTO));
            sb.AppendLine(" SELECT SCREEN_CD, COL_INDEX ,COL_WIDTH FROM TZ_SCREEN_SHEET_WIDTH_MS ");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  SCREEN_CD=@SCREEN_CD ");
            sb.AppendLine("  AND SHEET_ID=@SHEET_ID ");

            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@SCREEN_CD", DataType.VarChar, objWidth.SCREEN_CD.Value);
            req.Parameters.Add("@SHEET_ID", DataType.VarChar, objWidth.SHEET_ID.Value);
            #endregion
            return db.ExecuteForList<SheetWidthDTO>(req);
        }
    }
}
