using System;
using System.Collections.Generic;
using System.Drawing;


namespace WorkFlowDiagram
{
    internal class WorkflowLineHeader {
        private Workflow m_parent = null;

        private string m_ID = String.Empty;
        private int m_zIndex = 0;
        private readonly List<WorkflowLineDetail> m_lines = new List<WorkflowLineDetail>();
        private readonly List<WorkflowLineConnector> m_connectors = new List<WorkflowLineConnector>();


        public WorkflowLineHeader(Workflow parent, string ID, int zIndex) {
            Parent = parent;
            this.ID = ID;
            m_zIndex = zIndex;
        }


        #region "  Properties  "
        /// <summary>
        /// Get or set WorkFlow parent.
        /// </summary>
        public Workflow Parent {
            get { return m_parent; }
            set { m_parent = value; }
        }

        /// <summary>
        /// Get list of lines.
        /// </summary>
        public List<WorkflowLineDetail> Lines {
            get { return m_lines; }
        }

        /// <summary>
        /// Get or set unique Line ID.
        /// </summary>
        public int ZIndex {
            get { return m_zIndex; }
            set { m_zIndex = value; }
        }

        /// <summary>
        /// Get or set line ID.
        /// </summary>
        public string ID {
            get { return m_ID; }
            set { m_ID = value; }
        }

        /// <summary>
        /// Get list of connector.
        /// </summary>
        public List<WorkflowLineConnector> Connectors {
            get { return m_connectors; }
        }

        #endregion

        #region "  Public method  "
        
        /// <summary>
        /// Get line which status is EndPoint.
        /// If not found will return NULL.
        /// </summary>
        /// <returns></returns>
        public WorkflowLineDetail GetLineEndPoint() {
            for (int i=0; i<m_lines.Count; i++) {
                if (m_lines[i].Status == WorkflowLineStatus.EndPoint)
                    return m_lines[i];
            }

            return null;
        }               

        /// <summary>
        /// Get max index Row and Column of line deatil.
        /// </summary>
        /// <returns></returns>
        public Cell FindMaxRowColumnIndex()
        {
            Cell cell = new Cell(Parent, 0, 0);

            // Find in Line detail.
            for (int i=0; i<Lines.Count; i++) {
                if (i == 0) {
                    cell.RowIndex = Lines[i].FromCell.RowIndex;
                    cell.ColumnIndex = Lines[i].FromCell.ColumnIndex;
                }

                cell.RowIndex = Math.Max(cell.RowIndex, Lines[i].ToCell.RowIndex);
                cell.ColumnIndex = Math.Max(cell.ColumnIndex, Lines[i].ToCell.ColumnIndex);
            }

            // Find in Connector
            for (int i=0; i<Connectors.Count; i++) {
                cell.RowIndex = Math.Max(cell.RowIndex, Connectors[i].Cell.RowIndex);
                cell.ColumnIndex = Math.Max(cell.ColumnIndex, Connectors[i].Cell.ColumnIndex);
            }

            return cell;
        }

        public override string ToString()
        {
            return String.Format("Z-Index: {0}, Lines count: {1}", ZIndex, Lines.Count);
        }
        #endregion
    }

    /// <summary>
    /// Model of workflow line.
    /// </summary>
    internal class WorkflowLineDetail
    {

        private WorkflowLineHeader m_lineHeader = null;
        private Cell m_fromCell = null;
        private Cell m_toCell = null;        
        private WorkflowLineStatus m_status = WorkflowLineStatus.Straight;

        #region "  Constructor  "
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public WorkflowLineDetail(WorkflowLineHeader parent,  Cell from, Cell to, WorkflowLineStatus status) {
            this.m_lineHeader = parent;
            FromCell = from;
            ToCell = to;
            m_status = status;
        }
        #endregion

        #region "  Properties  "
        /// <summary>
        /// Get or set start point of line.
        /// </summary>
        public Cell FromCell {
            get {
                if (m_fromCell == null)
                    throw new NullReferenceException("From point is null");

                return m_fromCell;
            }
            set { m_fromCell = value; }
        }

        /// <summary>
        /// Get or set end of line.
        /// </summary>
        public Cell ToCell {
            get {
                if (m_fromCell == null)
                    throw new NullReferenceException("To point is null");

                return m_toCell;
            }
            set { m_toCell = value; }
        }

        /// <summary>
        /// Get or set status of line.
        /// </summary>
        public WorkflowLineStatus Status {
            get { return m_status; }
            set { m_status = value; }
        }

        public WorkflowLineHeader LineHeader {
            get { return m_lineHeader; }
            //set { m_lineHeader = value; }
        }
        #endregion

        #region "  Public method  "
        /// <summary>
        /// Get line direction. It compute from FromCell to ToCell
        /// </summary>
        /// <returns></returns>
        public WorkflowLineDirection GetLineDirection() {
            // Check horizontal direction (Left of Right)
            if (FromCell.RowIndex == ToCell.RowIndex) {
                if (FromCell.ColumnIndex < ToCell.ColumnIndex) {
                    return WorkflowLineDirection.RIGHT;
                } 
                else
                {
                    return WorkflowLineDirection.LEFT;
                }
            } else {
                if (FromCell.RowIndex < ToCell.RowIndex) {
                    return WorkflowLineDirection.BOTTOM;
                } else {
                    return WorkflowLineDirection.TOP;
                }
            }
        }
        #endregion

        public override string ToString()
        {
            return String.Format("WorkFlow ID: {0}, FromCell: {1}, ToCell: {2}", LineHeader.ID,
                                 this.FromCell.ToString(), this.ToCell.ToString());
        }
        
    }

    /// <summary>
    /// Model of connector between line.
    /// </summary>
    internal class WorkflowLineConnector {
        private WorkflowLineHeader m_lineHeader = null;
        private Cell m_cell = null;
        private WorkflowConnectorType m_connectorType = WorkflowConnectorType.None;     

        public WorkflowLineConnector(WorkflowLineHeader parent, Cell cell, WorkflowConnectorType connectorType) {
            m_lineHeader = parent;
            m_cell = cell;
            m_connectorType = connectorType;
        }

        #region "  Properties  "
        public WorkflowLineHeader LineHeader {
            get { return m_lineHeader; }
            //set { m_lineHeader = value; }
        }

        public Cell Cell {
            get { return m_cell; }
            set { m_cell = value; }
        }

        public WorkflowConnectorType ConnectorType {
            get { return m_connectorType; }
            set { m_connectorType = value; }
        }
        #endregion

        public override string ToString()
        {
            return String.Format("Cell: {0}, Type: {1}", Cell.ToString(), ConnectorType.ToString());
        }
    }

}
