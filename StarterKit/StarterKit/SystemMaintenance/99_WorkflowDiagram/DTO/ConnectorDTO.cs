using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkFlowDiagram.DTO
{
    internal class ConnectorDTO
    {
        private string m_WF_ID = String.Empty;
        private string m_LINE_ID = String.Empty;
        private int m_ROW_INDEX = 0;
        private int m_COL_INDEX = 0;
        private int m_STATUS = 0;


        public string WF_ID {
            get { return m_WF_ID; }
            set { m_WF_ID = value; }
        }

        public string LINE_ID {
            get { return m_LINE_ID; }
            set { m_LINE_ID = value; }
        }

        public int ROW_INDEX {
            get { return m_ROW_INDEX; }
            set { m_ROW_INDEX = value; }
        }

        public int COL_INDEX {
            get { return m_COL_INDEX; }
            set { m_COL_INDEX = value; }
        }

        public int STATUS {
            get { return m_STATUS; }
            set { m_STATUS = value; }
        }
    }
}
