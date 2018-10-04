using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkFlowDiagram.DTO;
using System.Data;
using EVOFramework.Database;

namespace WorkFlowDiagram.DAO
{
    internal class LineDetailDAO
    {
        public List<LineDetailDTO> GetLineDetails(Database db, string WF_ID, string ID) {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine(" SELECT ");
            //sb.AppendLine("   DTL.WF_ID ");
            //sb.AppendLine("   ,DTL.ID ");
            //sb.AppendLine("   ,DTL.SEQ ");
            //sb.AppendLine("   ,DTL.FROM_ROW ");
            //sb.AppendLine("   ,DTL.FROM_COL ");
            //sb.AppendLine("   ,DTL.TO_ROW ");
            //sb.AppendLine("   ,DTL.TO_COL ");
            //sb.AppendLine("   ,DTL.STATUS ");
            //sb.AppendLine(" FROM WF_LINE_DTL DTL ");
            //sb.AppendLine(" WHERE DTL.WF_ID = :WF_ID AND ID = :ID");
            //sb.AppendLine(" START WITH DTL.WF_ID = :WF_ID ");
            //sb.AppendLine(" CONNECT BY  ");
            //sb.AppendLine("         DTL.TO_ROW = DTL.FROM_ROW  ");
            //sb.AppendLine("         AND DTL.TO_COL = DTL.FROM_COL       ");
            //sb.AppendLine(" ORDER SIBLINGS BY DTL.SEQ ");

            sb.AppendLine(" SELECT ");
            sb.AppendLine("   DTL.WF_ID ");
            sb.AppendLine("   ,DTL.ID ");
            sb.AppendLine("   ,DTL.SEQ ");
            sb.AppendLine("   ,DTL.FROM_ROW ");
            sb.AppendLine("   ,DTL.FROM_COL ");
            sb.AppendLine("   ,DTL.TO_ROW ");
            sb.AppendLine("   ,DTL.TO_COL ");
            sb.AppendLine("   ,DTL.STATUS ");
            sb.AppendLine(" FROM WF_LINE_DTL DTL ");
            sb.AppendLine(" WHERE DTL.WF_ID = :WF_ID");
            sb.AppendLine(" ORDER BY DTL.SEQ");
            

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("WF_ID", DataType.NVarChar, WF_ID);
            //req.Parameters.Add("ID", DataType.NVarChar, ID);

            DataTable dt = db.ExecuteQuery(req);

            List<LineDetailDTO> list = MappingLineHeaderDTO(dt);
            return list;
        }

        public static List<LineDetailDTO> MappingLineHeaderDTO(DataTable dt)
        {
            List<LineDetailDTO> list = new List<LineDetailDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LineDetailDTO dto = new LineDetailDTO();
                dto.WF_ID = Convert.ToString(dt.Rows[i]["WF_ID"]);
                dto.ID = Convert.ToString(dt.Rows[i]["ID"]);
                dto.SEQ = Convert.ToInt32(dt.Rows[i]["SEQ"]);
                dto.FROM_ROW = Convert.ToInt32(dt.Rows[i]["FROM_ROW"]);
                dto.FROM_COL = Convert.ToInt32(dt.Rows[i]["FROM_COL"]);
                dto.TO_ROW = Convert.ToInt32(dt.Rows[i]["TO_ROW"]);
                dto.TO_COL = Convert.ToInt32(dt.Rows[i]["TO_COL"]);
                dto.STATUS = Convert.ToInt32(dt.Rows[i]["STATUS"]);
                

                list.Add(dto);
            }

            return list;
        }
    }
}
