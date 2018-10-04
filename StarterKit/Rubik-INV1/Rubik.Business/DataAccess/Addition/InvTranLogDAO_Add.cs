using System;
using System.Collections.Generic;
using System.Text;
using Rubik.DTO;
using EVOFramework.Database;
using EVOFramework;
using System.Data;

namespace Rubik.DAO
{
    internal partial class InvTranLogDAO
    {
        #region Load Operation
        internal List<InvTranLogDTO> LoadAllInvTranLogPeriod(Database database, NZDateTime FromDate, NZDateTime ToDate, NZString ScreenType)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InvTranLogDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + InvTranLogDTO.eColumns.ID);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.OPERATION_TYPE);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.OPERATION_DATE);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.OPERATION_MACHINE);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.OPERATION_USER);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.TRANS_ID);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.LOT_NO);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.PACK_NO);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.EXTERNAL_LOT_NO);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.TRANS_DATE);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.TRANS_CLS);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.IN_OUT_CLS);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.QTY);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.WEIGHT);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.OBJ_ITEM_CD);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.OBJ_ORDER_QTY);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.REF_NO);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.REF_SLIP_NO);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.REF_SLIP_CLS);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.OTHER_DL_NO);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.SLIP_NO);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.REMARK);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.DEALING_NO);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.PRICE);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.AMOUNT);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.FOR_CUSTOMER);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.FOR_MACHINE);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.SHIFT_CLS);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.REF_SLIP_NO2);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.NG_QTY);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.NG_WEIGHT);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.TRAN_SUB_CLS);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.SCREEN_TYPE);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.GROUP_TRANS_ID);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.RESERVE_QTY);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.RETURN_QTY);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.NG_REASON);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.EFFECT_STOCK);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.LOT_REMARK);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.PERSON_IN_CHARGE);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.CURRENCY);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.REWORK_FLAG);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.FG_NO);
            sb.AppendLine("  ," + InvTranLogDTO.eColumns.OLD_DATA);

            sb.AppendLine(" FROM " + tableName);

            sb.AppendLine(" WHERE " + InvTranLogDTO.eColumns.OPERATION_DATE + " BETWEEN :FROMDATE AND :TODATE ");
            sb.AppendLine(" AND ((:SCREEN_TYPE IS NULL) OR (" + InvTranLogDTO.eColumns.SCREEN_TYPE + " = :SCREEN_TYPE)) ");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("FROMDATE", DataType.DateTime, FromDate.StrongValue.Date);
            req.Parameters.Add("TODATE", DataType.DateTime, ToDate.StrongValue.Date);
            req.Parameters.Add("SCREEN_TYPE", DataType.VarChar, ScreenType.Value);
            return db.ExecuteForList<InvTranLogDTO>(req);
        }

        public DataTable LoadLogData(Database database, LogInquiryCriteriaDTO criteria)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            sb.AppendLine(" SELECT * ");
            sb.AppendLine(" FROM " + criteria.TableName);
            sb.AppendLine(" WHERE " + InvTranLogDTO.eColumns.OPERATION_DATE + " BETWEEN :FROMDATE AND :TODATE ");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("FROMDATE", DataType.DateTime, criteria.FromDate.StrongValue.Date);
            req.Parameters.Add("TODATE", DataType.DateTime, criteria.ToDate.StrongValue.Date);
            DataSet ds = db.ExecuteDataSet(req);
            DataTable dt = null;

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }

            return dt;
        }

        public DataTable LoadLogTable(Database database)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            sb.AppendLine(" SELECT TABLE_NAME, TABLE_DESCRIPTION ");
            sb.AppendLine(" FROM TZ_LOG_TABLE_MS ");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());

            DataSet ds = db.ExecuteDataSet(req);
            DataTable dt = null;

            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }

            return dt;
        }

        #endregion
    }
}

