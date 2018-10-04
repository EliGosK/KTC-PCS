using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EVOFramework.Database;

namespace WorkFlowDiagram
{
    internal class WorkflowRowStyle :RowStyle
    {
        private WorkflowRowType m_rowType = WorkflowRowType.Space;
        
        #region "  Constructor  "
        public WorkflowRowStyle(SizeType sizeType) : base(sizeType) {
            m_rowType = WorkflowRowType.Space;
        }
        public WorkflowRowStyle(SizeType sizeType, WorkflowRowType rowType)
            : base(sizeType)
        {
            m_rowType = rowType;            
        }
        #endregion

        #region "  Properties  "
        public WorkflowRowType ColumnType
        {
            get { return m_rowType; }
            set { m_rowType = value; }
        }
        #endregion
    }
}
