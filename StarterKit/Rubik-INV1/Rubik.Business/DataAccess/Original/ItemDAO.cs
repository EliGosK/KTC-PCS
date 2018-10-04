/* Create by: Mr.Teerayut Sinlan
 * Create on: 2010-06-21
 * Company: CSI Groups (Thailand)
 * Group: SI-EVO
 
 *** This generate source code was build for DAO on StarterKit system. ***/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;
using System.Data;
using EVOFramework;
using Rubik.DTO;

namespace Rubik.DAO
{
    internal partial class ItemDAO
    {
        #region Variables
        private readonly Database m_db;
        #endregion

        #region Constructor
        public ItemDAO() { }

        public ItemDAO(Database db) {
            this.m_db = db;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get encapsulated database object.
        /// </summary>
        public Database CurrentDatabase {
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
        protected Database UseDatabase(Database specificDB) {
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
        public int AddNewOrUpdate(Database database, ItemDTO data) {
            Database db = UseDatabase(database);

            if (Exist(database, data.ITEM_CD))
                return UpdateWithoutPK(db, data);

            return AddNew(db, data);

        }

        /// <summary>
        /// Insert new record into database.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNew(Database database, ItemDTO data) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" INSERT INTO " + data.TableName + "(");
            sb.AppendLine("  " + ItemDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + ItemDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + ItemDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + ItemDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + ItemDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + ItemDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + ItemDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + ItemDTO.eColumns.SHORT_NAME);
            sb.AppendLine("  ," + ItemDTO.eColumns.ITEM_DESC);
            sb.AppendLine("  ," + ItemDTO.eColumns.KIND_OF_PRODUCT);
            sb.AppendLine("  ," + ItemDTO.eColumns.CUSTOMER_CD);
            sb.AppendLine("  ," + ItemDTO.eColumns.CUSTOMER_USE_POINT);
            sb.AppendLine("  ," + ItemDTO.eColumns.WEIGHT);
            sb.AppendLine("  ," + ItemDTO.eColumns.BOI);
            sb.AppendLine("  ," + ItemDTO.eColumns.PRODUCTION_DI);
            sb.AppendLine("  ," + ItemDTO.eColumns.ITEM_LEVEL);
            sb.AppendLine("  ," + ItemDTO.eColumns.MAT_NAME);
            sb.AppendLine("  ," + ItemDTO.eColumns.MAT_SIZE);
            sb.AppendLine("  ," + ItemDTO.eColumns.MAT_SUPPLIER_CD);
            sb.AppendLine("  ," + ItemDTO.eColumns.KIND_OF_MAT);
            sb.AppendLine("  ," + ItemDTO.eColumns.MAT_DI);
            sb.AppendLine("  ," + ItemDTO.eColumns.REMARK);
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_KIND);
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_HEAD);
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_M);
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_L);
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_TYPE);
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_REMARK1);
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_REMARK2);
            sb.AppendLine("  ," + ItemDTO.eColumns.HEXABULAR);
            sb.AppendLine("  ," + ItemDTO.eColumns.HEAT_FLAG);
            sb.AppendLine("  ," + ItemDTO.eColumns.HEAT_TYPE);
            sb.AppendLine("  ," + ItemDTO.eColumns.HEAT_HARDNESS);
            sb.AppendLine("  ," + ItemDTO.eColumns.HEAT_CORE_HARDNESS);
            sb.AppendLine("  ," + ItemDTO.eColumns.HEAT_CASE_DEPTH);
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_FLAG);
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_KIND);
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_SUPPLIER_CD);
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_THICKNESS1_1);
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_THICKNESS1_2);
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_THICKNESS2_1);
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_THICKNESS2_2);
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_KTC);
            sb.AppendLine("  ," + ItemDTO.eColumns.BAKING_FLAG);
            sb.AppendLine("  ," + ItemDTO.eColumns.BAKING_TIME);
            sb.AppendLine("  ," + ItemDTO.eColumns.BAKING_TEMP);
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT1_FLAG);
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT1_KIND);
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT1_CONDITION);
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT2_FLAG);
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT2_KIND);
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT2_CONDITION);
            sb.AppendLine("  ," + ItemDTO.eColumns.ROUTING_TEXT);
            sb.AppendLine("  ," + ItemDTO.eColumns.OLD_DATA);
            sb.AppendLine(") VALUES(");
            sb.AppendLine("   @CRT_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,@CRT_MACHINE");
            sb.AppendLine("   ,@UPD_BY");
            sb.AppendLine("   ,GETDATE()");
            sb.AppendLine("   ,@UPD_MACHINE");
            sb.AppendLine("   ,@ITEM_CD");
            sb.AppendLine("   ,@SHORT_NAME");
            sb.AppendLine("   ,@ITEM_DESC");
            sb.AppendLine("   ,@KIND_OF_PRODUCT");
            sb.AppendLine("   ,@CUSTOMER_CD");
            sb.AppendLine("   ,@CUSTOMER_USE_POINT");
            sb.AppendLine("   ,@WEIGHT");
            sb.AppendLine("   ,@BOI");
            sb.AppendLine("   ,@PRODUCTION_DI");
            sb.AppendLine("   ,@ITEM_LEVEL");
            sb.AppendLine("   ,@MAT_NAME");
            sb.AppendLine("   ,@MAT_SIZE");
            sb.AppendLine("   ,@MAT_SUPPLIER_CD");
            sb.AppendLine("   ,@KIND_OF_MAT");
            sb.AppendLine("   ,@MAT_DI");
            sb.AppendLine("   ,@REMARK");
            sb.AppendLine("   ,@SCREW_KIND");
            sb.AppendLine("   ,@SCREW_HEAD");
            sb.AppendLine("   ,@SCREW_M");
            sb.AppendLine("   ,@SCREW_L");
            sb.AppendLine("   ,@SCREW_TYPE");
            sb.AppendLine("   ,@SCREW_REMARK1");
            sb.AppendLine("   ,@SCREW_REMARK2");
            sb.AppendLine("   ,@HEXABULAR");
            sb.AppendLine("   ,@HEAT_FLAG");
            sb.AppendLine("   ,@HEAT_TYPE");
            sb.AppendLine("   ,@HEAT_HARDNESS");
            sb.AppendLine("   ,@HEAT_CORE_HARDNESS");
            sb.AppendLine("   ,@HEAT_CASE_DEPTH");
            sb.AppendLine("   ,@PLATING_FLAG");
            sb.AppendLine("   ,@PLATING_KIND");
            sb.AppendLine("   ,@PLATING_SUPPLIER_CD");
            sb.AppendLine("   ,@PLATING_THICKNESS1_1");
            sb.AppendLine("   ,@PLATING_THICKNESS1_2");
            sb.AppendLine("   ,@PLATING_THICKNESS2_1");
            sb.AppendLine("   ,@PLATING_THICKNESS2_2");
            sb.AppendLine("   ,@PLATING_KTC");
            sb.AppendLine("   ,@BAKING_FLAG");
            sb.AppendLine("   ,@BAKING_TIME");
            sb.AppendLine("   ,@BAKING_TEMP");
            sb.AppendLine("   ,@OTHER_TREATMENT1_FLAG");
            sb.AppendLine("   ,@OTHER_TREATMENT1_KIND");
            sb.AppendLine("   ,@OTHER_TREATMENT1_CONDITION");
            sb.AppendLine("   ,@OTHER_TREATMENT2_FLAG");
            sb.AppendLine("   ,@OTHER_TREATMENT2_KIND");
            sb.AppendLine("   ,@OTHER_TREATMENT2_CONDITION");
            sb.AppendLine("   ,@ROUTING_TEXT");
            sb.AppendLine("   ,@OLD_DATA");
            sb.AppendLine(" )");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());

            #region Parameters
            req.Parameters.Add("@CRT_BY", DataType.NVarChar, data.CRT_BY.Value);
            req.Parameters.Add("@CRT_MACHINE", DataType.NVarChar, data.CRT_MACHINE.Value);
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("@SHORT_NAME", DataType.NVarChar, data.SHORT_NAME.Value);
            req.Parameters.Add("@ITEM_DESC", DataType.NVarChar, data.ITEM_DESC.Value);
            req.Parameters.Add("@KIND_OF_PRODUCT", DataType.NVarChar, data.KIND_OF_PRODUCT.Value);
            req.Parameters.Add("@CUSTOMER_CD", DataType.NVarChar, data.CUSTOMER_CD.Value);
            req.Parameters.Add("@CUSTOMER_USE_POINT", DataType.NVarChar, data.CUSTOMER_USE_POINT.Value);
            req.Parameters.Add("@WEIGHT", DataType.Number, data.WEIGHT.Value);
            req.Parameters.Add("@BOI", DataType.NVarChar, data.BOI.Value);
            req.Parameters.Add("@PRODUCTION_DI", DataType.NVarChar, data.PRODUCTION_DI.Value);
            req.Parameters.Add("@ITEM_LEVEL", DataType.NVarChar, data.ITEM_LEVEL.Value);
            req.Parameters.Add("@MAT_NAME", DataType.NVarChar, data.MAT_NAME.Value);
            req.Parameters.Add("@MAT_SIZE", DataType.NVarChar, data.MAT_SIZE.Value);
            req.Parameters.Add("@MAT_SUPPLIER_CD", DataType.NVarChar, data.MAT_SUPPLIER_CD.Value);
            req.Parameters.Add("@KIND_OF_MAT", DataType.NVarChar, data.KIND_OF_MAT.Value);
            req.Parameters.Add("@MAT_DI", DataType.NVarChar, data.MAT_DI.Value);
            req.Parameters.Add("@REMARK", DataType.NVarChar, data.REMARK.Value);
            req.Parameters.Add("@SCREW_KIND", DataType.NVarChar, data.SCREW_KIND.Value);
            req.Parameters.Add("@SCREW_HEAD", DataType.NVarChar, data.SCREW_HEAD.Value);
            req.Parameters.Add("@SCREW_M", DataType.NVarChar, data.SCREW_M.Value);
            req.Parameters.Add("@SCREW_L", DataType.NVarChar, data.SCREW_L.Value);
            req.Parameters.Add("@SCREW_TYPE", DataType.NVarChar, data.SCREW_TYPE.Value);
            req.Parameters.Add("@SCREW_REMARK1", DataType.NVarChar, data.SCREW_REMARK1.Value);
            req.Parameters.Add("@SCREW_REMARK2", DataType.NVarChar, data.SCREW_REMARK2.Value);
            req.Parameters.Add("@HEXABULAR", DataType.NVarChar, data.HEXABULAR.Value);
            req.Parameters.Add("@HEAT_FLAG", DataType.Default, data.HEAT_FLAG.Value);
            req.Parameters.Add("@HEAT_TYPE", DataType.NVarChar, data.HEAT_TYPE.Value);
            req.Parameters.Add("@HEAT_HARDNESS", DataType.NVarChar, data.HEAT_HARDNESS.Value);
            req.Parameters.Add("@HEAT_CORE_HARDNESS", DataType.NVarChar, data.HEAT_CORE_HARDNESS.Value);
            req.Parameters.Add("@HEAT_CASE_DEPTH", DataType.NVarChar, data.HEAT_CASE_DEPTH.Value);
            req.Parameters.Add("@PLATING_FLAG", DataType.Default, data.PLATING_FLAG.Value);
            req.Parameters.Add("@PLATING_KIND", DataType.NVarChar, data.PLATING_KIND.Value);
            req.Parameters.Add("@PLATING_SUPPLIER_CD", DataType.NVarChar, data.PLATING_SUPPLIER_CD.Value);
            req.Parameters.Add("@PLATING_THICKNESS1_1", DataType.NVarChar, data.PLATING_THICKNESS1_1.Value);
            req.Parameters.Add("@PLATING_THICKNESS1_2", DataType.NVarChar, data.PLATING_THICKNESS1_2.Value);
            req.Parameters.Add("@PLATING_THICKNESS2_1", DataType.NVarChar, data.PLATING_THICKNESS2_1.Value);
            req.Parameters.Add("@PLATING_THICKNESS2_2", DataType.NVarChar, data.PLATING_THICKNESS2_2.Value);
            req.Parameters.Add("@PLATING_KTC", DataType.NVarChar, data.PLATING_KTC.Value);
            req.Parameters.Add("@BAKING_FLAG", DataType.Default, data.BAKING_FLAG.Value);
            req.Parameters.Add("@BAKING_TIME", DataType.NVarChar, data.BAKING_TIME.Value);
            req.Parameters.Add("@BAKING_TEMP", DataType.NVarChar, data.BAKING_TEMP.Value);
            req.Parameters.Add("@OTHER_TREATMENT1_FLAG", DataType.Default, data.OTHER_TREATMENT1_FLAG.Value);
            req.Parameters.Add("@OTHER_TREATMENT1_KIND", DataType.NVarChar, data.OTHER_TREATMENT1_KIND.Value);
            req.Parameters.Add("@OTHER_TREATMENT1_CONDITION", DataType.NVarChar, data.OTHER_TREATMENT1_CONDITION.Value);
            req.Parameters.Add("@OTHER_TREATMENT2_FLAG", DataType.Default, data.OTHER_TREATMENT2_FLAG.Value);
            req.Parameters.Add("@OTHER_TREATMENT2_KIND", DataType.NVarChar, data.OTHER_TREATMENT2_KIND.Value);
            req.Parameters.Add("@OTHER_TREATMENT2_CONDITION", DataType.NVarChar, data.OTHER_TREATMENT2_CONDITION.Value);
            req.Parameters.Add("@ROUTING_TEXT", DataType.NVarChar, data.ROUTING_TEXT.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, data.OLD_DATA.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using primary key value on the given data variable
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data with primary key value.</param>
        /// <returns></returns>
        public int UpdateWithoutPK(Database database, ItemDTO data) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + ItemDTO.eColumns.UPD_BY + "=@UPD_BY");
            sb.AppendLine("  ," + ItemDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + ItemDTO.eColumns.UPD_MACHINE + "=@UPD_MACHINE");
            sb.AppendLine("  ," + ItemDTO.eColumns.SHORT_NAME + "=@SHORT_NAME");
            sb.AppendLine("  ," + ItemDTO.eColumns.ITEM_DESC + "=@ITEM_DESC");
            sb.AppendLine("  ," + ItemDTO.eColumns.KIND_OF_PRODUCT + "=@KIND_OF_PRODUCT");
            sb.AppendLine("  ," + ItemDTO.eColumns.CUSTOMER_CD + "=@CUSTOMER_CD");
            sb.AppendLine("  ," + ItemDTO.eColumns.CUSTOMER_USE_POINT + "=@CUSTOMER_USE_POINT");
            sb.AppendLine("  ," + ItemDTO.eColumns.WEIGHT + "=@WEIGHT");
            sb.AppendLine("  ," + ItemDTO.eColumns.BOI + "=@BOI");
            sb.AppendLine("  ," + ItemDTO.eColumns.PRODUCTION_DI + "=@PRODUCTION_DI");
            sb.AppendLine("  ," + ItemDTO.eColumns.ITEM_LEVEL + "=@ITEM_LEVEL");
            sb.AppendLine("  ," + ItemDTO.eColumns.MAT_NAME + "=@MAT_NAME");
            sb.AppendLine("  ," + ItemDTO.eColumns.MAT_SIZE + "=@MAT_SIZE");
            sb.AppendLine("  ," + ItemDTO.eColumns.MAT_SUPPLIER_CD + "=@MAT_SUPPLIER_CD");
            sb.AppendLine("  ," + ItemDTO.eColumns.KIND_OF_MAT + "=@KIND_OF_MAT");
            sb.AppendLine("  ," + ItemDTO.eColumns.MAT_DI + "=@MAT_DI");
            sb.AppendLine("  ," + ItemDTO.eColumns.REMARK + "=@REMARK");
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_KIND + "=@SCREW_KIND");
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_HEAD + "=@SCREW_HEAD");
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_M + "=@SCREW_M");
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_L + "=@SCREW_L");
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_TYPE + "=@SCREW_TYPE");
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_REMARK1 + "=@SCREW_REMARK1");
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_REMARK2 + "=@SCREW_REMARK2");
            sb.AppendLine("  ," + ItemDTO.eColumns.HEXABULAR + "=@HEXABULAR");
            sb.AppendLine("  ," + ItemDTO.eColumns.HEAT_FLAG + "=@HEAT_FLAG");
            sb.AppendLine("  ," + ItemDTO.eColumns.HEAT_TYPE + "=@HEAT_TYPE");
            sb.AppendLine("  ," + ItemDTO.eColumns.HEAT_HARDNESS + "=@HEAT_HARDNESS");
            sb.AppendLine("  ," + ItemDTO.eColumns.HEAT_CORE_HARDNESS + "=@HEAT_CORE_HARDNESS");
            sb.AppendLine("  ," + ItemDTO.eColumns.HEAT_CASE_DEPTH + "=@HEAT_CASE_DEPTH");
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_FLAG + "=@PLATING_FLAG");
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_KIND + "=@PLATING_KIND");
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_SUPPLIER_CD + "=@PLATING_SUPPLIER_CD");
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_THICKNESS1_1 + "=@PLATING_THICKNESS1_1");
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_THICKNESS1_2 + "=@PLATING_THICKNESS1_2");
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_THICKNESS2_1 + "=@PLATING_THICKNESS2_1");
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_THICKNESS2_2 + "=@PLATING_THICKNESS2_2");
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_KTC + "=@PLATING_KTC");
            sb.AppendLine("  ," + ItemDTO.eColumns.BAKING_FLAG + "=@BAKING_FLAG");
            sb.AppendLine("  ," + ItemDTO.eColumns.BAKING_TIME + "=@BAKING_TIME");
            sb.AppendLine("  ," + ItemDTO.eColumns.BAKING_TEMP + "=@BAKING_TEMP");
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT1_FLAG + "=@OTHER_TREATMENT1_FLAG");
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT1_KIND + "=@OTHER_TREATMENT1_KIND");
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT1_CONDITION + "=@OTHER_TREATMENT1_CONDITION");
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT2_FLAG + "=@OTHER_TREATMENT2_FLAG");
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT2_KIND + "=@OTHER_TREATMENT2_KIND");
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT2_CONDITION + "=@OTHER_TREATMENT2_CONDITION");
            sb.AppendLine("  ," + ItemDTO.eColumns.ROUTING_TEXT + "=@ROUTING_TEXT");
            sb.AppendLine("  ," + ItemDTO.eColumns.OLD_DATA + "=@OLD_DATA");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ItemDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("@SHORT_NAME", DataType.NVarChar, data.SHORT_NAME.Value);
            req.Parameters.Add("@ITEM_DESC", DataType.NVarChar, data.ITEM_DESC.Value);
            req.Parameters.Add("@KIND_OF_PRODUCT", DataType.NVarChar, data.KIND_OF_PRODUCT.Value);
            req.Parameters.Add("@CUSTOMER_CD", DataType.NVarChar, data.CUSTOMER_CD.Value);
            req.Parameters.Add("@CUSTOMER_USE_POINT", DataType.NVarChar, data.CUSTOMER_USE_POINT.Value);
            req.Parameters.Add("@WEIGHT", DataType.Number, data.WEIGHT.Value);
            req.Parameters.Add("@BOI", DataType.NVarChar, data.BOI.Value);
            req.Parameters.Add("@PRODUCTION_DI", DataType.NVarChar, data.PRODUCTION_DI.Value);
            req.Parameters.Add("@ITEM_LEVEL", DataType.NVarChar, data.ITEM_LEVEL.Value);
            req.Parameters.Add("@MAT_NAME", DataType.NVarChar, data.MAT_NAME.Value);
            req.Parameters.Add("@MAT_SIZE", DataType.NVarChar, data.MAT_SIZE.Value);
            req.Parameters.Add("@MAT_SUPPLIER_CD", DataType.NVarChar, data.MAT_SUPPLIER_CD.Value);
            req.Parameters.Add("@KIND_OF_MAT", DataType.NVarChar, data.KIND_OF_MAT.Value);
            req.Parameters.Add("@MAT_DI", DataType.NVarChar, data.MAT_DI.Value);
            req.Parameters.Add("@REMARK", DataType.NVarChar, data.REMARK.Value);
            req.Parameters.Add("@SCREW_KIND", DataType.NVarChar, data.SCREW_KIND.Value);
            req.Parameters.Add("@SCREW_HEAD", DataType.NVarChar, data.SCREW_HEAD.Value);
            req.Parameters.Add("@SCREW_M", DataType.NVarChar, data.SCREW_M.Value);
            req.Parameters.Add("@SCREW_L", DataType.NVarChar, data.SCREW_L.Value);
            req.Parameters.Add("@SCREW_TYPE", DataType.NVarChar, data.SCREW_TYPE.Value);
            req.Parameters.Add("@SCREW_REMARK1", DataType.NVarChar, data.SCREW_REMARK1.Value);
            req.Parameters.Add("@SCREW_REMARK2", DataType.NVarChar, data.SCREW_REMARK2.Value);
            req.Parameters.Add("@HEXABULAR", DataType.NVarChar, data.HEXABULAR.Value);
            req.Parameters.Add("@HEAT_FLAG", DataType.Default, data.HEAT_FLAG.Value);
            req.Parameters.Add("@HEAT_TYPE", DataType.NVarChar, data.HEAT_TYPE.Value);
            req.Parameters.Add("@HEAT_HARDNESS", DataType.NVarChar, data.HEAT_HARDNESS.Value);
            req.Parameters.Add("@HEAT_CORE_HARDNESS", DataType.NVarChar, data.HEAT_CORE_HARDNESS.Value);
            req.Parameters.Add("@HEAT_CASE_DEPTH", DataType.NVarChar, data.HEAT_CASE_DEPTH.Value);
            req.Parameters.Add("@PLATING_FLAG", DataType.Default, data.PLATING_FLAG.Value);
            req.Parameters.Add("@PLATING_KIND", DataType.NVarChar, data.PLATING_KIND.Value);
            req.Parameters.Add("@PLATING_SUPPLIER_CD", DataType.NVarChar, data.PLATING_SUPPLIER_CD.Value);
            req.Parameters.Add("@PLATING_THICKNESS1_1", DataType.NVarChar, data.PLATING_THICKNESS1_1.Value);
            req.Parameters.Add("@PLATING_THICKNESS1_2", DataType.NVarChar, data.PLATING_THICKNESS1_2.Value);
            req.Parameters.Add("@PLATING_THICKNESS2_1", DataType.NVarChar, data.PLATING_THICKNESS2_1.Value);
            req.Parameters.Add("@PLATING_THICKNESS2_2", DataType.NVarChar, data.PLATING_THICKNESS2_2.Value);
            req.Parameters.Add("@PLATING_KTC", DataType.NVarChar, data.PLATING_KTC.Value);
            req.Parameters.Add("@BAKING_FLAG", DataType.Default, data.BAKING_FLAG.Value);
            req.Parameters.Add("@BAKING_TIME", DataType.NVarChar, data.BAKING_TIME.Value);
            req.Parameters.Add("@BAKING_TEMP", DataType.NVarChar, data.BAKING_TEMP.Value);
            req.Parameters.Add("@OTHER_TREATMENT1_FLAG", DataType.Default, data.OTHER_TREATMENT1_FLAG.Value);
            req.Parameters.Add("@OTHER_TREATMENT1_KIND", DataType.NVarChar, data.OTHER_TREATMENT1_KIND.Value);
            req.Parameters.Add("@OTHER_TREATMENT1_CONDITION", DataType.NVarChar, data.OTHER_TREATMENT1_CONDITION.Value);
            req.Parameters.Add("@OTHER_TREATMENT2_FLAG", DataType.Default, data.OTHER_TREATMENT2_FLAG.Value);
            req.Parameters.Add("@OTHER_TREATMENT2_KIND", DataType.NVarChar, data.OTHER_TREATMENT2_KIND.Value);
            req.Parameters.Add("@OTHER_TREATMENT2_CONDITION", DataType.NVarChar, data.OTHER_TREATMENT2_CONDITION.Value);
            req.Parameters.Add("@ROUTING_TEXT", DataType.NVarChar, data.ROUTING_TEXT.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, data.OLD_DATA.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Update record by using the table's primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="data">Data which to update.</param>
        /// <param name="oldITEM_CD">Old Key #1</param>
        /// <returns></returns>
        public int UpdateWithPK(Database database, ItemDTO data, String oldITEM_CD) {

            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE " + data.TableName);
            sb.AppendLine(" SET ");
            sb.AppendLine("  " + ItemDTO.eColumns.UPD_BY + "=@UPD_BY");
            sb.AppendLine("  ," + ItemDTO.eColumns.UPD_DATE + "=GETDATE()");
            sb.AppendLine("  ," + ItemDTO.eColumns.UPD_MACHINE + "=@UPD_MACHINE");
            sb.AppendLine("  ," + ItemDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            sb.AppendLine("  ," + ItemDTO.eColumns.SHORT_NAME + "=@SHORT_NAME");
            sb.AppendLine("  ," + ItemDTO.eColumns.ITEM_DESC + "=@ITEM_DESC");
            sb.AppendLine("  ," + ItemDTO.eColumns.KIND_OF_PRODUCT + "=@KIND_OF_PRODUCT");
            sb.AppendLine("  ," + ItemDTO.eColumns.CUSTOMER_CD + "=@CUSTOMER_CD");
            sb.AppendLine("  ," + ItemDTO.eColumns.CUSTOMER_USE_POINT + "=@CUSTOMER_USE_POINT");
            sb.AppendLine("  ," + ItemDTO.eColumns.WEIGHT + "=@WEIGHT");
            sb.AppendLine("  ," + ItemDTO.eColumns.BOI + "=@BOI");
            sb.AppendLine("  ," + ItemDTO.eColumns.PRODUCTION_DI + "=@PRODUCTION_DI");
            sb.AppendLine("  ," + ItemDTO.eColumns.ITEM_LEVEL + "=@ITEM_LEVEL");
            sb.AppendLine("  ," + ItemDTO.eColumns.MAT_NAME + "=@MAT_NAME");
            sb.AppendLine("  ," + ItemDTO.eColumns.MAT_SIZE + "=@MAT_SIZE");
            sb.AppendLine("  ," + ItemDTO.eColumns.MAT_SUPPLIER_CD + "=@MAT_SUPPLIER_CD");
            sb.AppendLine("  ," + ItemDTO.eColumns.KIND_OF_MAT + "=@KIND_OF_MAT");
            sb.AppendLine("  ," + ItemDTO.eColumns.MAT_DI + "=@MAT_DI");
            sb.AppendLine("  ," + ItemDTO.eColumns.REMARK + "=@REMARK");
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_KIND + "=@SCREW_KIND");
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_HEAD + "=@SCREW_HEAD");
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_M + "=@SCREW_M");
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_L + "=@SCREW_L");
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_TYPE + "=@SCREW_TYPE");
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_REMARK1 + "=@SCREW_REMARK1");
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_REMARK2 + "=@SCREW_REMARK2");
            sb.AppendLine("  ," + ItemDTO.eColumns.HEXABULAR + "=@HEXABULAR");
            sb.AppendLine("  ," + ItemDTO.eColumns.HEAT_FLAG + "=@HEAT_FLAG");
            sb.AppendLine("  ," + ItemDTO.eColumns.HEAT_TYPE + "=@HEAT_TYPE");
            sb.AppendLine("  ," + ItemDTO.eColumns.HEAT_HARDNESS + "=@HEAT_HARDNESS");
            sb.AppendLine("  ," + ItemDTO.eColumns.HEAT_CORE_HARDNESS + "=@HEAT_CORE_HARDNESS");
            sb.AppendLine("  ," + ItemDTO.eColumns.HEAT_CASE_DEPTH + "=@HEAT_CASE_DEPTH");
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_FLAG + "=@PLATING_FLAG");
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_KIND + "=@PLATING_KIND");
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_SUPPLIER_CD + "=@PLATING_SUPPLIER_CD");
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_THICKNESS1_1 + "=@PLATING_THICKNESS1_1");
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_THICKNESS1_2 + "=@PLATING_THICKNESS1_2");
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_THICKNESS2_1 + "=@PLATING_THICKNESS2_1");
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_THICKNESS2_2 + "=@PLATING_THICKNESS2_2");
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_KTC + "=@PLATING_KTC");
            sb.AppendLine("  ," + ItemDTO.eColumns.BAKING_FLAG + "=@BAKING_FLAG");
            sb.AppendLine("  ," + ItemDTO.eColumns.BAKING_TIME + "=@BAKING_TIME");
            sb.AppendLine("  ," + ItemDTO.eColumns.BAKING_TEMP + "=@BAKING_TEMP");
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT1_FLAG + "=@OTHER_TREATMENT1_FLAG");
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT1_KIND + "=@OTHER_TREATMENT1_KIND");
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT1_CONDITION + "=@OTHER_TREATMENT1_CONDITION");
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT2_FLAG + "=@OTHER_TREATMENT2_FLAG");
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT2_KIND + "=@OTHER_TREATMENT2_KIND");
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT2_CONDITION + "=@OTHER_TREATMENT2_CONDITION");
            sb.AppendLine("  ," + ItemDTO.eColumns.OLD_DATA + "=@OLD_DATA");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ItemDTO.eColumns.ITEM_CD + "=@oldITEM_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("@UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("@ITEM_CD", DataType.NVarChar, data.ITEM_CD.Value);
            req.Parameters.Add("@SHORT_NAME", DataType.NVarChar, data.SHORT_NAME.Value);
            req.Parameters.Add("@ITEM_DESC", DataType.NVarChar, data.ITEM_DESC.Value);
            req.Parameters.Add("@KIND_OF_PRODUCT", DataType.NVarChar, data.KIND_OF_PRODUCT.Value);
            req.Parameters.Add("@CUSTOMER_CD", DataType.NVarChar, data.CUSTOMER_CD.Value);
            req.Parameters.Add("@CUSTOMER_USE_POINT", DataType.NVarChar, data.CUSTOMER_USE_POINT.Value);
            req.Parameters.Add("@WEIGHT", DataType.Number, data.WEIGHT.Value);
            req.Parameters.Add("@BOI", DataType.NVarChar, data.BOI.Value);
            req.Parameters.Add("@PRODUCTION_DI", DataType.NVarChar, data.PRODUCTION_DI.Value);
            req.Parameters.Add("@ITEM_LEVEL", DataType.NVarChar, data.ITEM_LEVEL.Value);
            req.Parameters.Add("@MAT_NAME", DataType.NVarChar, data.MAT_NAME.Value);
            req.Parameters.Add("@MAT_SIZE", DataType.NVarChar, data.MAT_SIZE.Value);
            req.Parameters.Add("@MAT_SUPPLIER_CD", DataType.NVarChar, data.MAT_SUPPLIER_CD.Value);
            req.Parameters.Add("@KIND_OF_MAT", DataType.NVarChar, data.KIND_OF_MAT.Value);
            req.Parameters.Add("@MAT_DI", DataType.NVarChar, data.MAT_DI.Value);
            req.Parameters.Add("@REMARK", DataType.NVarChar, data.REMARK.Value);
            req.Parameters.Add("@SCREW_KIND", DataType.NVarChar, data.SCREW_KIND.Value);
            req.Parameters.Add("@SCREW_HEAD", DataType.NVarChar, data.SCREW_HEAD.Value);
            req.Parameters.Add("@SCREW_M", DataType.NVarChar, data.SCREW_M.Value);
            req.Parameters.Add("@SCREW_L", DataType.NVarChar, data.SCREW_L.Value);
            req.Parameters.Add("@SCREW_TYPE", DataType.NVarChar, data.SCREW_TYPE.Value);
            req.Parameters.Add("@SCREW_REMARK1", DataType.NVarChar, data.SCREW_REMARK1.Value);
            req.Parameters.Add("@SCREW_REMARK2", DataType.NVarChar, data.SCREW_REMARK2.Value);
            req.Parameters.Add("@HEXABULAR", DataType.NVarChar, data.HEXABULAR.Value);
            req.Parameters.Add("@HEAT_FLAG", DataType.Default, data.HEAT_FLAG.Value);
            req.Parameters.Add("@HEAT_TYPE", DataType.NVarChar, data.HEAT_TYPE.Value);
            req.Parameters.Add("@HEAT_HARDNESS", DataType.NVarChar, data.HEAT_HARDNESS.Value);
            req.Parameters.Add("@HEAT_CORE_HARDNESS", DataType.NVarChar, data.HEAT_CORE_HARDNESS.Value);
            req.Parameters.Add("@HEAT_CASE_DEPTH", DataType.NVarChar, data.HEAT_CASE_DEPTH.Value);
            req.Parameters.Add("@PLATING_FLAG", DataType.Default, data.PLATING_FLAG.Value);
            req.Parameters.Add("@PLATING_KIND", DataType.NVarChar, data.PLATING_KIND.Value);
            req.Parameters.Add("@PLATING_SUPPLIER_CD", DataType.NVarChar, data.PLATING_SUPPLIER_CD.Value);
            req.Parameters.Add("@PLATING_THICKNESS1_1", DataType.NVarChar, data.PLATING_THICKNESS1_1.Value);
            req.Parameters.Add("@PLATING_THICKNESS1_2", DataType.NVarChar, data.PLATING_THICKNESS1_2.Value);
            req.Parameters.Add("@PLATING_THICKNESS2_1", DataType.NVarChar, data.PLATING_THICKNESS2_1.Value);
            req.Parameters.Add("@PLATING_THICKNESS2_2", DataType.NVarChar, data.PLATING_THICKNESS2_2.Value);
            req.Parameters.Add("@PLATING_KTC", DataType.NVarChar, data.PLATING_KTC.Value);
            req.Parameters.Add("@BAKING_FLAG", DataType.Default, data.BAKING_FLAG.Value);
            req.Parameters.Add("@BAKING_TIME", DataType.NVarChar, data.BAKING_TIME.Value);
            req.Parameters.Add("@BAKING_TEMP", DataType.NVarChar, data.BAKING_TEMP.Value);
            req.Parameters.Add("@OTHER_TREATMENT1_FLAG", DataType.Default, data.OTHER_TREATMENT1_FLAG.Value);
            req.Parameters.Add("@OTHER_TREATMENT1_KIND", DataType.NVarChar, data.OTHER_TREATMENT1_KIND.Value);
            req.Parameters.Add("@OTHER_TREATMENT1_CONDITION", DataType.NVarChar, data.OTHER_TREATMENT1_CONDITION.Value);
            req.Parameters.Add("@OTHER_TREATMENT2_FLAG", DataType.Default, data.OTHER_TREATMENT2_FLAG.Value);
            req.Parameters.Add("@OTHER_TREATMENT2_KIND", DataType.NVarChar, data.OTHER_TREATMENT2_KIND.Value);
            req.Parameters.Add("@OTHER_TREATMENT2_CONDITION", DataType.NVarChar, data.OTHER_TREATMENT2_CONDITION.Value);
            req.Parameters.Add("@OLD_DATA", DataType.Default, data.OLD_DATA.Value);
            req.Parameters.Add("@oldITEM_CD", DataType.NVarChar, oldITEM_CD);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        /// <summary>
        /// Delete record with key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ITEM_CD">Key #1</param>
        /// <returns></returns>
        public int Delete(Database database, String ITEM_CD) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement

            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ItemDTO));
            sb.AppendLine(" DELETE FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ItemDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@ITEM_CD", DataType.NVarChar, ITEM_CD);
            #endregion
            return db.ExecuteNonQuery(req);
        }
        #endregion

        #region Check Exists Operation
        /// <summary>
        /// Check exists the specified key.
        /// </summary>
        public bool Exist(Database database, String ITEM_CD) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ItemDTO));

            sb.AppendLine(" SELECT TOP 1 1 ");
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ItemDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@ITEM_CD", DataType.NVarChar, ITEM_CD);
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
        public List<ItemDTO> LoadAll(Database database) {
            return LoadAll(database, true,
                ItemDTO.eColumns.ITEM_CD
            );
        }

        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <returns></returns>
        /// 
        public List<ItemDTO> LoadAll(Database database, bool ascending) {
            return LoadAll(database, ascending,
                ItemDTO.eColumns.ITEM_CD
            );
        }


        /// <summary>
        /// Load all records.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ascending">Kind of sorting.</param>
        /// <param name="orderByColumns"></param>
        /// <returns></returns>
        public List<ItemDTO> LoadAll(Database database, bool ascending, params ItemDTO.eColumns[] orderByColumns) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ItemDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + ItemDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + ItemDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + ItemDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + ItemDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + ItemDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + ItemDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + ItemDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + ItemDTO.eColumns.SHORT_NAME);
            sb.AppendLine("  ," + ItemDTO.eColumns.ITEM_DESC);
            sb.AppendLine("  ," + ItemDTO.eColumns.KIND_OF_PRODUCT);
            sb.AppendLine("  ," + ItemDTO.eColumns.CUSTOMER_CD);
            sb.AppendLine("  ," + ItemDTO.eColumns.CUSTOMER_USE_POINT);
            sb.AppendLine("  ," + ItemDTO.eColumns.WEIGHT);
            sb.AppendLine("  ," + ItemDTO.eColumns.BOI);
            sb.AppendLine("  ," + ItemDTO.eColumns.PRODUCTION_DI);
            sb.AppendLine("  ," + ItemDTO.eColumns.ITEM_LEVEL);
            sb.AppendLine("  ," + ItemDTO.eColumns.MAT_NAME);
            sb.AppendLine("  ," + ItemDTO.eColumns.MAT_SIZE);
            sb.AppendLine("  ," + ItemDTO.eColumns.MAT_SUPPLIER_CD);
            sb.AppendLine("  ," + ItemDTO.eColumns.KIND_OF_MAT);
            sb.AppendLine("  ," + ItemDTO.eColumns.MAT_DI);
            sb.AppendLine("  ," + ItemDTO.eColumns.REMARK);
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_KIND);
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_HEAD);
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_M);
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_L);
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_TYPE);
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_REMARK1);
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_REMARK2);
            sb.AppendLine("  ," + ItemDTO.eColumns.HEXABULAR);
            sb.AppendLine("  ," + ItemDTO.eColumns.HEAT_FLAG);
            sb.AppendLine("  ," + ItemDTO.eColumns.HEAT_TYPE);
            sb.AppendLine("  ," + ItemDTO.eColumns.HEAT_HARDNESS);
            sb.AppendLine("  ," + ItemDTO.eColumns.HEAT_CORE_HARDNESS);
            sb.AppendLine("  ," + ItemDTO.eColumns.HEAT_CASE_DEPTH);
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_FLAG);
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_KIND);
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_SUPPLIER_CD);
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_THICKNESS1_1);
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_THICKNESS1_2);
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_THICKNESS2_1);
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_THICKNESS2_2);
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_KTC);
            sb.AppendLine("  ," + ItemDTO.eColumns.BAKING_FLAG);
            sb.AppendLine("  ," + ItemDTO.eColumns.BAKING_TIME);
            sb.AppendLine("  ," + ItemDTO.eColumns.BAKING_TEMP);
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT1_FLAG);
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT1_KIND);
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT1_CONDITION);
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT2_FLAG);
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT2_KIND);
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT2_CONDITION);
            sb.AppendLine("  ," + ItemDTO.eColumns.OLD_DATA);
            sb.AppendLine(" FROM " + tableName);

            if (orderByColumns != null && orderByColumns.Length > 0) {
                sb.AppendLine(" ORDER BY ");
                string sort = ascending ? "asc" : "desc";

                for (int i = 0; i < orderByColumns.Length; i++) {
                    if (i == 0)
                        sb.AppendLine(String.Format("   {0} {1}", orderByColumns[i], sort));
                    else
                        sb.AppendLine(String.Format("   ,{0} {1}", orderByColumns[i], sort));
                }
            }
            #endregion

            DataRequest req = new DataRequest(sb.ToString());

            return db.ExecuteForList<ItemDTO>(req);
        }

        /// <summary>
        /// Load with specified primary key.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="ITEM_CD">Key #1</param>
        /// <returns></returns>
        public ItemDTO LoadByPK(Database database, String ITEM_CD) {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ItemDTO));
            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + ItemDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + ItemDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + ItemDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + ItemDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + ItemDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + ItemDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + ItemDTO.eColumns.ITEM_CD);
            sb.AppendLine("  ," + ItemDTO.eColumns.SHORT_NAME);
            sb.AppendLine("  ," + ItemDTO.eColumns.ITEM_DESC);
            sb.AppendLine("  ," + ItemDTO.eColumns.KIND_OF_PRODUCT);
            sb.AppendLine("  ," + ItemDTO.eColumns.CUSTOMER_CD);
            sb.AppendLine("  ," + ItemDTO.eColumns.CUSTOMER_USE_POINT);
            sb.AppendLine("  ," + ItemDTO.eColumns.WEIGHT);
            sb.AppendLine("  ," + ItemDTO.eColumns.BOI);
            sb.AppendLine("  ," + ItemDTO.eColumns.PRODUCTION_DI);
            sb.AppendLine("  ," + ItemDTO.eColumns.ITEM_LEVEL);
            sb.AppendLine("  ," + ItemDTO.eColumns.MAT_NAME);
            sb.AppendLine("  ," + ItemDTO.eColumns.MAT_SIZE);
            sb.AppendLine("  ," + ItemDTO.eColumns.MAT_SUPPLIER_CD);
            sb.AppendLine("  ," + ItemDTO.eColumns.KIND_OF_MAT);
            sb.AppendLine("  ," + ItemDTO.eColumns.MAT_DI);
            sb.AppendLine("  ," + ItemDTO.eColumns.REMARK);
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_KIND);
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_HEAD);
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_M);
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_L);
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_TYPE);
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_REMARK1);
            sb.AppendLine("  ," + ItemDTO.eColumns.SCREW_REMARK2);
            sb.AppendLine("  ," + ItemDTO.eColumns.HEXABULAR);
            sb.AppendLine("  ," + ItemDTO.eColumns.HEAT_FLAG);
            sb.AppendLine("  ," + ItemDTO.eColumns.HEAT_TYPE);
            sb.AppendLine("  ," + ItemDTO.eColumns.HEAT_HARDNESS);
            sb.AppendLine("  ," + ItemDTO.eColumns.HEAT_CORE_HARDNESS);
            sb.AppendLine("  ," + ItemDTO.eColumns.HEAT_CASE_DEPTH);
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_FLAG);
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_KIND);
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_SUPPLIER_CD);
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_THICKNESS1_1);
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_THICKNESS1_2);
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_THICKNESS2_1);
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_THICKNESS2_2);
            sb.AppendLine("  ," + ItemDTO.eColumns.PLATING_KTC);
            sb.AppendLine("  ," + ItemDTO.eColumns.BAKING_FLAG);
            sb.AppendLine("  ," + ItemDTO.eColumns.BAKING_TIME);
            sb.AppendLine("  ," + ItemDTO.eColumns.BAKING_TEMP);
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT1_FLAG);
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT1_KIND);
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT1_CONDITION);
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT2_FLAG);
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT2_KIND);
            sb.AppendLine("  ," + ItemDTO.eColumns.OTHER_TREATMENT2_CONDITION);
            sb.AppendLine("  ," + ItemDTO.eColumns.OLD_DATA);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ");
            sb.AppendLine("  " + ItemDTO.eColumns.ITEM_CD + "=@ITEM_CD");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("@ITEM_CD", DataType.NVarChar, ITEM_CD);
            #endregion

            List<ItemDTO> list = db.ExecuteForList<ItemDTO>(req);

            if (list != null && list.Count > 0)
                return list[0];

            return null;
        }

        public DataTable LoadItemList(Database database, bool bIncludeOldData)
        {
            Database db = UseDatabase(database);

            DataRequest req = new DataRequest("S_MAS030_LoadItemList");
            req.CommandType = CommandType.StoredProcedure;
            if (!bIncludeOldData)
                req.Parameters.Add("@pInt_OldData", 0);

            return db.ExecuteQuery(req);
        }

        public string ValidateBeforeDelete(Database database, NZString ITEM_CD)
        {
            Database db = UseDatabase(database);
            DataRequest req = new DataRequest("S_MAS030_CheckBeforeDelete");
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_ItemCode", DataType.VarChar, ITEM_CD.Value);
            string sReturnCode = db.ExecuteScalar(req).ToString();
            return (NZString)sReturnCode;
        }

        
        #endregion
    }
}

