using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowDiagram.DTO;
using WorkFlowDiagram.DAO;

namespace WorkFlowDiagram
{
    public delegate void ButtonLoadHandler(object sender, WorkflowButtonArgs e);
    public delegate void ButtonClickHandler(object sender, WorkflowButton button);

    [ToolboxItem(false)]
    internal partial class Workflow : TableLayoutPanel
    {        
        #region "  Events  "
        

        public event ButtonLoadHandler ButtonLoad;
        public event ButtonClickHandler ButtonClick;
        #endregion

        #region "  DAO Variables  "
        private readonly ButtonDAO m_daoButton = new ButtonDAO();
        private readonly LineHeaderDAO m_daoLineHeader = new LineHeaderDAO();
        private readonly LineDetailDAO m_daoLineDetail = new LineDetailDAO();
        private readonly ConnectorDAO m_daoConnector = new ConnectorDAO();
        #endregion

        #region "  Variables  "
        /// <summary>
        /// WorkFlow Viewer.
        /// </summary>
        private WorkflowViewer m_viewer = null;
        private WorkflowEngine m_engine = null;
        private LineImage m_lineImage = null;
        private WorkflowDocument m_workflowDocument = null;
        #endregion

        #region "  Constructor  "
        public Workflow(WorkflowViewer viewer, LineImage lineImage) : base()
        {
            m_viewer = viewer;
            m_lineImage = lineImage;
            m_engine = new WorkflowEngine(this);

            InitializeComponent();
            
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }
        #endregion

        #region "  Properties  "
        /// <summary>
        /// Get WorkFlow Viewer.
        /// </summary>
        public WorkflowViewer Viewer {
            get { return m_viewer; }
        }

        public WorkflowEngine Engine {
            get { return m_engine; }
        }

        public LineImage LineImage {
            get { return m_lineImage; }
            set { m_lineImage = value; }
        }

        /// <summary>
        /// Get or set workflow document.
        /// </summary>
        public WorkflowDocument WorkflowDocument {
            get { return m_workflowDocument; }
            set { m_workflowDocument = value; }
        }


        #endregion

        #region "  Event Raise  "
        void buttonClick(object sender, EventArgs e) {
            if (ButtonClick != null)
                ButtonClick(this, sender as WorkflowButton);
        }

        internal void OnButtonLoad(WorkflowButtonArgs e) {
            if (ButtonLoad != null) {
                ButtonLoad(this, e);
            }
        }
        #endregion

        #region "  Paint event  "
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Engine.DrawLines(e.Graphics);
        }
        #endregion

        #region "  Private method  "
        /// <summary>
        /// Reset all variables and clear all data which showing on screen.
        /// </summary>
        private void ResetAndClearAll() {
            // Clear data.
            m_workflowDocument = null;
            

            // Clear TableLayout
            ClearAllControl();
        }        

        /// <summary>
        /// Clear all control on layout. Exclude data model.
        /// </summary>
        internal void ClearAllControl() {
            // Unbind event.
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is WorkflowButton)
                {
                    this.Controls[i].Click -= new EventHandler(buttonClick);

                }
            }

            // Clear TableLayout
            this.Controls.Clear();
            this.RowCount = 0;
            this.ColumnCount = 0;

            this.RowStyles.Clear();
            this.ColumnStyles.Clear();
        }        
        #endregion

        #region "  Public method  "       
        /// <summary>
        /// Refresh screen. It does not load from database, It will reuses old data to refresh screen.
        /// </summary>
        public void ReloadDocument() {            
            // Clear all component and control, exclude model data.
            this.Controls.Clear();
            this.RowCount = 0;
            this.ColumnCount = 0;
            this.RowStyles.Clear();
            this.ColumnStyles.Clear();

            //###############
            //  Generate control
            //###############
            Engine.StartGenerateWorkflow(m_workflowDocument.ButtonList, m_workflowDocument.LineHeaderList);
                     
        }
       
        /// <summary>
        /// Load document to display.
        /// </summary>
        /// <param name="document"></param>
        public void LoadDocument(WorkflowDocument document) {
            if (Object.ReferenceEquals(m_workflowDocument, document))
                return;

            m_workflowDocument = document;
            
            //== Clear all control on workflow.
            ClearAllControl();

            // Binding Button Event
            for (int i = 0; i < document.ButtonList.Count; i++) {                                                                    
                document.ButtonList[i].Click += new EventHandler(buttonClick);
            }

            //###############
            //  Generate control
            //###############
            Engine.StartGenerateWorkflow(m_workflowDocument.ButtonList, m_workflowDocument.LineHeaderList);

            //###############
            // Update bound of control.
            //###############
            this.UpdateBounds();
        }

        /// <summary>
        /// Close and release current document.
        /// </summary>
        public void CloseDocument() {
            ResetAndClearAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="rowStyle"></param>
        internal void InsertRow(int index, WorkflowRowStyle rowStyle) {
            if (index < 0 || index > this.RowCount)
                throw new ArgumentOutOfRangeException(String.Format("Index : {0} out of range.", index));

            // Update new row style.
            if (index == this.RowCount) {
                this.RowStyles.Add(rowStyle);
            } else {
                this.RowStyles.Insert(index, rowStyle);
            }

            // Add new row.
            this.RowCount++;

            // Move control to new location.
            for (int i=0; i<this.Controls.Count; i++) {
                Control control = Controls[i];
                TableLayoutPanelCellPosition cellPosition = this.GetCellPosition(control);
                if (cellPosition.Row >= index) {
                    SetRow(control, cellPosition.Row + 1);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="columnStyle"></param>
        internal void InsertColumn(int index, WorkflowColumnStyle columnStyle) {
            if (index < 0 || index > this.ColumnCount)
                throw new ArgumentOutOfRangeException(String.Format("Index : {0} out of range.", index));

            // Update new row style.
            if (index == this.ColumnCount)
            {
                this.ColumnStyles.Add(columnStyle);
            }
            else
            {
                this.ColumnStyles.Insert(index, columnStyle);
            }

            // Add new column.
            this.ColumnCount++;

            // Move control to new location.
            for (int i = 0; i < this.Controls.Count; i++)
            {
                Control control = Controls[i];
                TableLayoutPanelCellPosition cellPosition = this.GetCellPosition(control);
                if (cellPosition.Column >= index)
                {
                    SetColumn(control, cellPosition.Column + 1);
                }
            }
        }
        #endregion        
    }
}
