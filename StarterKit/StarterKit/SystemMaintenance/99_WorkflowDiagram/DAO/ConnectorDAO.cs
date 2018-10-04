using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;
using WorkFlowDiagram.DTO;
using System.Data;

namespace WorkFlowDiagram.DAO
{
    internal class ConnectorDAO
    {
        public List<ConnectorDTO> GetConnectors(Database db, string WF_ID, string LINE_ID) {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT ");
            sb.AppendLine("   T.WF_ID ");
            sb.AppendLine("   ,T.LINE_ID ");
            sb.AppendLine("   ,T.ROW_INDEX ");
            sb.AppendLine("   ,T.COL_INDEX ");
            sb.AppendLine("   ,T.STATUS ");
            sb.AppendLine(" FROM WF_CONNECTOR T ");
            sb.AppendLine(" WHERE  ");
            sb.AppendLine("   T.WF_ID = :WF_ID ");
            sb.AppendLine("   AND T.LINE_ID = :LINE_ID ");

            DataRequest req =new DataRequest(sb.ToString());
            req.Parameters.Add("WF_ID", DataType.NVarChar, WF_ID);
            req.Parameters.Add("LINE_ID", DataType.NVarChar, LINE_ID);

            DataTable dt = db.ExecuteQuery(req);
            List<ConnectorDTO> list = MappingConnectorDTO(dt);
            return list;
        }

        public static List<ConnectorDTO> MappingConnectorDTO(DataTable dt) {
            List<ConnectorDTO> list = new List<ConnectorDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ConnectorDTO dto = new ConnectorDTO();
                dto.WF_ID = Convert.ToString(dt.Rows[i]["WF_ID"]);
                dto.LINE_ID = Convert.ToString(dt.Rows[i]["LINE_ID"]);                
                dto.ROW_INDEX = Convert.ToInt32(dt.Rows[i]["ROW_INDEX"]);
                dto.COL_INDEX = Convert.ToInt32(dt.Rows[i]["COL_INDEX"]);
                dto.STATUS = Convert.ToInt32(dt.Rows[i]["STATUS"]);                

                list.Add(dto);
            }

            return list;
        }
    }
}
