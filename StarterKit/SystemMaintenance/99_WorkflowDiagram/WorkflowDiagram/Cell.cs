using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkFlowDiagram
{
    /// <summary>
    /// Represent cell on table layout.
    /// </summary>
    public class Cell
    {
        private Workflow m_parent = null;
        private int m_rowIndex = 0;
        private int m_columnIndex = 0;

        private Cell() {
        }

        internal Cell(Workflow parent, int rowIndex, int columnIndex) {
            Parent = parent;
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
        }

        internal Workflow Parent {
            get { return m_parent; }
            set { m_parent = value; }
        }

        public int RowIndex {
            get { return m_rowIndex; }
            set { m_rowIndex = value; }
        }

        public int ColumnIndex {
            get { return m_columnIndex; }
            set { m_columnIndex = value; }
        }

        public override string ToString()
        {
            return String.Format("(Row: {0}, Column: {1})", RowIndex, ColumnIndex);
        }
    }
}
