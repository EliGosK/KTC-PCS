using System.Windows.Forms;

namespace WorkFlowDiagram
{
    public class WorkflowColumnStyle : ColumnStyle
    {        
        private WorkflowColumnType m_columnType = WorkflowColumnType.Space;

        public WorkflowColumnStyle(SizeType sizeType) : base(sizeType) {
            m_columnType = WorkflowColumnType.Space;
        }

        public WorkflowColumnStyle(SizeType sizeType, WorkflowColumnType columnType) : base(sizeType) {
            m_columnType = columnType;
        }

        public WorkflowColumnType ColumnType {
            get { return m_columnType; }
            set { m_columnType = value; }
        }
    }
}
