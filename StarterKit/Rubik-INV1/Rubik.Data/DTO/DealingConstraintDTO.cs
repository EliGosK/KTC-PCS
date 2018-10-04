/*
 *		Author: Ms. Sansanee K.
 *      Team : SI-EVO
 * 		Writed On 2012/03/05
 * 		Time : 03:53 PM
 *  	This is DTO for TB_DEALING_CONSTRAINT_MS Table.
 *		From Templates Version : 1.0.0
 *		Last Modify Template On : 2009/08/27
 */
#region Using Namespace
using System;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Database;
using System.Collections.Generic;
#endregion

namespace Rubik.DTO
{
    [Serializable()]
    [DataTransferObject("TB_DEALING_CONSTRAINT_MS", typeof(eColumns))]
    public class DealingConstraintDTO : AbstractDTO
    {
        #region " Enums Columns "
        public enum eColumns
        {
            LOC_CD,
            NO_CONSUMPTION_FLAG,
            COMPONENT_ITEM_USAGE,
            ENABLE_SUPPLIER_FLAG,
            ENABLE_LOT_FLAG,
            ENABLE_PACK_FLAG,
            ENABLE_CUST_LOT_FLAG,
            NO_MOVE_FLAG,
            NO_PRODUCTION_REPORT_FLAG,
            NO_NG_CONSUMPTION_FLAG,
            LOT_CONTROL_FLAG,
            CHECK_DUPLICATE_LOT_FLAG
        };
        #endregion

        #region " Variables "
        private NZString m_strLOC_CD = new NZString();
        private NZInt m_iNO_CONSUMPTION_FLAG = new NZInt();
        private NZInt m_iCOMPONENT_ITEM_USAGE = new NZInt();
        private NZInt m_iENABLE_SUPPLIER_FLAG = new NZInt();
        private NZInt m_iENABLE_LOT_FLAG = new NZInt();
        private NZInt m_iENABLE_PACK_FLAG = new NZInt();
        private NZInt m_iENABLE_CUST_LOT_FLAG = new NZInt();
        private NZInt m_iNO_MOVE_FLAG = new NZInt();
        private NZInt m_iNO_PRODUCTION_REPORT_FLAG = new NZInt();
        private NZInt m_iNO_NG_CONSUMPTION_FLAG = new NZInt();
        private NZInt m_iLOT_CONTROL_FLAG = new NZInt();
        private NZInt m_iCHECK_DUPLICATE_LOT_FLAG = new NZInt();
        #endregion

        #region " Constructor "

        #endregion

