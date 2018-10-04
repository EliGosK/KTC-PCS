using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Data;

namespace WorkFlowDiagram.DTO
{
    public class ButtonDTO
    {
        private string m_WF_ID = String.Empty;
        private int m_ROW_INDEX = 0;
        private int m_COL_INDEX = 0;
        private string m_TAG1 = String.Empty;
        private string m_TAG2 = String.Empty;
        private DateTime m_CREATEDATE;
        private DateTime m_UPDATEDATE;
        private int m_FLG_VIEW;

        public ButtonDTO()
        {
        }

        public ButtonDTO(string WF_ID, int ROW_INDEX, int COL_INDEX)
        {
            this.WF_ID = WF_ID;
            this.ROW_INDEX = ROW_INDEX;
            this.COL_INDEX = COL_INDEX;
        }

        public string WF_ID
        {
            get { return m_WF_ID; }
            set { m_WF_ID = value; }
        }

        public int ROW_INDEX
        {
            get { return m_ROW_INDEX; }
            set { m_ROW_INDEX = value; }
        }

        public int COL_INDEX
        {
            get { return m_COL_INDEX; }
            set { m_COL_INDEX = value; }
        }

        public string TAG1
        {
            get { return m_TAG1; }
            set { m_TAG1 = value; }
        }

        public string TAG2
        {
            get { return m_TAG2; }
            set { m_TAG2 = value; }
        }

        public DateTime CREATEDATE
        {
            get { return m_CREATEDATE; }
            set { m_CREATEDATE = value; }
        }

        public DateTime UPDATEDATE
        {
            get { return m_UPDATEDATE; }
            set { m_UPDATEDATE = value; }
        }

        public int FLG_VIEW
        {
            get { return m_FLG_VIEW; }
            set { m_FLG_VIEW = value; }
        }
    }
}
