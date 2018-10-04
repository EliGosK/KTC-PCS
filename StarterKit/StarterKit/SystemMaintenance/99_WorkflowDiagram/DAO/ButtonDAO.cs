using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;
using System.Data;
using WorkFlowDiagram.DTO;
using System.Collections;
using EVOFramework.Data;

namespace WorkFlowDiagram.DAO
{
    internal class ButtonDAO
    {
        #region "  Public method  "
        public List<ButtonDTO> FindButton(Database db, string WF_ID, string USER_ACCOUNT, bool autoArrangeIcon, int iconPerRow)
        {
            StringBuilder sb = new StringBuilder();

            //ถ้าไม่ auto arrange ก็วาดตามที่ db เก็บ
            // แต่ถ้า auto arrange จะวาดตามจำนวน column ที่กำหนด
            if (autoArrangeIcon == false)
            {
                sb.AppendLine(" SELECT ");
                sb.AppendLine("     T.WF_ID");
                sb.AppendLine("     ,T.ROW_INDEX");
                sb.AppendLine("     ,T.COL_INDEX");
                sb.AppendLine("     ,T.TAG1");
                sb.AppendLine("     ,T.TAG2");
                sb.AppendLine("     ,T.CREATEDATE");
                sb.AppendLine("     ,T.UPDATEDATE");
                sb.AppendLine("     ,pmGroup.FLG_VIEW ");
                sb.AppendLine(" FROM WF_BUTTON T");
                sb.AppendLine(" INNER JOIN TZ_GROUP_SCREEN_PERMISSION_MS pmGroup on T.TAG1=pmGroup.SCREEN_CD");
                sb.AppendLine(" INNER JOIN TZ_USER_MS usr on pmGroup.GROUP_CD=usr.GROUP_CD");
                sb.AppendLine(" WHERE ");
                sb.AppendLine("     T.WF_ID = :WF_ID");
                sb.AppendLine("     AND USR.USER_ACCOUNT = :I_USER_ACCOUNT");
                sb.AppendLine(" ORDER BY T.WF_ID,T.ROW_INDEX, T.COL_INDEX");
            }
            else if (autoArrangeIcon == true)
            {
                sb.AppendLine("  SELECT  ");
                sb.AppendLine("      T.WF_ID ");
                sb.AppendLine(string.Format("      ,((ROW_NUMBER() OVER(ORDER BY T.ROW_INDEX, T.COL_INDEX) -1 ) / {0} ) as ROW_INDEX ", iconPerRow.ToString()));
                sb.AppendLine(string.Format("      ,((ROW_NUMBER() OVER(ORDER BY T.ROW_INDEX, T.COL_INDEX) -1 ) % {0} ) + 1 as COL_INDEX ", iconPerRow.ToString()));
                sb.AppendLine("      ,T.TAG1 ");
                sb.AppendLine("      ,T.TAG2 ");
                sb.AppendLine("      ,T.CREATEDATE ");
                sb.AppendLine("      ,T.UPDATEDATE ");
                sb.AppendLine("      ,pmGroup.FLG_VIEW ");
                sb.AppendLine("  FROM WF_BUTTON T ");
                sb.AppendLine("  INNER JOIN TZ_GROUP_SCREEN_PERMISSION_MS pmGroup on T.TAG1=pmGroup.SCREEN_CD ");
                sb.AppendLine("  INNER JOIN TZ_USER_MS usr on pmGroup.GROUP_CD=usr.GROUP_CD ");
                sb.AppendLine("  WHERE  ");
                sb.AppendLine("      T.WF_ID = :WF_ID ");
                sb.AppendLine("      AND USR.USER_ACCOUNT = :I_USER_ACCOUNT ");
                sb.AppendLine("      AND pmGroup.FLG_VIEW = 1 ");
                sb.AppendLine("  ORDER BY T.WF_ID,T.ROW_INDEX, T.COL_INDEX ");

            }


            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("WF_ID", DataType.NVarChar, WF_ID);
            req.Parameters.Add("I_USER_ACCOUNT", DataType.VarChar, USER_ACCOUNT);

            DataTable dt = db.ExecuteQuery(req);



            List<ButtonDTO> list = MappingButtonDTO(dt);
            return list;
        }
        #endregion

        #region "  Mapping  "
        public static List<ButtonDTO> MappingButtonDTO(DataTable dt)
        {
            List<ButtonDTO> list = new List<ButtonDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ButtonDTO dto = new ButtonDTO();
                dto.WF_ID = Convert.ToString(dt.Rows[i]["WF_ID"]);
                dto.ROW_INDEX = Convert.ToInt32(dt.Rows[i]["ROW_INDEX"]);
                dto.COL_INDEX = Convert.ToInt32(dt.Rows[i]["COL_INDEX"]);
                dto.TAG1 = Convert.ToString(dt.Rows[i]["TAG1"]);
                dto.TAG2 = Convert.ToString(dt.Rows[i]["TAG2"]);
                dto.CREATEDATE = Convert.ToDateTime(dt.Rows[i]["CREATEDATE"]);
                dto.UPDATEDATE = Convert.ToDateTime(dt.Rows[i]["UPDATEDATE"]);
                dto.FLG_VIEW = Convert.ToInt32(dt.Rows[i]["FLG_VIEW"]);

                list.Add(dto);
            }

            return list;
        }
        #endregion
    }
}
