using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WorkFlowDiagram
{
    /// <summary>
    /// Engine for calculate and draw surface.
    /// </summary>
    internal partial class WorkflowEngine
    {
        #region "  Constant  to adjust space.  "
        internal const int VSPACE_HEIGHT = 20;
        internal const int HSPACE_WIDTH = 20;
        internal const int BUTTON_WIDTH = 100;
        internal const int BUTTON_HEIGHT = 80;
        internal const int ARROW_SPACE = 14;        
        #endregion

        #region "  Variables  "
        private Workflow m_parentWorkflow = null;
        private WorkflowButtonList m_buttonList = null;
        private WorkflowLineHeaderList m_lineHeaderList = null;

        /// <summary>
        /// เก็บรายการของเส้นที่จะกลายเป็นลูกศรชี้ไปยังปุ่ม Button
        /// </summary>
        private readonly List<WorkflowLineDetail> m_lineEndPoint = new List<WorkflowLineDetail>();       
        #endregion

        #region "  Constructor  "
        public WorkflowEngine(Workflow parent) {
            ParentWorkflow = parent;            
        }
        #endregion

        #region "  Properties  "
        public Workflow ParentWorkflow {
            get { return m_parentWorkflow; }
            set { m_parentWorkflow = value; }
        }

        public WorkflowButtonList ButtonList {
            get { return m_buttonList; }
            set { m_buttonList = value; }
        }

        public WorkflowLineHeaderList LineHeaderList {
            get { return m_lineHeaderList; }
            set { m_lineHeaderList = value; }
        }

        #endregion

        #region "  Public method  "
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buttons"></param>
        /// <param name="lineHeaders"></param>
        public void StartGenerateWorkflow(WorkflowButtonList buttons, WorkflowLineHeaderList lineHeaders) {
#warning Please remove: TableLayout show cell border.
            //ParentWorkflow.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            ButtonList = buttons;
            LineHeaderList = lineHeaders;            

            //== Create Button and Space cell.
            GenerateButton(buttons);

            //== Extract EndPoint line.
            m_lineEndPoint.Clear();
            m_lineEndPoint.AddRange(ExtractEndPoint(LineHeaderList));

            //== Calculate area for EndPoint
            GenerateArrowSpaceForEndPoint(m_lineEndPoint);                        
        }
        #endregion


        /// <summary>
        /// Generate Button on TableLayout with space cell type.
        /// </summary>
        /// <param name="buttons"></param>
        private void GenerateButton(WorkflowButtonList buttons) {
            if (ButtonList.Count == 0)
                return;

            int maxRow = 0;
            int maxCol = 0;

            // Find max row and column index on button list.
            Cell maxButtonCell = ButtonList.FindMaxRowColumnIndex();
            maxRow = maxButtonCell.RowIndex;
            maxCol = maxButtonCell.ColumnIndex;

            // Find max row and column index on line deatil.
            Cell maxLineCell = LineHeaderList.FindMaxRowColumnIndex();
            maxRow = Math.Max(maxRow, maxLineCell.RowIndex);
            maxCol = Math.Max(maxCol, maxLineCell.ColumnIndex);

            //== Generate Row.
            ParentWorkflow.RowCount = Math.Max(0, ((maxRow + 1) * 2) - 1);
            for (int i = 0; i < ParentWorkflow.RowCount; i++)
            {
                WorkflowRowStyle row = null;
                if (i % 2 == 0)
                {
                    // It's Button.
                    row = new WorkflowRowStyle(SizeType.Absolute, WorkflowRowType.Button);
                    row.Height = BUTTON_HEIGHT;

                }
                else
                {
                    // It's VSpace.
                    row = new WorkflowRowStyle(SizeType.Absolute, WorkflowRowType.Space);
                    row.Height = VSPACE_HEIGHT;
                }

                ParentWorkflow.RowStyles.Add(row);
            }

            //== Generate Column
            ParentWorkflow.ColumnCount = Math.Max(0, ((maxCol + 1) * 2) - 1);
            for (int i = 0; i < ParentWorkflow.ColumnCount; i++)
            {
                WorkflowColumnStyle col = null;
                if (i % 2 == 0)
                {
                    // It's Button.
                    col = new WorkflowColumnStyle(SizeType.Absolute, WorkflowColumnType.Button);
                    col.Width = BUTTON_WIDTH;
                }
                else
                {
                    // It's HSpace.
                    col = new WorkflowColumnStyle(SizeType.Absolute, WorkflowColumnType.Space);
                    col.Width = HSPACE_WIDTH;
                }

                ParentWorkflow.ColumnStyles.Add(col);
            }

            //== Put button into cell.
            for (int i = 0; i < ButtonList.Count; i++)
            {
                WorkflowButton btn = ButtonList[i];
                WorkflowButtonArgs buttonArgs = new WorkflowButtonArgs();
                buttonArgs.Data = btn.Data;

                // Raise event when button has loading.
                // User can bind event "ButtonLoad" to override our Text and Image.
                ParentWorkflow.OnButtonLoad(buttonArgs);
                btn.Text = buttonArgs.Text;
                btn.Image = buttonArgs.Image;
                btn.BackColor = Color.Transparent;
                
                // Add control into table's cell.
                Cell cell = GetIndexWorkFlowButtonCell(btn.Data.ROW_INDEX, btn.Data.COL_INDEX);
                ParentWorkflow.Controls.Add(btn, cell.ColumnIndex, cell.RowIndex);

                btn.Dock = DockStyle.Fill;
            }
        }

        /// <summary>
        /// Extract EndPoint from lines header list.
        /// </summary>
        /// <param name="lines"></param>
        private List<WorkflowLineDetail> ExtractEndPoint(WorkflowLineHeaderList lines) {
            List<WorkflowLineDetail> list = new List<WorkflowLineDetail>();
            for (int i=0; i<lines.Count; i++) {
                WorkflowLineDetail lineDetail = lines[i].GetLineEndPoint();
                if (lineDetail != null)
                    list.Add(lineDetail);
            }

            return list;
        }

        private void GenerateArrowSpaceForEndPoint(List<WorkflowLineDetail> lineEndPoints) {
            for (int i=0; i<lineEndPoints.Count(); i++) {

                WorkflowLineDetail line = lineEndPoints[i];
                WorkflowLineDirection direction = line.GetLineDirection();

                Cell cell = GetIndexWorkFlowButtonCell(line.ToCell.RowIndex, line.ToCell.ColumnIndex);

                WorkflowColumnStyle columnStyle = null;
                WorkflowRowStyle rowStyle = null;

                switch (direction) {
                    case WorkflowLineDirection.LEFT:  
                        // add space on right side of Button cell.
                        columnStyle = new WorkflowColumnStyle(SizeType.Absolute, WorkflowColumnType.DisplayArrow);
                        columnStyle.Width = ARROW_SPACE;
                                                
                        ParentWorkflow.InsertColumn(cell.ColumnIndex + 1, columnStyle);
                        break;
                    case WorkflowLineDirection.TOP:
                        // add space on bottom side of Button cell.
                        rowStyle = new WorkflowRowStyle(SizeType.Absolute, WorkflowRowType.DisplayArrow);
                        rowStyle.Height = ARROW_SPACE;
                        
                        ParentWorkflow.InsertRow(cell.RowIndex + 1, rowStyle);
                        break;
                    case WorkflowLineDirection.RIGHT:
                        // add space on left side of Button cell.
                        columnStyle = new WorkflowColumnStyle(SizeType.Absolute, WorkflowColumnType.DisplayArrow);
                        columnStyle.Width = ARROW_SPACE;

                        ParentWorkflow.InsertColumn(cell.ColumnIndex, columnStyle);
                        break;
                    case WorkflowLineDirection.BOTTOM:
                        // add space on top side of Button cell.
                        rowStyle = new WorkflowRowStyle(SizeType.Absolute, WorkflowRowType.DisplayArrow);
                        rowStyle.Height = ARROW_SPACE;

                        ParentWorkflow.InsertRow(cell.RowIndex, rowStyle);
                        break;                    
                }
            }            
        }

        /// <summary>
        /// Get Row and Column index which cell type is Button on TableLayout
        /// </summary>
        /// <param name="row">Row index of button.</param>
        /// <param name="col">Column index of button.</param>
        /// <returns></returns>
        internal Cell GetIndexWorkFlowButtonCell(int rowButton, int colButton)
        {
            int buttonRow = 0;
            int buttonCol = 0;
            int index = -1;

            //== Find Row button cell.
            for (int i = 0; i < ParentWorkflow.RowStyles.Count; i++)
            {
                WorkflowRowStyle rowStyle = ParentWorkflow.RowStyles[i] as WorkflowRowStyle;
                if (rowStyle == null)
                    throw new ArgumentException("Invalid WorkflowRowStyle");

                if (rowStyle.ColumnType == WorkflowRowType.Button)
                    index++;

                if (index == rowButton)
                {
                    buttonRow = i;
                    break;
                }
            }

            //== Find Row button cell.
            index = -1;
            for (int i = 0; i < ParentWorkflow.ColumnStyles.Count; i++)
            {
                WorkflowColumnStyle colStyle = ParentWorkflow.ColumnStyles[i] as WorkflowColumnStyle;
                if (colStyle == null)
                    throw new ArgumentException("Invalid WorkflowRowStyle");

                if (colStyle.ColumnType == WorkflowColumnType.Button)
                    index++;

                if (index == colButton)
                {
                    buttonCol = i;
                    break;
                }
            }

            return new Cell(ParentWorkflow, buttonRow, buttonCol);
        }

        /// <summary>
        /// Get rectangle of cell on TableLayout.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        internal Rectangle GetCellRectangle(Cell cell) {
            if (cell.RowIndex > ParentWorkflow.RowCount - 1 ||
                cell.ColumnIndex > ParentWorkflow.ColumnCount - 1)
                return Rectangle.Empty;

            int[] rowHeights = ParentWorkflow.GetRowHeights();
            int[] colWidths = ParentWorkflow.GetColumnWidths();

            Rectangle rect = Rectangle.Empty;
            int value = 0;
            int index = 0;
            for (int i=0; i<cell.RowIndex; i++) {
                value += rowHeights[i];
                index = i + 1;
            }
            rect.Y = value;
            rect.Height = rowHeights[index];

            value = 0;
            index = 0;
            for (int i=0; i<cell.ColumnIndex; i++) {
                value += colWidths[i];
                index = i + 1;
            }
            rect.X = value;
            rect.Width = colWidths[index];

            return rect;
        }

        /// <summary>
        /// Get Workflow row style
        /// </summary>
        /// <param name="row">Row index of Layout</param>
        /// <returns></returns>
        internal WorkflowRowStyle GetRowStyle(int row) {
            return ParentWorkflow.RowStyles[row] as WorkflowRowStyle;
        }

        /// <summary>
        /// Get Workflow column style.
        /// </summary>
        /// <param name="col">Column index of Layout.</param>
        /// <returns></returns>
        internal WorkflowColumnStyle GetColumnStyle(int col) {
            return ParentWorkflow.ColumnStyles[col] as WorkflowColumnStyle;
        }
        
        
    }
}
