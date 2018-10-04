/*
 *		Author: Mr.Teerayut S
 *      Team : SI-EVO
 * 		Writed On 2010/06/21
 * 		Time : 05:18 PM
 *  	This is DTO for TB_ITEM_MS Table.
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
    [DataTransferObject("TB_BOM_MS", typeof(eColumns))]
    public class ItemComponentDTO : AbstractDTO
    {
        #region " Enums Columns "
        public enum eColumns
        {
            SEQ_NO,
            ITEM_CD,
            SHORT_NAME,
            CUSTOMER_CD,
            PCS,
            OLD_DATA,
           
        };
        #endregion

        #region " Variables "

        private NZInt m_iSEQ_NO = new NZInt();


        private NZString m_strITEM_CD = new NZString();
        private NZString m_strSHORT_NAME = new NZString();
        private NZString m_strCUSTOMER_CD = new NZString();
        private NZDecimal m_iPCS = new NZDecimal();
        private NZInt m_iOLD_DATA = new NZInt();
        #endregion

        #region " Constructor "

        #endregion

        #region " Getter and Setter properties "
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Int32, "SEQ_NO", 10, 0, 0)]
        public NZInt SEQ_NO
        {
            get { return m_iSEQ_NO; }
            set { m_iSEQ_NO = value; }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ITEM_CD", 0, 0, 30)]
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
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "SHORT_NAME", 0, 0, 50)]
        public NZString SHORT_NAME
        {
            get { return m_strSHORT_NAME; }
            set
            {
                if (value == null)
                    m_strSHORT_NAME.Value = value;
                else
                    m_strSHORT_NAME = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "CUSTOMER_CD", 0, 0, 30)]
        public NZString CUSTOMER_CD
        {
            get { return m_strCUSTOMER_CD; }
            set
            {
                if (value == null)
                    m_strCUSTOMER_CD.Value = value;
                else
                    m_strCUSTOMER_CD = value;
            }
        }

        [Field(typeof(System.Decimal), typeof(NZDecimal), DataType.Default, "PCS", 10, 0, 4)]
        public NZDecimal PCS
        {
            get { return m_iPCS; }
            set
            {
                if (value == null)
                    m_iPCS.Value = value;
                else
                    m_iPCS = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Default, "OLD_DATA", 10, 0, 4)]
        public NZInt OLD_DATA
        {
            get { return m_iOLD_DATA; }
            set
            {
                if (value == null)
                    m_iOLD_DATA.Value = value;
                else
                    m_iOLD_DATA = value;
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
        //public override MapKeyValue<string, List<string>> PrimaryKey
        //{
        //    get
        //    {
        //        List<string> values = new List<string>();

        //        //Add MemberColums of PrimaryKey
        //        values.Add(eColumns.ITEM_CD.ToString());

        //        //Add PrimaryKey Name
        //        return new MapKeyValue<string, List<string>>("PK_TB_ITEM_MS", values);
        //    }
        //}

        public override MapKeyValue<string, List<string>> PrimaryKey
        {
            get
            {
                return null;
            }
        }

        public override Map<string, List<string>> UniqueKeys
        {
            get
            {
                return null;
            }
        }
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			ItemDTO dto = new ItemDTO();
			dto.CRT_BY = 
			dto.CRT_DATE = 
			dto.CRT_MACHINE = 
			dto.UPD_BY = 
			dto.UPD_DATE = 
			dto.UPD_MACHINE = 
			dto.ITEM_CD = 
			dto.SHORT_NAME = 
			dto.ITEM_DESC = 
			dto.KIND_OF_PRODUCT = 
			dto.CUSTOMER_CD = 
			dto.CUSTOMER_USE_POINT = 
			dto.WEIGHT = 
			dto.BOI = 
			dto.PRODUCTION_DI = 
			dto.ITEM_LEVEL = 
			dto.MAT_NAME = 
			dto.MAT_SIZE = 
			dto.MAT_SUPPLIER_CD = 
			dto.KIND_OF_MAT = 
			dto.MAT_DI = 
			dto.REMARK = 
			dto.SCREW_KIND = 
			dto.SCREW_HEAD = 
			dto.SCREW_M = 
			dto.SCREW_L = 
			dto.SCREW_TYPE = 
			dto.SCREW_REMARK1 = 
			dto.SCREW_REMARK2 = 
			dto.HEXABULAR = 
			dto.HEAT_FLAG = 
			dto.HEAT_TYPE = 
			dto.HEAT_HARDNESS = 
			dto.HEAT_CORE_HARDNESS = 
			dto.HEAT_CASE_DEPTH = 
			dto.PLATING_FLAG = 
			dto.PLATING_KIND = 
			dto.PLATING_SUPPLIER_CD = 
			dto.PLATING_THICKNESS1_1 = 
			dto.PLATING_THICKNESS1_2 = 
			dto.PLATING_THICKNESS2_1 = 
			dto.PLATING_THICKNESS2_2 = 
			dto.PLATING_KTC = 
			dto.BAKING_FLAG = 
			dto.BAKING_TIME = 
			dto.BAKING_TEMP = 
			dto.OTHER_TREATMENT1_FLAG = 
			dto.OTHER_TREATMENT1_KIND = 
			dto.OTHER_TREATMENT1_CONDITION = 
			dto.OTHER_TREATMENT2_FLAG = 
			dto.OTHER_TREATMENT2_KIND = 
			dto.OTHER_TREATMENT2_CONDITION = 
			dto.OLD_DATA = 
		}
		*/
        #endregion
    }
}