        #region " Getter and Setter properties "
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOC_CD", 0, 0, 30)]
        public NZString LOC_CD
        {
            get { return m_strLOC_CD; }
            set
            {
                if (value == null)
                    m_strLOC_CD.Value = value;
                else
                    m_strLOC_CD = value;
            }
        }
        /// <summary>
        /// Production Report
        /// </summary>
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Int32, "NO_CONSUMPTION_FLAG", 10, 0, 4)]
        public NZInt NO_CONSUMPTION_FLAG
        {
            get { return m_iNO_CONSUMPTION_FLAG; }
            set
            {
                if (value == null)
                    m_iNO_CONSUMPTION_FLAG.Value = value;
                else
                    m_iNO_CONSUMPTION_FLAG = value;
            }
        }
        /// <summary>
        /// move
        /// </summary>
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Int32, "COMPONENT_ITEM_USAGE", 10, 0, 4)]
        public NZInt COMPONENT_ITEM_USAGE
        {
            get { return m_iCOMPONENT_ITEM_USAGE; }
            set
            {
                if (value == null)
                    m_iCOMPONENT_ITEM_USAGE.Value = value;
                else
                    m_iCOMPONENT_ITEM_USAGE = value;
            }
        }
        /// <summary>
        /// production report
        /// </summary>
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Int32, "ENABLE_SUPPLIER_FLAG", 10, 0, 4)]
        public NZInt ENABLE_SUPPLIER_FLAG
        {
            get { return m_iENABLE_SUPPLIER_FLAG; }
            set
            {
                if (value == null)
                    m_iENABLE_SUPPLIER_FLAG.Value = value;
                else
                    m_iENABLE_SUPPLIER_FLAG = value;
            }
        }
        /// <summary>
        /// adjust, stock taking
        /// </summary>
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Int32, "ENABLE_LOT_FLAG", 10, 0, 4)]
        public NZInt ENABLE_LOT_FLAG
        {
            get { return m_iENABLE_LOT_FLAG; }
            set
            {
                if (value == null)
                    m_iENABLE_LOT_FLAG.Value = value;
                else
                    m_iENABLE_LOT_FLAG = value;
            }
        }
        /// <summary>
        /// adjust, stock taking
        /// </summary>
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Int32, "ENABLE_PACK_FLAG", 10, 0, 4)]
        public NZInt ENABLE_PACK_FLAG
        {
            get { return m_iENABLE_PACK_FLAG; }
            set
            {
                if (value == null)
                    m_iENABLE_PACK_FLAG.Value = value;
                else
                    m_iENABLE_PACK_FLAG = value;
            }
        }
        /// <summary>
        /// production report
        /// </summary>
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Int32, "ENABLE_CUST_LOT_FLAG", 10, 0, 4)]
        public NZInt ENABLE_CUST_LOT_FLAG
        {
            get { return m_iENABLE_CUST_LOT_FLAG; }
            set
            {
                if (value == null)
                    m_iENABLE_CUST_LOT_FLAG.Value = value;
                else
                    m_iENABLE_CUST_LOT_FLAG = value;
            }
        }
        /// <summary>
        /// move
        /// </summary>
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Int32, "NO_MOVE_FLAG", 10, 0, 4)]
        public NZInt NO_MOVE_FLAG
        {
            get { return m_iNO_MOVE_FLAG; }
            set
            {
                if (value == null)
                    m_iNO_MOVE_FLAG.Value = value;
                else
                    m_iNO_MOVE_FLAG = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Int32, "NO_PRODUCTION_REPORT_FLAG", 10, 0, 4)]
        public NZInt NO_PRODUCTION_REPORT_FLAG
        {
            get { return m_iNO_PRODUCTION_REPORT_FLAG; }
            set
            {
                if (value == null)
                    m_iNO_PRODUCTION_REPORT_FLAG.Value = value;
                else
                    m_iNO_PRODUCTION_REPORT_FLAG = value;
            }
        }

        [Field(typeof(System.Int32), typeof(NZInt), DataType.Int32, "NO_NG_CONSUMPTION_FLAG", 10, 0, 4)]
        public NZInt NO_NG_CONSUMPTION_FLAG
        {
            get { return m_iNO_NG_CONSUMPTION_FLAG; }
            set
            {
                if (value == null)
                    m_iNO_NG_CONSUMPTION_FLAG.Value = value;
                else
                    m_iNO_NG_CONSUMPTION_FLAG = value;
            }
        }

        [Field(typeof(System.Int32), typeof(NZInt), DataType.Int32, "LOT_CONTROL_FLAG", 10, 0, 4)]
        public NZInt LOT_CONTROL_FLAG
        {
            get { return m_iLOT_CONTROL_FLAG; }
            set
            {
                if (value == null)
                    m_iLOT_CONTROL_FLAG.Value = value;
                else
                    m_iLOT_CONTROL_FLAG = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Int32, "CHECK_DUPLICATE_LOT_FLAG", 10, 0, 4)]
        public NZInt CHECK_DUPLICATE_LOT_FLAG {
            get { return m_iCHECK_DUPLICATE_LOT_FLAG; }
            set {
                if (value == null)
                    m_iLOT_CONTROL_FLAG.Value = value;
                else
                    m_iLOT_CONTROL_FLAG = value;
            }
        }
        #endregion

        #region " Overriden method "
        /// <summary>
        /// Return array of primary key fields.
        /// </summary>
        /// <remarks>
        /// If this table mapping has not primary key, return null value.
        /// </remarks>
        public override MapKeyValue<string, List<string>> PrimaryKey
        {
            get
            {
                List<string> values = new List<string>();

                //Add MemberColums of PrimaryKey
                values.Add(eColumns.LOC_CD.ToString());

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("PK_TB_DEALING_CONSTRAINT_MS", values);
            }
        }
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			DealingConstraintDTO dto = new DealingConstraintDTO();
			dto.LOC_CD = 
			dto.NO_CONSUMPTION_FLAG = 
			dto.COMPONENT_ITEM_USAGE = 
			dto.ENABLE_SUPPLIER_FLAG = 
			dto.ENABLE_LOT_FLAG = 
			dto.ENABLE_PACK_FLAG = 
			dto.ENABLE_CUST_LOT_FLAG = 
			dto.NO_MOVE_FLAG = 
			dto.NO_PRODUCTION_REPORT_FLAG = 
		}
		*/
        #endregion
    }
}

