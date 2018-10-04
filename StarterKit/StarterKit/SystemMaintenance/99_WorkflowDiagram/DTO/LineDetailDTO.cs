using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkFlowDiagram.DTO
{
    internal class LineDetailDTO
    {
        private string m_WF_ID = String.Empty;
        private string m_ID = String.Empty;
        private int m_SEQ = 0;
        private int m_FROM_ROW = 0;
        private int m_FROM_COL = 0;
        private int m_TO_ROW = 0;
        private int m_TO_COL = 0;
        private int m_STATUS = 0;

        public LineDetailDTO() {
        }

        public LineDetailDTO(string WF_ID, string ID, int SEQ) {
            this.WF_ID = WF_ID;
            this.ID = ID;
            this.SEQ = SEQ;
        }

        public string WF_ID {
            get { return m_WF_ID; }
            set { m_WF_ID = value; }
        }

        public int SEQ {
            get { return m_SEQ; }
            set { m_SEQ = value; }
        }

        public int FROM_ROW {
            get { return m_FROM_ROW; }
            set { m_FROM_ROW = value; }
        }

        public int FROM_COL {
            get { return m_FROM_COL; }
            set { m_FROM_COL = value; }
        }

        public int TO_ROW {
            get { return m_TO_ROW; }
            set { m_TO_ROW = value; }
        }

        public int TO_COL {
            get { return m_TO_COL; }
            set { m_TO_COL = value; }
        }

        public int STATUS {
            get { return m_STATUS; }
            set { m_STATUS = value; }
        }

        public string ID {
            get { return m_ID; }
            set { m_ID = value; }
        }
    }
}
