using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkFlowDiagram
{
    [ToolboxItem(false)]
    public partial class WorkflowViewer : Control
    {
        #region "  Variables  "
        private TableLayoutPanel m_tableLayout = null;
        private Workflow m_workFlow = null;
        private Panel m_container = null;
        private LineImage m_lineImage = null;
        #endregion

        #region "  Events  "
        public event ButtonLoadHandler ButtonLoad;
        public event ButtonClickHandler ButtonClick;
        #endregion

        #region "  Constructor  "
        public WorkflowViewer() : base()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            
            ResetViewer();
        }
        #endregion

        #region "  Overriden base method  "
        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode)
                m_lineImage = new LineImage();                

            base.OnHandleCreated(e);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            ResetViewer();
        }

        #endregion

        #region "  Properties  "
        public LineImage LineImage {
            get { return m_lineImage; }
            set { m_lineImage = value; }
        }

        internal Panel PanelContainer {
            get { return m_container; }
            set { m_container = value; }
        }

        internal Workflow WorkFlow {
            get { return m_workFlow; }
            set { m_workFlow = value; }
        }
        #endregion

        #region "  Private methods  "
        /// <summary>
        /// Calculate position center on container.
        /// </summary>
        /// <returns></returns>
        private Point CalculateWorkFlowPositionCenter()
        {
            int left = 0;
            if (WorkFlow.Width < PanelContainer.Width)
            {
                int hcenter = PanelContainer.Width / 2;
                left = hcenter - WorkFlow.Width / 2;
            }
            else
            {
                if (PanelContainer.HorizontalScroll.Visible)
                {
                    left = -PanelContainer.HorizontalScroll.Value;
                }
            }

            int top = 0;
            if (WorkFlow.Height < PanelContainer.Height)
            {
                int vcenter = PanelContainer.Height / 2;
                top = vcenter - WorkFlow.Height / 2;
            }
            else
            {
                if (PanelContainer.VerticalScroll.Visible)
                {
                    top = -PanelContainer.VerticalScroll.Value;
                }
            }
            return new Point(left, top);
        }


        /// <summary>
        /// Reset viewer. Clear all controls on container and reset row and column style.
        /// </summary>
        private void ResetViewer() {
            this.Controls.Clear();

            // Dispose old workflow.
            if (WorkFlow != null)
            {
                WorkFlow.Dispose();
                WorkFlow = null;
            }

            // Dispose Panel Container.
            if (PanelContainer != null)
            {
                // Unbind event handler.
                PanelContainer.Resize -= m_container_Resize;
                PanelContainer.Scroll -= m_container_Scroll;
                // Dispose object.
                PanelContainer.Dispose();
                PanelContainer = null;
            }

            //Dispose Table Layout
            if (m_tableLayout != null) {
                m_tableLayout.Dispose();
                m_tableLayout = null;
            }

            // ReCreate TableLayout.
            m_tableLayout = new TableLayoutPanel();            
            m_tableLayout.Dock = DockStyle.Fill;

            // ReCreate Container.
            PanelContainer = new WorkflowPanel();            
            PanelContainer.Dock = DockStyle.Fill;
            PanelContainer.AutoScroll = true;
            PanelContainer.Resize += m_container_Resize;
            PanelContainer.Scroll += m_container_Scroll;

            m_tableLayout.RowCount = 1;
            m_tableLayout.ColumnCount = 1;
            m_tableLayout.RowStyles.Clear();
            m_tableLayout.ColumnStyles.Clear();
            m_tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            m_tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            m_tableLayout.Controls.Add(PanelContainer, 0, 0);
            
            this.Controls.Add(m_tableLayout);

            // Create new workflow.
            WorkFlow = new Workflow(this, LineImage);
            WorkFlow.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            WorkFlow.AutoSize = true;
            WorkFlow.AutoSizeMode = AutoSizeMode.GrowAndShrink;            

            // Add workflow into container.
            PanelContainer.Controls.Add(WorkFlow);
            PanelContainer.Width = WorkFlow.Width;

            SubscribeWorkflow();
        }

        void m_container_Scroll(object sender, ScrollEventArgs e)
        {
            Parent.Invalidate();
        }
        void m_container_Resize(object sender, EventArgs e)
        {
            if (WorkFlow == null)
                return;

            Point location = CalculateWorkFlowPositionCenter();
            WorkFlow.Location = location;
        }
        void m_workFlow_ButtonLoad(object sender, WorkflowButtonArgs e)
        {
            if (ButtonLoad != null)
                ButtonLoad(this, e);
        }
        void m_workFlow_ButtonClick(object sender, WorkflowButton button)
        {
            if (ButtonClick != null)
                ButtonClick(this, button);
        }

        private void SubscribeWorkflow()
        {
            if (this.WorkFlow == null)
                return;

            this.WorkFlow.ButtonLoad += new ButtonLoadHandler(m_workFlow_ButtonLoad);
            this.WorkFlow.ButtonClick += new ButtonClickHandler(m_workFlow_ButtonClick);
        }
        private void UnsubscribeWorkFlow()
        {
            if (this.WorkFlow == null)
                return;

            this.WorkFlow.ButtonLoad -= new ButtonLoadHandler(m_workFlow_ButtonLoad);
            this.WorkFlow.ButtonClick -= new ButtonClickHandler(m_workFlow_ButtonClick);
        }
        #endregion

        #region "  Public methods  "
        /// <summary>
        /// Load workflow document.
        /// </summary>
        /// <param name="document"></param>
        public void LoadDocument(WorkflowDocument document) {
            if (document == null) {
                WorkFlow.CloseDocument();
                return;
            }            
            
            // Formatting Workflow Document to View.            
            WorkFlow.SuspendLayout();
            WorkFlow.LoadDocument(document);                        
            WorkFlow.ResumeLayout(true);

            //== Calculate position.
            Point location = CalculateWorkFlowPositionCenter();            
            WorkFlow.Location = location;         
                           
            PanelContainer.ScrollControlIntoView(WorkFlow);            
        }

        /// <summary>
        /// Reload current workflow document.
        /// </summary>
        public void ReloadDocument() {
            if (WorkFlow == null)
                throw new ApplicationException("Not found workflow to reload.");
            
            WorkFlow.ReloadDocument();
        }

        /// <summary>
        /// Close current workflow document.
        /// </summary>
        public void CloseDocument() {
            if (WorkFlow != null) {
                UnsubscribeWorkFlow();
                WorkFlow.CloseDocument();
            }

            ResetViewer();
        }
        #endregion

        
    }
}
