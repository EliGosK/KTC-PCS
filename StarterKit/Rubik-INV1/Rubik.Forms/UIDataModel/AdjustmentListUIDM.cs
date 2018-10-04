using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Data;
using EVOFramework;

namespace Rubik.UIDataModel
{
    public class AdjustmentListUIDM : IUIDataModel
    {
        private NZString m_ADJUST_TYPE = new NZString();
        private NZString m_REF_FROM = new NZString();
        private NZString m_REF_TO = new NZString();
        private NZDateTime m_ADJUST_DATE_FROM = new NZDateTime();
        private NZDateTime m_ADJUST_DATE_TO = new NZDateTime();
        private NZString m_ITEM_CODE = new NZString();
        private NZString m_ITEM_DESC = new NZString();
        private NZString m_STOCK_CODE = new NZString();
        private NZString m_LOT_NO = new NZString();


        public NZString ADJUST_TYPE
        {
            get { return m_ADJUST_TYPE; }
            set { m_ADJUST_TYPE = value; }
        }

        public NZString REF_FROM {
            get { return m_REF_FROM; }
            set { m_REF_FROM = value; }
        }

        public NZString REF_TO {
            get { return m_REF_TO; }
            set { m_REF_TO = value; }
        }

        public NZDateTime ADJUST_DATE_FROM {
            get { return m_ADJUST_DATE_FROM; }
            set { m_ADJUST_DATE_FROM = value; }
        }

        public NZDateTime ADJUST_DATE_TO {
            get { return m_ADJUST_DATE_TO; }
            set { m_ADJUST_DATE_TO = value; }
        }

        public NZString ITEM_CODE {
            get { return m_ITEM_CODE; }
            set { m_ITEM_CODE = value; }
        }

        public NZString ITEM_DESC {
            get { return m_ITEM_DESC; }
            set { m_ITEM_DESC = value; }
        }

        public NZString STOCK_CODE {
            get { return m_STOCK_CODE; }
            set { m_STOCK_CODE = value; }
        }

        public NZString LOT_NO {
            get { return m_LOT_NO; }
            set { m_LOT_NO = value; }
        }
    }
}
