using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;

namespace Rubik.UIDataModel
{
    public class BOMRegisterUIDM : ItemUIDM
    {
        #region " Variables "
        private NZInt m_UPPER_QTY = new NZInt();
        private NZInt m_LOWER_QTY = new NZInt();
        private NZString m_CHILD_ORDER_LOC_CD = new NZString();
        private NZString m_MRP_FLAG = new NZString();
        #endregion


        public NZInt UPPER_QTY
        {
            get { return m_UPPER_QTY; }
            set
            {
                if (value == null)
                    m_UPPER_QTY.Value = value;
                else
                    m_UPPER_QTY = value;
            }
        }

        public NZInt LOWER_QTY
        {
            get { return m_LOWER_QTY; }
            set
            {
                if (value == null)
                    m_LOWER_QTY.Value = value;
                else
                    m_LOWER_QTY = value;
            }
        }

        public NZString CHILD_ORDER_LOC_CD
        {
            get { return m_CHILD_ORDER_LOC_CD; }
            set
            {
                if (value == null)
                    m_CHILD_ORDER_LOC_CD.Value = value;
                else
                    m_CHILD_ORDER_LOC_CD = value;
            }
        }

        public NZString MRP_FLAG
        {
            get { return m_MRP_FLAG; }
            set
            {
                if (value == null)
                    m_MRP_FLAG.Value = value;
                else
                    m_MRP_FLAG = value;
            }
        }
    }
}
