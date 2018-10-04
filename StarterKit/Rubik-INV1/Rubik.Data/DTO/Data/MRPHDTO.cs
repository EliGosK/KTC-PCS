/*
 *		Author: 
 *      Team : SI-EVO
 * 		Writed On 2554/06/23
 * 		Time : 10:49 AM
 *  	This is DTO for TB_MRP_H_TR Table.
 *		From Templates Version : 
 *		Last Modify Template On : 
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
    [DataTransferObject("TB_MRP_H_TR", typeof(eColumns))]
    public class MRPHDTO : AbstractDTO
    {
        #region " Enums Columns "
        public enum eColumns
        {
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE,
            IS_ACTIVE,
            MRP_NO,
            ITEM_CD,
            ORDER_LOC_CD,
            REVISION_NO,
            ITEM_CLS,
            ITEM_DESC,
            ORDER_PROCESS_CLS,
            LOT_SIZE,
            REORDER_POINT,
            SAFETY_STOCK,
            MINIMUM_ORDER,
            INV_UM_CLS,
            ORDER_UM_CLS,
            INV_UM_RATE,
            ORDER_UM_RATE,
            MAX_CAPACITY,
            LEADTIME,
            SAFETY_LEADTIME,
            MRP_FLAG,
            ORDER_CONDITION
        };
        #endregion

        #region " Variables "
        private NZString m_strCRT_BY = new NZString();
        private NZDateTime m_dtCRT_DATE = new NZDateTime();
        private NZString m_strCRT_MACHINE = new NZString();
        private NZString m_strUPD_BY = new NZString();
        private NZDateTime m_dtUPD_DATE = new NZDateTime();
        private NZString m_strUPD_MACHINE = new NZString();
        private NZDecimal m_dIS_ACTIVE = new NZDecimal();
        private NZString m_strMRP_NO = new NZString();
        private NZString m_strITEM_CD = new NZString();
        private NZString m_strORDER_LOC_CD = new NZString();
        private NZDecimal m_dREVISION_NO = new NZDecimal();
        private NZString m_strITEM_CLS = new NZString();
        private NZString m_strITEM_DESC = new NZString();
        private NZString m_strORDER_PROCESS_CLS = new NZString();
        private NZDecimal m_dLOT_SIZE = new NZDecimal();
        private NZDecimal m_dREORDER_POINT = new NZDecimal();
        private NZDecimal m_dSAFETY_STOCK = new NZDecimal();
        private NZDecimal m_dMINIMUM_ORDER = new NZDecimal();
        private NZString m_strINV_UM_CLS = new NZString();
        private NZString m_strORDER_UM_CLS = new NZString();
        private NZDecimal m_dINV_UM_RATE = new NZDecimal();
        private NZDecimal m_dORDER_UM_RATE = new NZDecimal();
        private NZDecimal m_dMAX_CAPACITY = new NZDecimal();
        private NZDecimal m_dLEADTIME = new NZDecimal();
        private NZDecimal m_dSAFETY_LEADTIME = new NZDecimal();
        private NZString m_strMRP_FLAG = new NZString();
        private NZString m_strORDER_CONDITION = new NZString();
        #endregion

        #region " Constructor "

        #endregion

        #region " Getter and Setter properties "
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CRT_BY", 0, 0, 15)]
        public NZString CRT_BY
        {
            get { return m_strCRT_BY; }
            set
            {
                if (value == null)
                    m_strCRT_BY.Value = value;
                else
                    m_strCRT_BY = value;
            }
        }
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "CRT_DATE", 23, 3, 8)]
        public NZDateTime CRT_DATE
        {
            get { return m_dtCRT_DATE; }
            set
            {
                if (value == null)
                    m_dtCRT_DATE.Value = value;
                else
                    m_dtCRT_DATE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CRT_MACHINE", 0, 0, 50)]
        public NZString CRT_MACHINE
        {
            get { return m_strCRT_MACHINE; }
            set
            {
                if (value == null)
                    m_strCRT_MACHINE.Value = value;
                else
                    m_strCRT_MACHINE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UPD_BY", 0, 0, 15)]
        public NZString UPD_BY
        {
            get { return m_strUPD_BY; }
            set
            {
                if (value == null)
                    m_strUPD_BY.Value = value;
                else
                    m_strUPD_BY = value;
            }
        }
        [Field(typeof(System.DateTime), typeof(NZDateTime), DataType.DateTime, "UPD_DATE", 23, 3, 8)]
        public NZDateTime UPD_DATE
        {
            get { return m_dtUPD_DATE; }
            set
            {
                if (value == null)
                    m_dtUPD_DATE.Value = value;
                else
                    m_dtUPD_DATE = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UPD_MACHINE", 0, 0, 50)]
        public NZString UPD_MACHINE
        {
            get { return m_strUPD_MACHINE; }
            set
            {
                if (value == null)
                    m_strUPD_MACHINE.Value = value;
                else
                    m_strUPD_MACHINE = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "IS_ACTIVE", 1, 0, 5)]
        public NZDecimal IS_ACTIVE
        {
            get { return m_dIS_ACTIVE; }
            set
            {
                if (value == null)
                    m_dIS_ACTIVE.Value = value;
                else
                    m_dIS_ACTIVE = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "MRP_NO", 0, 0, 30)]
        public NZString MRP_NO
        {
            get { return m_strMRP_NO; }
            set
            {
                if (value == null)
                    m_strMRP_NO.Value = value;
                else
                    m_strMRP_NO = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ITEM_CD", 0, 0, 35)]
        public NZString ITEM_CD
        {
            get { return m_strITEM_CD; }
            set
            {
                if (value == null)
                    m_strITEM_CD.Value = value;
                else
                    m_strITEM_CD = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ORDER_LOC_CD", 0, 0, 20)]
        public NZString ORDER_LOC_CD
        {
            get { return m_strORDER_LOC_CD; }
            set
            {
                if (value == null)
                    m_strORDER_LOC_CD.Value = value;
                else
                    m_strORDER_LOC_CD = value;
            }
        }
        /// <summary>
        /// Number of Update (only keep 1 revision)
        /// </summary>
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "REVISION_NO", 16, 0, 9)]
        public NZDecimal REVISION_NO
        {
            get { return m_dREVISION_NO; }
            set
            {
                if (value == null)
                    m_dREVISION_NO.Value = value;
                else
                    m_dREVISION_NO = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ITEM_CLS", 0, 0, 5)]
        public NZString ITEM_CLS
        {
            get { return m_strITEM_CLS; }
            set
            {
                if (value == null)
                    m_strITEM_CLS.Value = value;
                else
                    m_strITEM_CLS = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ITEM_DESC", 0, 0, 50)]
        public NZString ITEM_DESC
        {
            get { return m_strITEM_DESC; }
            set
            {
                if (value == null)
                    m_strITEM_DESC.Value = value;
                else
                    m_strITEM_DESC = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ORDER_PROCESS_CLS", 0, 0, 30)]
        public NZString ORDER_PROCESS_CLS
        {
            get { return m_strORDER_PROCESS_CLS; }
            set
            {
                if (value == null)
                    m_strORDER_PROCESS_CLS.Value = value;
                else
                    m_strORDER_PROCESS_CLS = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "LOT_SIZE", 13, 6, 9)]
        public NZDecimal LOT_SIZE
        {
            get { return m_dLOT_SIZE; }
            set
            {
                if (value == null)
                    m_dLOT_SIZE.Value = value;
                else
                    m_dLOT_SIZE = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "REORDER_POINT", 16, 4, 9)]
        public NZDecimal REORDER_POINT
        {
            get { return m_dREORDER_POINT; }
            set
            {
                if (value == null)
                    m_dREORDER_POINT.Value = value;
                else
                    m_dREORDER_POINT = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "SAFETY_STOCK", 16, 4, 9)]
        public NZDecimal SAFETY_STOCK
        {
            get { return m_dSAFETY_STOCK; }
            set
            {
                if (value == null)
                    m_dSAFETY_STOCK.Value = value;
                else
                    m_dSAFETY_STOCK = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "MINIMUM_ORDER", 16, 4, 9)]
        public NZDecimal MINIMUM_ORDER
        {
            get { return m_dMINIMUM_ORDER; }
            set
            {
                if (value == null)
                    m_dMINIMUM_ORDER.Value = value;
                else
                    m_dMINIMUM_ORDER = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "INV_UM_CLS", 0, 0, 5)]
        public NZString INV_UM_CLS
        {
            get { return m_strINV_UM_CLS; }
            set
            {
                if (value == null)
                    m_strINV_UM_CLS.Value = value;
                else
                    m_strINV_UM_CLS = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ORDER_UM_CLS", 0, 0, 5)]
        public NZString ORDER_UM_CLS
        {
            get { return m_strORDER_UM_CLS; }
            set
            {
                if (value == null)
                    m_strORDER_UM_CLS.Value = value;
                else
                    m_strORDER_UM_CLS = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "INV_UM_RATE", 16, 6, 9)]
        public NZDecimal INV_UM_RATE
        {
            get { return m_dINV_UM_RATE; }
            set
            {
                if (value == null)
                    m_dINV_UM_RATE.Value = value;
                else
                    m_dINV_UM_RATE = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "ORDER_UM_RATE", 16, 6, 9)]
        public NZDecimal ORDER_UM_RATE
        {
            get { return m_dORDER_UM_RATE; }
            set
            {
                if (value == null)
                    m_dORDER_UM_RATE.Value = value;
                else
                    m_dORDER_UM_RATE = value;
            }
        }
        /// <summary>
        /// Maximum Capacity Per Leadtime
        /// </summary>
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "MAX_CAPACITY", 16, 4, 9)]
        public NZDecimal MAX_CAPACITY
        {
            get { return m_dMAX_CAPACITY; }
            set
            {
                if (value == null)
                    m_dMAX_CAPACITY.Value = value;
                else
                    m_dMAX_CAPACITY = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "LEADTIME", 16, 4, 9)]
        public NZDecimal LEADTIME
        {
            get { return m_dLEADTIME; }
            set
            {
                if (value == null)
                    m_dLEADTIME.Value = value;
                else
                    m_dLEADTIME = value;
            }
        }
        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Number, "SAFETY_LEADTIME", 5, 0, 5)]
        public NZDecimal SAFETY_LEADTIME
        {
            get { return m_dSAFETY_LEADTIME; }
            set
            {
                if (value == null)
                    m_dSAFETY_LEADTIME.Value = value;
                else
                    m_dSAFETY_LEADTIME = value;
            }
        }
        /// <summary>
        /// Flag 01 : Do Cal Cal MRP, 02 : Release Order By Manual, 03 : Release Order
        /// </summary>
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "MRP_FLAG", 0, 0, 5)]
        public NZString MRP_FLAG
        {
            get { return m_strMRP_FLAG; }
            set
            {
                if (value == null)
                    m_strMRP_FLAG.Value = value;
                else
                    m_strMRP_FLAG = value;
            }
        }
        /// <summary>
        /// Release Order By[Daily, Monthly Weekly]
        /// </summary>
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ORDER_CONDITION", 0, 0, 5)]
        public NZString ORDER_CONDITION
        {
            get { return m_strORDER_CONDITION; }
            set
            {
                if (value == null)
                    m_strORDER_CONDITION.Value = value;
                else
                    m_strORDER_CONDITION = value;
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
                values.Add(eColumns.MRP_NO.ToString());
                values.Add(eColumns.ITEM_CD.ToString());
                values.Add(eColumns.ORDER_LOC_CD.ToString());

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("PK_TB_MRP_H_TR", values);
            }
        }
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			MRPHDTO dto = new MRPHDTO();
			dto.CRT_BY = 
			dto.CRT_DATE = 
			dto.CRT_MACHINE = 
			dto.UPD_BY = 
			dto.UPD_DATE = 
			dto.UPD_MACHINE = 
			dto.IS_ACTIVE = 
			dto.MRP_NO = 
			dto.ITEM_CD = 
			dto.ORDER_LOC_CD = 
			dto.REVISION_NO = 
			dto.ITEM_CLS = 
			dto.ITEM_DESC = 
			dto.ORDER_PROCESS_CLS = 
			dto.LOT_SIZE = 
			dto.REORDER_POINT = 
			dto.SAFETY_STOCK = 
			dto.MINIMUM_ORDER = 
			dto.INV_UM_CLS = 
			dto.ORDER_UM_CLS = 
			dto.INV_UM_RATE = 
			dto.ORDER_UM_RATE = 
			dto.MAX_CAPACITY = 
			dto.LEADTIME = 
			dto.SAFETY_LEADTIME = 
			dto.MRP_FLAG = 
			dto.ORDER_CONDITION = 
		}
		*/
        #endregion
    }
}

