/* Create by: Ms. Sansanee K.
 * Create on: 2012-03-02
 * Company: CSI Groups (Thailand)
 * Group: SI-EVO
 
 *** This generate source code was build for DAO on StarterKit system. ***/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using EVOFramework.Database;
using Rubik.DTO;

namespace Rubik.DAO
{
    internal partial class InventoryTransactionDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public InventoryTransactionDAO() { }

        public InventoryTransactionDAO(Database db)
        {
            this.m_db = db;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get encapsulated database object.
        /// </summary>
        public Database CurrentDatabase
        {
            get { return m_db; }
        }
        #endregion

        #region Protected Method
        /// <summary>
        /// Determine to choose current database connection.
        /// </summary>
        /// <param name="specificDB"></param>
        /// <exception cref="DataAccessException">Cannot determine to use database.</exception>
        /// <returns></returns>
        protected Database UseDatabase(Database specificDB)
        {
            if (specificDB != null)
                return specificDB;

            if (this.m_db != null)
                return this.m_db;

            throw new DataAccessException(ResourceBundle.ALL.S_CANNOT_USE_DB);
        }
        #endregion

        #region Basic Operation
        /// <summary>
        /// Check exist before manipulate data. If found record will update data. Otherwise insert new data.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNewOrUpdate(Database database, InventoryTransactionDTO data)
        {
            Database db = UseDatabase(database);

            if (Exist(database, data.TRANS_ID))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, InventoryTransactionDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + InventoryTransactionDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_ID);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOT_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.FG_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.PACK_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.EXTERNAL_LOT_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_DATE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.IN_OUT_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.QTY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.WEIGHT);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OBJ_ITEM_CD);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OBJ_ORDER_QTY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OTHER_DL_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.SLIP_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REMARK);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.DEALING_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.PRICE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.AMOUNT);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.FOR_CUSTOMER);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.FOR_MACHINE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.SHIFT_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_NO2);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.NG_QTY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.NG_WEIGHT);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRAN_SUB_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.SCREEN_TYPE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.GROUP_TRANS_ID);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.RESERVE_QTY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.RETURN_QTY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.NG_REASON);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.EFFECT_STOCK);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOT_REMARK);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.PERSON_IN_CHARGE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.CURRENCY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REWORK_FLAG);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OLD_DATA);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TIME_STAMP);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   @CRT_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,@CRT_MACHINE");
            sb.AppendLine("   ,@UPD_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,@UPD_MACHINE");
            sb.AppendLine("   ,@TRANS_ID");
            sb.AppendLine("   ,@ITEM_CD");
            sb.AppendLine("   ,@LOC_CD");
            sb.AppendLine("   ,@LOT_NO");
            sb.AppendLine("   ,@FG_NO");
            sb.AppendLine("   ,@PACK_NO");
            sb.AppendLine("   ,@EXTERNAL_LOT_NO");
            sb.AppendLine("   ,@TRANS_DATE");
            sb.AppendLine("   ,@TRANS_CLS");
            sb.AppendLine("   ,@IN_OUT_CLS");
            sb.AppendLine("   ,@QTY");
            sb.AppendLine("   ,@WEIGHT");
            sb.AppendLine("   ,@OBJ_ITEM_CD");
            sb.AppendLine("   ,@OBJ_ORDER_QTY");
            sb.AppendLine("   ,@REF_NO");
            sb.AppendLine("   ,@REF_SLIP_NO");
            sb.AppendLine("   ,@REF_SLIP_CLS");
            sb.AppendLine("   ,@OTHER_DL_NO");
            sb.AppendLine("   ,@SLIP_NO");
            sb.AppendLine("   ,@REMARK");
            sb.AppendLine("   ,@DEALING_NO");
            sb.AppendLine("   ,@PRICE");
            sb.AppendLine("   ,@AMOUNT");
            sb.AppendLine("   ,@FOR_CUSTOMER");
            sb.AppendLine("   ,@FOR_MACHINE");
            sb.AppendLine("   ,@SHIFT_CLS");
            sb.AppendLine("   ,@REF_SLIP_NO2");
            sb.AppendLine("   ,@NG_QTY");
            sb.AppendLine("   ,@NG_WEIGHT");
            sb.AppendLine("   ,@TRAN_SUB_CLS");
            sb.AppendLine("   ,@SCREEN_TYPE");
            sb.AppendLine("   ,@GROUP_TRANS_ID");
            sb.AppendLine("   ,@RESERVE_QTY");
            sb.AppendLine("   ,@RETURN_QTY");
            sb.AppendLine("   ,@NG_REASON");
            sb.AppendLine("   ,@EFFECT_STOCK");
            sb.AppendLine("   ,@LOT_REMARK");
            sb.AppendLine("   ,@PERSON_IN_CHARGE");
            sb.AppendLine("   ,@CURRENCY");
            sb.AppendLine("   ,@REWORK_FLAG");
            sb.AppendLine("   ,@OLD_DATA");
            sb.AppendLine("   ,@TIME_STAMP");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@CRT_BY", DataType.NVarChar, data.CRT_BY.Value);
            req.Parameters.Add("@CRT_MACHINE", DataType.NVarChar, data.CRT_MACHINE.Value);
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@TRANS_ID", DataType.NVarChar, data.TRANS_ID.Value);
            req.Parameters.Add("@ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("@LOC_CD", DataType.NVarChar, data.LOC_CD.Value);
            req.Parameters.Add("@LOT_NO", DataType.NVarChar, data.LOT_NO.Value);
            req.Parameters.Add("@FG_NO", DataType.NVarChar, data.FG_NO.Value);
            req.Parameters.Add("@PACK_NO", DataType.NVarChar, data.PACK_NO.Value);
            req.Parameters.Add("@EXTERNAL_LOT_NO", DataType.NVarChar, data.EXTERNAL_LOT_NO.Value);
            req.Parameters.Add("@TRANS_DATE", DataType.DateTime, data.TRANS_DATE.StrongValue.Date);
            req.Parameters.Add("@TRANS_CLS", DataType.NVarChar, data.TRANS_CLS.Value);
            req.Parameters.Add("@IN_OUT_CLS", DataType.NVarChar, data.IN_OUT_CLS.Value);
            req.Parameters.Add("@QTY", DataType.Number, data.QTY.Value);
            req.Parameters.Add("@WEIGHT", DataType.Number, data.WEIGHT.Value);
            req.Parameters.Add("@OBJ_ITEM_CD", DataType.NVarChar, data.OBJ_ITEM_CD.Value);
            req.Parameters.Add("@OBJ_ORDER_QTY", DataType.Number, data.OBJ_ORDER_QTY.Value);
            req.Parameters.Add("@REF_NO", DataType.NVarChar, data.REF_NO.Value);
            req.Parameters.Add("@REF_SLIP_NO", DataType.NVarChar, data.REF_SLIP_NO.Value);
            req.Parameters.Add("@REF_SLIP_CLS", DataType.NVarChar, data.REF_SLIP_CLS.Value);
            req.Parameters.Add("@OTHER_DL_NO", DataType.NVarChar, data.OTHER_DL_NO.Value);
            req.Parameters.Add("@SLIP_NO", DataType.NVarChar, data.SLIP_NO.Value);
            req.Parameters.Add("@REMARK", DataType.NVarChar, data.REMARK.Value);
            req.Parameters.Add("@DEALING_NO", DataType.NVarChar, data.DEALING_NO.Value);
            req.Parameters.Add("@PRICE", DataType.Number, data.PRICE.Value);
            req.Parameters.Add("@AMOUNT", DataType.Number, data.AMOUNT.Value);
            req.Parameters.Add("@FOR_CUSTOMER", DataType.NVarChar, data.FOR_CUSTOMER.Value);
            req.Parameters.Add("@FOR_MACHINE", DataType.NVarChar, data.FOR_MACHINE.Value);
            req.Parameters.Add("@SHIFT_CLS", DataType.NVarChar, data.SHIFT_CLS.Value);
            req.Parameters.Add("@REF_SLIP_NO2", DataType.NVarChar, data.REF_SLIP_NO2.Value);
            req.Parameters.Add("@NG_QTY", DataType.Number, data.NG_QTY.Value);
            req.Parameters.Add("@NG_WEIGHT", DataType.Number, data.NG_WEIGHT.Value);
            req.Parameters.Add("@TRAN_SUB_CLS", DataType.NVarChar, data.TRAN_SUB_CLS.Value);
            req.Parameters.Add("@SCREEN_TYPE", DataType.NVarChar, data.SCREEN_TYPE.Value);
            req.Parameters.Add("@GROUP_TRANS_ID", DataType.NVarChar, data.GROUP_TRANS_ID.Value);
            req.Parameters.Add("@RESERVE_QTY", DataType.Number, data.RESERVE_QTY.Value);
            req.Parameters.Add("@RETURN_QTY", DataType.Number, data.RETURN_QTY.Value);
            req.Parameters.Add("@NG_REASON", DataType.NVarChar, data.NG_REASON.Value);
            req.Parameters.Add("@EFFECT_STOCK", DataType.Default, data.EFFECT_STOCK.Value);
            req.Parameters.Add("@LOT_REMARK", DataType.NVarChar, data.LOT_REMARK.Value);
            req.Parameters.Add("@PERSON_IN_CHARGE", DataType.NVarChar, data.PERSON_IN_CHARGE.Value);
            req.Parameters.Add("@CURRENCY", DataType.NVarChar, data.CURRENCY.Value);
            req.Parameters.Add("@REWORK_FLAG", DataType.Int32, data.REWORK_FLAG.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, 0);
            req.Parameters.Add("@TIME_STAMP", DataType.Default, data.TIME_STAMP.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using primary key value on the given data variable
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data with primary key value.</param>
        /// <returns></returns>
        public int UpdateWithoutPK(Database database, InventoryTransactionDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + InventoryTransactionDTO.eColumns.UPD_BY + "=@UPD_BY");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_MACHINE + "=@UPD_MACHINE");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOC_CD + "=@LOC_CD");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOT_NO + "=@LOT_NO");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.FG_NO + "=@FG_NO");            
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.PACK_NO + "=@PACK_NO");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.EXTERNAL_LOT_NO + "=@EXTERNAL_LOT_NO");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_DATE + "=@TRANS_DATE");
            //sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_CLS + "=@TRANS_CLS");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.IN_OUT_CLS + "=@IN_OUT_CLS");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.QTY + "=@QTY");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.WEIGHT + "=@WEIGHT");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OBJ_ITEM_CD + "=@OBJ_ITEM_CD");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OBJ_ORDER_QTY + "=@OBJ_ORDER_QTY");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_NO + "=@REF_NO");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_NO + "=@REF_SLIP_NO");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_CLS + "=@REF_SLIP_CLS");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OTHER_DL_NO + "=@OTHER_DL_NO");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.SLIP_NO + "=@SLIP_NO");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REMARK + "=@REMARK");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.DEALING_NO + "=@DEALING_NO");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.PRICE + "=@PRICE");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.AMOUNT + "=@AMOUNT");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.FOR_CUSTOMER + "=@FOR_CUSTOMER");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.FOR_MACHINE + "=@FOR_MACHINE");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.SHIFT_CLS + "=@SHIFT_CLS");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_NO2 + "=@REF_SLIP_NO2");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.NG_QTY + "=@NG_QTY");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.NG_WEIGHT + "=@NG_WEIGHT");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRAN_SUB_CLS + "=@TRAN_SUB_CLS");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.SCREEN_TYPE + "=@SCREEN_TYPE");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.GROUP_TRANS_ID + "=@GROUP_TRANS_ID");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.RESERVE_QTY + "=@RESERVE_QTY");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.RETURN_QTY + "=@RETURN_QTY");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.NG_REASON + "=@NG_REASON");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.EFFECT_STOCK + "=@EFFECT_STOCK");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOT_REMARK + "=@LOT_REMARK");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.PERSON_IN_CHARGE + "=@PERSON_IN_CHARGE");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.CURRENCY + "=@CURRENCY");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REWORK_FLAG + "=@REWORK_FLAG");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OLD_DATA + "=@OLD_DATA");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TIME_STAMP + "=@TIME_STAMP");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InventoryTransactionDTO.eColumns.TRANS_ID + "=@TRANS_ID");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@TRANS_ID", DataType.NVarChar, data.TRANS_ID.Value);
            req.Parameters.Add("@ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("@LOC_CD", DataType.NVarChar, data.LOC_CD.Value);
            req.Parameters.Add("@LOT_NO", DataType.NVarChar, data.LOT_NO.Value);
            req.Parameters.Add("@FG_NO", DataType.NVarChar, data.FG_NO.Value);
            req.Parameters.Add("@PACK_NO", DataType.NVarChar, data.PACK_NO.Value);
            req.Parameters.Add("@EXTERNAL_LOT_NO", DataType.NVarChar, data.EXTERNAL_LOT_NO.Value);
            req.Parameters.Add("@TRANS_DATE", DataType.DateTime, data.TRANS_DATE.Value);
            //req.Parameters.Add("@TRANS_CLS", DataType.NVarChar, data.TRANS_CLS.Value);
            req.Parameters.Add("@IN_OUT_CLS", DataType.NVarChar, data.IN_OUT_CLS.Value);
            req.Parameters.Add("@QTY", DataType.Number, data.QTY.Value);
            req.Parameters.Add("@WEIGHT", DataType.Number, data.WEIGHT.Value);
            req.Parameters.Add("@OBJ_ITEM_CD", DataType.NVarChar, data.OBJ_ITEM_CD.Value);
            req.Parameters.Add("@OBJ_ORDER_QTY", DataType.Number, data.OBJ_ORDER_QTY.Value);
            req.Parameters.Add("@REF_NO", DataType.NVarChar, data.REF_NO.Value);
            req.Parameters.Add("@REF_SLIP_NO", DataType.NVarChar, data.REF_SLIP_NO.Value);
            req.Parameters.Add("@REF_SLIP_CLS", DataType.NVarChar, data.REF_SLIP_CLS.Value);
            req.Parameters.Add("@OTHER_DL_NO", DataType.NVarChar, data.OTHER_DL_NO.Value);
            req.Parameters.Add("@SLIP_NO", DataType.NVarChar, data.SLIP_NO.Value);
            req.Parameters.Add("@REMARK", DataType.NVarChar, data.REMARK.Value);
            req.Parameters.Add("@DEALING_NO", DataType.NVarChar, data.DEALING_NO.Value);
            req.Parameters.Add("@PRICE", DataType.Number, data.PRICE.Value);
            req.Parameters.Add("@AMOUNT", DataType.Number, data.AMOUNT.Value);
            req.Parameters.Add("@FOR_CUSTOMER", DataType.NVarChar, data.FOR_CUSTOMER.Value);
            req.Parameters.Add("@FOR_MACHINE", DataType.NVarChar, data.FOR_MACHINE.Value);
            req.Parameters.Add("@SHIFT_CLS", DataType.NVarChar, data.SHIFT_CLS.Value);
            req.Parameters.Add("@REF_SLIP_NO2", DataType.NVarChar, data.REF_SLIP_NO2.Value);
            req.Parameters.Add("@NG_QTY", DataType.Number, data.NG_QTY.Value);
            req.Parameters.Add("@NG_WEIGHT", DataType.Number, data.NG_WEIGHT.Value);
            req.Parameters.Add("@TRAN_SUB_CLS", DataType.NVarChar, data.TRAN_SUB_CLS.Value);
            req.Parameters.Add("@SCREEN_TYPE", DataType.NVarChar, data.SCREEN_TYPE.Value);
            req.Parameters.Add("@GROUP_TRANS_ID", DataType.NVarChar, data.GROUP_TRANS_ID.Value);
            req.Parameters.Add("@RESERVE_QTY", DataType.Number, data.RESERVE_QTY.Value);
            req.Parameters.Add("@RETURN_QTY", DataType.Number, data.RETURN_QTY.Value);
            req.Parameters.Add("@NG_REASON", DataType.NVarChar, data.NG_REASON.Value);
            req.Parameters.Add("@EFFECT_STOCK", DataType.Default, data.EFFECT_STOCK.Value);
            req.Parameters.Add("@LOT_REMARK", DataType.NVarChar, data.LOT_REMARK.Value);
            req.Parameters.Add("@PERSON_IN_CHARGE", DataType.NVarChar, data.PERSON_IN_CHARGE.Value);
            req.Parameters.Add("@CURRENCY", DataType.NVarChar, data.CURRENCY.Value);
            req.Parameters.Add("@REWORK_FLAG", DataType.Int32, data.REWORK_FLAG.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, 0);
            req.Parameters.Add("@TIME_STAMP", DataType.Default, data.TIME_STAMP.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldTRANS_ID">Old Key #1</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, InventoryTransactionDTO data, String oldTRANS_ID)
        {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + InventoryTransactionDTO.eColumns.UPD_BY + "=@UPD_BY");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_MACHINE + "=@UPD_MACHINE");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_ID + "=@TRANS_ID");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOC_CD + "=@LOC_CD");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOT_NO + "=@LOT_NO");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.FG_NO + "=@FG_NO");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.PACK_NO + "=@PACK_NO");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.EXTERNAL_LOT_NO + "=@EXTERNAL_LOT_NO");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_DATE + "=@TRANS_DATE");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_CLS + "=@TRANS_CLS");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.IN_OUT_CLS + "=@IN_OUT_CLS");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.QTY + "=@QTY");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.WEIGHT + "=@WEIGHT");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OBJ_ITEM_CD + "=@OBJ_ITEM_CD");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OBJ_ORDER_QTY + "=@OBJ_ORDER_QTY");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_NO + "=@REF_NO");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_NO + "=@REF_SLIP_NO");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_CLS + "=@REF_SLIP_CLS");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OTHER_DL_NO + "=@OTHER_DL_NO");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.SLIP_NO + "=@SLIP_NO");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REMARK + "=@REMARK");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.DEALING_NO + "=@DEALING_NO");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.PRICE + "=@PRICE");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.AMOUNT + "=@AMOUNT");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.FOR_CUSTOMER + "=@FOR_CUSTOMER");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.FOR_MACHINE + "=@FOR_MACHINE");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.SHIFT_CLS + "=@SHIFT_CLS");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_NO2 + "=@REF_SLIP_NO2");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.NG_QTY + "=@NG_QTY");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.NG_WEIGHT + "=@NG_WEIGHT");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRAN_SUB_CLS + "=@TRAN_SUB_CLS");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.SCREEN_TYPE + "=@SCREEN_TYPE");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.GROUP_TRANS_ID + "=@GROUP_TRANS_ID");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.RESERVE_QTY + "=@RESERVE_QTY");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.RETURN_QTY + "=@RETURN_QTY");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.NG_REASON + "=@NG_REASON");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.EFFECT_STOCK + "=@EFFECT_STOCK");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOT_REMARK + "=@LOT_REMARK");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.PERSON_IN_CHARGE + "=@PERSON_IN_CHARGE");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.CURRENCY + "=@CURRENCY");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REWORK_FLAG + "=@REWORK_FLAG");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OLD_DATA + "=@OLD_DATA");
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TIME_STAMP + "=@TIME_STAMP");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InventoryTransactionDTO.eColumns.TRANS_ID + "=@oldTRANS_ID");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@TRANS_ID", DataType.NVarChar, data.TRANS_ID.Value);
            req.Parameters.Add("@ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("@LOC_CD", DataType.NVarChar, data.LOC_CD.Value);
            req.Parameters.Add("@LOT_NO", DataType.NVarChar, data.LOT_NO.Value);
            req.Parameters.Add("@FG_NO", DataType.NVarChar, data.FG_NO.Value);
            req.Parameters.Add("@PACK_NO", DataType.NVarChar, data.PACK_NO.Value);
            req.Parameters.Add("@EXTERNAL_LOT_NO", DataType.NVarChar, data.EXTERNAL_LOT_NO.Value);
            req.Parameters.Add("@TRANS_DATE", DataType.DateTime, data.TRANS_DATE.Value);
            req.Parameters.Add("@TRANS_CLS", DataType.NVarChar, data.TRANS_CLS.Value);
            req.Parameters.Add("@IN_OUT_CLS", DataType.NVarChar, data.IN_OUT_CLS.Value);
            req.Parameters.Add("@QTY", DataType.Number, data.QTY.Value);
            req.Parameters.Add("@WEIGHT", DataType.Number, data.WEIGHT.Value);
            req.Parameters.Add("@OBJ_ITEM_CD", DataType.NVarChar, data.OBJ_ITEM_CD.Value);
            req.Parameters.Add("@OBJ_ORDER_QTY", DataType.Number, data.OBJ_ORDER_QTY.Value);
            req.Parameters.Add("@REF_NO", DataType.NVarChar, data.REF_NO.Value);
            req.Parameters.Add("@REF_SLIP_NO", DataType.NVarChar, data.REF_SLIP_NO.Value);
            req.Parameters.Add("@REF_SLIP_CLS", DataType.NVarChar, data.REF_SLIP_CLS.Value);
            req.Parameters.Add("@OTHER_DL_NO", DataType.NVarChar, data.OTHER_DL_NO.Value);
            req.Parameters.Add("@SLIP_NO", DataType.NVarChar, data.SLIP_NO.Value);
            req.Parameters.Add("@REMARK", DataType.NVarChar, data.REMARK.Value);
            req.Parameters.Add("@DEALING_NO", DataType.NVarChar, data.DEALING_NO.Value);
            req.Parameters.Add("@PRICE", DataType.Number, data.PRICE.Value);
            req.Parameters.Add("@AMOUNT", DataType.Number, data.AMOUNT.Value);
            req.Parameters.Add("@FOR_CUSTOMER", DataType.NVarChar, data.FOR_CUSTOMER.Value);
            req.Parameters.Add("@FOR_MACHINE", DataType.NVarChar, data.FOR_MACHINE.Value);
            req.Parameters.Add("@SHIFT_CLS", DataType.NVarChar, data.SHIFT_CLS.Value);
            req.Parameters.Add("@REF_SLIP_NO2", DataType.NVarChar, data.REF_SLIP_NO2.Value);
            req.Parameters.Add("@NG_QTY", DataType.Number, data.NG_QTY.Value);
            req.Parameters.Add("@NG_WEIGHT", DataType.Number, data.NG_WEIGHT.Value);
            req.Parameters.Add("@TRAN_SUB_CLS", DataType.NVarChar, data.TRAN_SUB_CLS.Value);
            req.Parameters.Add("@SCREEN_TYPE", DataType.NVarChar, data.SCREEN_TYPE.Value);
            req.Parameters.Add("@GROUP_TRANS_ID", DataType.NVarChar, data.GROUP_TRANS_ID.Value);
            req.Parameters.Add("@RESERVE_QTY", DataType.Number, data.RESERVE_QTY.Value);
            req.Parameters.Add("@RETURN_QTY", DataType.Number, data.RETURN_QTY.Value);
            req.Parameters.Add("@NG_REASON", DataType.NVarChar, data.NG_REASON.Value);
            req.Parameters.Add("@EFFECT_STOCK", DataType.Default, data.EFFECT_STOCK.Value);
            req.Parameters.Add("@LOT_REMARK", DataType.NVarChar, data.LOT_REMARK.Value);
            req.Parameters.Add("@PERSON_IN_CHARGE", DataType.NVarChar, data.PERSON_IN_CHARGE.Value);
            req.Parameters.Add("@CURRENCY", DataType.NVarChar, data.CURRENCY.Value);
            req.Parameters.Add("@REWORK_FLAG", DataType.Int32, data.REWORK_FLAG.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, 0);
            req.Parameters.Add("@TIME_STAMP", DataType.Default, data.TIME_STAMP.Value);
            req.Parameters.Add("@oldTRANS_ID", DataType.NVarChar, oldTRANS_ID);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="TRANS_ID">Key #1</param>
        /// <returns></returns>
        public int Delete(Database database, String TRANS_ID)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryTransactionDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InventoryTransactionDTO.eColumns.TRANS_ID + "=@TRANS_ID");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@TRANS_ID", DataType.NVarChar, TRANS_ID);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, String TRANS_ID)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryTransactionDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InventoryTransactionDTO.eColumns.TRANS_ID + "=@TRANS_ID");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@TRANS_ID", DataType.NVarChar, TRANS_ID);
            #endregion

            return (db.ExecuteQuery(req).Rows.Count > 0);
        }
        #endregion

        #region Load Operation
        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <returns>List of DTO.</returns>
        public List<InventoryTransactionDTO> LoadAll(Database database)
        {
            return LoadAll(database, true,
                InventoryTransactionDTO.eColumns.TRANS_ID
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        public List<InventoryTransactionDTO> LoadAll(Database database, bool ascending)
        {
            return LoadAll(database, ascending,
                InventoryTransactionDTO.eColumns.TRANS_ID
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<InventoryTransactionDTO> LoadAll(Database database, bool ascending, params InventoryTransactionDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryTransactionDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + InventoryTransactionDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_ID);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOT_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.PACK_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.EXTERNAL_LOT_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_DATE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.IN_OUT_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.QTY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.WEIGHT);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OBJ_ITEM_CD);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OBJ_ORDER_QTY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OTHER_DL_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.SLIP_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REMARK);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.DEALING_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.PRICE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.AMOUNT);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.FOR_CUSTOMER);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.FOR_MACHINE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.SHIFT_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_NO2);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.NG_QTY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.NG_WEIGHT);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRAN_SUB_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.SCREEN_TYPE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.GROUP_TRANS_ID);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.RESERVE_QTY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.NG_REASON);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.EFFECT_STOCK);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOT_REMARK);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.PERSON_IN_CHARGE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.CURRENCY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OLD_DATA);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TIME_STAMP);
            sb.AppendLine(" FROM " + tableName);

            if (orderByColumns != null && orderByColumns.Length > 0)
            {
                sb.AppendLine(" ORDER BY ");
                string sort = ascending ? "asc" : "desc";

                for (int i = 0; i < orderByColumns.Length; i++)
                {
                    if (i == 0)
                        sb.AppendLine(String.Format("   {0} {1}", orderByColumns[i], sort));
                    else
                        sb.AppendLine(String.Format("   ,{0} {1}", orderByColumns[i], sort));
                }
            }
            #endregion

            DataRequest req = new DataRequest(sb.ToString());

            return db.ExecuteForList<InventoryTransactionDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="TRANS_ID">Key #1</param>
        /// <returns></returns>
        public InventoryTransactionDTO LoadByPK(Database database, String TRANS_ID)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryTransactionDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + InventoryTransactionDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_ID);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOT_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.FG_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.PACK_NO);            
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.EXTERNAL_LOT_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_DATE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.IN_OUT_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.QTY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.WEIGHT);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OBJ_ITEM_CD);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OBJ_ORDER_QTY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OTHER_DL_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.SLIP_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REMARK);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.DEALING_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.PRICE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.AMOUNT);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.FOR_CUSTOMER);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.FOR_MACHINE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.SHIFT_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_NO2);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.NG_QTY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.NG_WEIGHT);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRAN_SUB_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.SCREEN_TYPE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.GROUP_TRANS_ID);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.RESERVE_QTY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.RETURN_QTY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.NG_REASON);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.EFFECT_STOCK);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOT_REMARK);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.PERSON_IN_CHARGE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.CURRENCY);            
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OLD_DATA);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TIME_STAMP);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + InventoryTransactionDTO.eColumns.TRANS_ID + "=@TRANS_ID");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@TRANS_ID", DataType.NVarChar, TRANS_ID);
            #endregion

            List<InventoryTransactionDTO> list = db.ExecuteForList<InventoryTransactionDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }

        public List<InventoryTransactionDTO> Load(Database database, InventoryTransactionDTO data)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(InventoryTransactionDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + InventoryTransactionDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_ID);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOC_CD);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOT_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.PACK_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.EXTERNAL_LOT_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_DATE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRANS_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.IN_OUT_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.QTY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.WEIGHT);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OBJ_ITEM_CD);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OBJ_ORDER_QTY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OTHER_DL_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.SLIP_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REMARK);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.DEALING_NO);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.PRICE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.AMOUNT);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.FOR_CUSTOMER);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.FOR_MACHINE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.SHIFT_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.REF_SLIP_NO2);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.NG_QTY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.NG_WEIGHT);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TRAN_SUB_CLS);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.SCREEN_TYPE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.GROUP_TRANS_ID);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.RESERVE_QTY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.NG_REASON);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.EFFECT_STOCK);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.LOT_REMARK);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.PERSON_IN_CHARGE);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.CURRENCY);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.OLD_DATA);
            sb.AppendLine("  ," + InventoryTransactionDTO.eColumns.TIME_STAMP);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine(String.Format("  ({1} IS NULL OR {0}={1})",InventoryTransactionDTO.eColumns.TRANS_ID,"@TRANS_ID"));
            sb.AppendLine(String.Format(" AND ({1} IS NULL OR {0}={1})", InventoryTransactionDTO.eColumns.ITEM_CD, "@ITEM_CD"));
            sb.AppendLine(String.Format(" AND ({1} IS NULL OR {0}={1})", InventoryTransactionDTO.eColumns.LOT_NO, "@LOT_NO"));
            sb.AppendLine(String.Format(" AND ({1} IS NULL OR {0}={1})", InventoryTransactionDTO.eColumns.LOC_CD, "@LOC_CD"));
            sb.AppendLine(String.Format(" AND ({1} IS NULL OR {0}={1})", InventoryTransactionDTO.eColumns.SLIP_NO, "@SLIP_NO"));
            sb.AppendLine(String.Format(" AND ({1} IS NULL OR {0}={1})", InventoryTransactionDTO.eColumns.PACK_NO, "@PACK_NO"));
            sb.AppendLine(String.Format(" AND ({1} IS NULL OR {0}={1})", InventoryTransactionDTO.eColumns.TRANS_CLS, "@TRANS_CLS"));
            sb.AppendLine(String.Format(" AND ({1} IS NULL OR {0}={1})", InventoryTransactionDTO.eColumns.REF_NO, "@REF_NO"));
            sb.AppendLine(String.Format(" AND ({1} IS NULL OR {0}={1})", InventoryTransactionDTO.eColumns.REF_SLIP_NO, "@REF_SLIP_NO"));
            sb.AppendLine(String.Format(" AND ({1} IS NULL OR {0}={1})", InventoryTransactionDTO.eColumns.GROUP_TRANS_ID, "@GROUP_TRANS_ID"));
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@TRANS_ID", DataType.NVarChar, CheckNull(data.TRANS_ID.Value));
            req.Parameters.Add("@ITEM_CD", DataType.Default, CheckNull(data.ITEM_CD.Value));
            req.Parameters.Add("@LOT_NO", DataType.NVarChar, CheckNull(data.LOT_NO.Value));
            req.Parameters.Add("@LOC_CD", DataType.NVarChar, CheckNull(data.LOC_CD.Value));
            req.Parameters.Add("@SLIP_NO", DataType.NVarChar, CheckNull(data.SLIP_NO.Value));
            req.Parameters.Add("@PACK_NO", DataType.NVarChar, CheckNull(data.PACK_NO.Value));
            req.Parameters.Add("@TRANS_CLS", DataType.NVarChar, CheckNull(data.TRANS_CLS.Value));
            req.Parameters.Add("@REF_NO", DataType.NVarChar, CheckNull(data.REF_NO.Value));
            req.Parameters.Add("@REF_SLIP_NO", DataType.NVarChar, CheckNull(data.REF_SLIP_NO.Value));
            req.Parameters.Add("@GROUP_TRANS_ID", DataType.NVarChar, CheckNull(data.GROUP_TRANS_ID.Value));
            #endregion

            return db.ExecuteForList<InventoryTransactionDTO>(req);
            //List<InventoryTransactionDTO> list = db.ExecuteForList<InventoryTransactionDTO>(req);

            //if (list != null && list.Count > 0)
            //    return list[0];

            //return null;
        }
        #endregion
    }
}

