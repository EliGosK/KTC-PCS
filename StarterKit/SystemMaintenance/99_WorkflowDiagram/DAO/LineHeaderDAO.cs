using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkFlowDiagram.DTO;
using EVOFramework.Database;
using System.Data;

namespace WorkFlowDiagram.DAO
{
    internal class LineHeaderDAO
    {
        public List<LineHeaderDTO> GetLineHeaders(Database db, string WF_ID) {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT ");
            sb.AppendLine("     T.WF_ID");
            sb.AppendLine("     ,T.ID");
            sb.AppendLine("     ,T.ZINDEX");
            sb.AppendLine("     ,T.REMARK");            
            sb.AppendLine(" FROM WF_LINE_HED T");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("     T.WF_ID = :WF_ID");
            sb.AppendLine(" ORDER BY T.ZINDEX");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("WF_ID", DataType.NVarChar, WF_ID);
            

            DataTable dt = db.ExecuteQuery(req);
            List<LineHeaderDTO> list = MappingLineHeaderDTO(dt);
            return list;            
        }

        public static List<LineHeaderDTO> MappingLineHeaderDTO(DataTable dt) {
            List<LineHeaderDTO> list = new List<LineHeaderDTO>();
            for (int i=0; i<dt.Rows.Count; i++) {
                LineHeaderDTO dto = new LineHeaderDTO();
                dto.WF_ID = Convert.ToString(dt.Rows[i]["WF_ID"]);
                dto.ID = Convert.ToString(dt.Rows[i]["ID"]);
                dto.ZINDEX = Convert.ToInt32(dt.Rows[i]["ZINDEX"]);
                dto.REMARK = (dt.Rows[i]["REMARK"] == null) ? "" : Convert.ToString(dt.Rows[i]["REMARK"]);

                list.Add(dto);
            }

            return list;
        }
    }
}
