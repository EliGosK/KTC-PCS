using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkFlowDiagram.DTO
{
    internal class LineHeaderDTO
    {
        private string m_WF_ID = String.Empty;
        private string m_ID = String.Empty;
        private int m_ZINDEX = 0;
        private string m_REMARK = String.Empty;

        public LineHeaderDTO() {
        }

        public LineHeaderDTO(string WF_ID, string ID, int ZINDEX) {
            this.WF_ID = WF_ID;
            this.ID = ID;
            this.ZINDEX = ZINDEX;
        }

        public string WF_ID {
            get { return m_WF_ID; }
            set { m_WF_ID = value; }
        }

        public int ZINDEX {
            get { return m_ZINDEX; }
            set { m_ZINDEX = value; }
        }

        public string REMARK {
            get { return m_REMARK; }
            set { m_REMARK = value; }
        }

        public string ID {
            get { return m_ID; }
            set { m_ID = value; }
        }
    }
}
