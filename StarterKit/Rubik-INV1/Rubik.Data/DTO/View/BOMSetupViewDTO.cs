using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Database;

namespace Rubik.DTO
{
    [Serializable()]
    [DataTransferObject("TB_BOM_MS", typeof(eColumns))]
    public class BOMSetupViewDTO : BOMSetupDTO
    {
        public new enum eColumns
        {
            UPPER_ITEM_CD,
            LOWER_ITEM_CD,
            LEVEL,
            PATH,
            SEQ,
            UPPER_QTY,
            LOWER_QTY,
            UPPER_ITEM_DESC,
            LOWER_ITEM_DESC,
            UPPER_ITEM_CLS,
            LOWER_ITEM_CLS,
            UPPER_LOT_CONTROL_CLS,
            LOWER_LOT_CONTROL_CLS,
            UPPER_CONSUMTION_CLS,
            LOWER_CONSUMTION_CLS,
            CHILD_ORDER_LOC_CD,
            MRP_FLAG
        }

        private NZString m_UPPER_ITEM_DESC = new NZString();
        private NZString m_LOWER_ITEM_DESC = new NZString();
        private NZString m_UPPER_ITEM_CLS = new NZString();
        private NZString m_LOWER_ITEM_CLS = new NZString();
        private NZString m_UPPER_LOT_CONTROL_CLS = new NZString();
        private NZString m_LOWER_LOT_CONTROL_CLS = new NZString();
        private NZString m_UPPER_CONSUMTION_CLS = new NZString();
        private NZString m_LOWER_CONSUMTION_CLS = new NZString();


        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UPPER_ITEM_DESC", 0, 0, 20)]
        public NZString UPPER_ITEM_DESC
        {
            get { return m_UPPER_ITEM_DESC; }
            set
            {
                if (value == null)
                    m_UPPER_ITEM_DESC.Value = value;
                else
                    m_UPPER_ITEM_DESC = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOWER_ITEM_DESC", 0, 0, 20)]
        public NZString LOWER_ITEM_DESC
        {
            get { return m_LOWER_ITEM_DESC; }
            set
            {
                if (value == null)
                    m_LOWER_ITEM_DESC.Value = value;
                else
                    m_LOWER_ITEM_DESC = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UPPER_ITEM_CLS", 0, 0, 20)]
        public NZString UPPER_ITEM_CLS
        {
            get { return m_UPPER_ITEM_CLS; }
            set
            {
                if (value == null)
                    m_UPPER_ITEM_CLS.Value = value;
                else
                    m_UPPER_ITEM_CLS = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOWER_ITEM_CLS", 0, 0, 20)]
        public NZString LOWER_ITEM_CLS
        {
            get { return m_LOWER_ITEM_CLS; }
            set
            {
                if (value == null)
                    m_LOWER_ITEM_CLS.Value = value;
                else
                    m_LOWER_ITEM_CLS = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UPPER_LOT_CONTROL_CLS", 0, 0, 20)]
        public NZString UPPER_LOT_CONTROL_CLS
        {
            get { return m_UPPER_LOT_CONTROL_CLS; }
            set
            {
                if (value == null)
                    m_UPPER_LOT_CONTROL_CLS.Value = value;
                else
                    m_UPPER_LOT_CONTROL_CLS = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOWER_LOT_CONTROL_CLS", 0, 0, 20)]
        public NZString LOWER_LOT_CONTROL_CLS
        {
            get { return m_LOWER_LOT_CONTROL_CLS; }
            set
            {
                if (value == null)
                    m_LOWER_LOT_CONTROL_CLS.Value = value;
                else
                    m_LOWER_LOT_CONTROL_CLS = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "UPPER_CONSUMTION_CLS", 0, 0, 20)]
        public NZString UPPER_CONSUMTION_CLS
        {
            get { return m_UPPER_CONSUMTION_CLS; }
            set
            {
                if (value == null)
                    m_UPPER_CONSUMTION_CLS.Value = value;
                else
                    m_UPPER_CONSUMTION_CLS = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "LOWER_CONSUMTION_CLS", 0, 0, 20)]
        public NZString LOWER_CONSUMTION_CLS
        {
            get { return m_LOWER_CONSUMTION_CLS; }
            set
            {
                if (value == null)
                    m_LOWER_CONSUMTION_CLS.Value = value;
                else
                    m_LOWER_CONSUMTION_CLS = value;
            }
        }
    }
}
