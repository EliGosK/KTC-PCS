/* Create by: Ms. Sansanee K.
 * Create on: 2011-06-08
 * Company: CSI Groups (Thailand)
 * Group: SI-EVO
 
 *** This generate source code was build for DAO on StarterKit system. ***/
using System;
using System.Collections.Generic;
using System.Text;
using EVOFramework.Database;
using EVOFramework;
using Rubik.DTO;
using Rubik.Data;
using System.Data;


namespace Rubik.DAO {
    internal partial class ProcessDAO {

        public ProcessDTO LoadLastProcess(Database database , string strPROCESS_TYPE) {

            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_COMMON_LoadLastProcess";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_PROCESS_TYPE", DataType.NVarChar, strPROCESS_TYPE);           

            List<ProcessDTO> list = db.ExecuteForList<ProcessDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }

        public int UpdateFinishProcess(Database database, ProcessDTO dto) {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_COMMON_UpdateFinishProcess";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_PROCESS_NO", DataType.NVarChar, dto.PROCESS_NO.Value);  
            req.Parameters.Add("@pVar_STATUS", DataType.NVarChar, dto.STATUS.Value);
            req.Parameters.Add("@pDtm_END_PRCS_TIME", DataType.DateTime, dto.END_PRCS_TIME.IsNull ? (object)DBNull.Value : dto.END_PRCS_TIME.Value);
            req.Parameters.Add("@pVar_PROCESS_BY", DataType.NVarChar, dto.PROCESS_BY.Value);
            req.Parameters.Add("@pVar_PROCESS_MACHINE", DataType.NVarChar, dto.PROCESS_MACHINE.Value);

            return db.ExecuteNonQuery(req);

        }

        public int SimulateMRP(Database database, string strMRP_NO, GenerateMRPDTO dto) {

            Database db = UseDatabase(database);

            DataRequest req = new DataRequest();
            req.CommandText = "S_MRP010_SimulateMRP";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_MRP_NO", DataType.NVarChar, strMRP_NO);
            req.Parameters.Add("@pDtm_START_DATE", DataType.DateTime, dto.START_DATE.Value);
            req.Parameters.Add("@pINT_RECOVER_DURATION", DataType.Int32, dto.RECOVER_DURATION.Value);
            if (dto.ITEM_FLAG) {
                req.Parameters.Add("@pVar_ITEM_CD_FROM", DataType.NVarChar, dto.ITEM_CD_FROM.Value);
                req.Parameters.Add("@pVar_ITEM_CD_TO", DataType.NVarChar, dto.ITEM_CD_TO.Value);
            }
            req.Parameters.Add("@pVar_USER_CD", DataType.NVarChar, dto.USER_CD.Value);
            req.Parameters.Add("@pVar_MACHINE", DataType.NVarChar, dto.MACHINE.Value);

            return db.ExecuteNonQuery(req);

        }
    }
}

