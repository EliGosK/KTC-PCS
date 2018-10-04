#region Record of change
/* Record of change
 * 20091005: Added 
 * 
 * 
 * */
#endregion

#region Using
using System;
using System.Windows.Forms;
using EVOFramework.Data;
using FarPoint.Win.Spread;
using System.ComponentModel;
using System.Collections.Generic;

#endregion

namespace EVOFramework.Windows.Forms
{
    /// <summary>
    /// Represent base form that all customize screen must inherit.
    /// </summary>
    public partial class EVOForm : System.Windows.Forms.Form
    {
        #region Variables

        /// <summary>
        /// Single instance for form's appearance.
        /// </summary>
        private AppearanceComponent m_appearanceComponent = null;
        /// <summary>
        /// Store cache control when form shown.
        /// </summary>
        private Map<string, ScreenDetail> m_mapControlCache = null;
        #endregion

        #region Constructor
        public EVOForm()
        {
            this.ControlAdded += EVOForm_ControlAdded;
            this.ControlRemoved += EVOForm_ControlRemoved;
            InitializeComponent();
        }

        void EVOForm_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (this.IsHandleCreated && MapControlCache != null)
            {
                MapControlCache.RemoveAll();
                m_mapControlCache = null;
            }
        }
        void EVOForm_ControlAdded(object sender, ControlEventArgs e)
        {
            if (this.IsHandleCreated && MapControlCache != null)
            {
                MapControlCache.RemoveAll();
                m_mapControlCache = null;
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Store cache control when form shown.
        /// </summary>
        protected Map<string, ScreenDetail> MapControlCache
        {
            get { return m_mapControlCache; }
        }

        /// <summary>
        /// [Meta] Screen Code
        /// </summary>
        [Browsable(false)]
        public string ScreenCode
        {
            get
            {
                object[] objs = this.GetType().GetCustomAttributes(typeof(ScreenAttribute), true);
                if (objs == null || objs.Length == 0)
                    return string.Empty;

                return ((ScreenAttribute)objs[0]).ScreenCD;

            }
        }

        #region Appearance Component
        /// <summary>
        /// Single instance for form's appearance.
        /// </summary>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public AppearanceComponent AppearanceComponent
        {
            get { return m_appearanceComponent; }
            set { m_appearanceComponent = value; }
        }

        #endregion

        #endregion


        #region Overriden methods
        protected override void OnLoad(EventArgs e)
        {
            //== Get list of all controls.
            List<Control> listControls = new List<Control>();
            for (int i = 0; i < this.Controls.Count; i++)
            {
                GetAllControls(this.Controls[i], listControls);
            }

            // Invalidate appearance for all controls which supported.
            for (int i = 0; i < listControls.Count; i++)
            {
                if (listControls[i] as IAppearanceUpdatable != null)
                {
                    ((IAppearanceUpdatable)listControls[i]).InvalidateAppearance();
                }

                if (listControls[i] as FpSpread != null)
                {
                    FpSpread fp = (FpSpread)listControls[i];

                    Appearance appearance = null;
                    if (fp.TextTipDelay == 1000)
                    {
                        appearance = AppearanceManager.DefaultAppearanceSet["ListDataGridStyle"];
                    }
                    else
                    {
                        appearance = AppearanceManager.DefaultAppearanceSet[""];

                    }

                    if (appearance != null)
                    {

                        System.Drawing.Font f = new System.Drawing.Font(appearance.FontName, appearance.FontSize, appearance.FontStyle);
                        fp.Font = f;
                        fp.BackColor = appearance.BackColor;
                        fp.ForeColor = appearance.ForeColor;

                        fp.Invalidate(false);

                        //FontStyle fontStyle = appearance.FontStyle;

                        //Font font = new Font(appearance.FontName, appearance.FontSize, fontStyle);
                        //this.Font = font;
                        //this.BackColor = appearance.BackColor;
                        //this.ForeColor = appearance.ForeColor;

                        //this.Invalidate(false);

                    }
                }

            }

            base.OnLoad(e);
        }
        #endregion

        #region Get list of all controls
        private void GetAllControls(Control control, List<Control> buffer)
        {

            buffer.Add(control);

            for (int i = 0; i < control.Controls.Count; i++)
            {
                GetAllControls(control.Controls[i], buffer);
            }
        }
        #endregion

        #region Get List of Controls

        /// <summary>
        /// Assign range text to control.
        /// </summary>
        /// <param name="mapNameText">Map between control's name and text. Key is control's name and Value is control's text.</param>
        public void AssignControlTextRange(Map<string, string> mapNameText)
        {
            this.SuspendLayout();
            for (int i = 0; i < mapNameText.Count; i++)
            {
                AssignControlText(mapNameText[i].Key, mapNameText[i].Value);
            }
            this.ResumeLayout(false);
        }
        /// <summary>
        /// Assign text to control.
        /// </summary>
        /// <param name="name">Control name. It must associate with result name on GetControlList method</param>
        /// <param name="text">Contro Text.</param>
        public void AssignControlText(string name, string text)
        {

            Map<string, ScreenDetail> mapBuffer = GetControlList();
            if (mapBuffer.FoundKey(name))
            {
                if (mapBuffer[name].Value.ObjOwner is Column)
                {
                    Column column = (Column)mapBuffer[name].Value.ObjOwner;
                    column.Label = text;
                }
                else if (mapBuffer[name].Value.ObjOwner is Control)
                {
                    Control control = (Control)mapBuffer[name].Value.ObjOwner;
                    control.Text = text;
                }
            }

        }

        /// <summary>
        /// Get list of controls which appropriate to multilanguage.
        /// </summary>
        /// <returns></returns>
        public Map<string, ScreenDetail> GetControlList()
        {
            if (MapControlCache == null)
                m_mapControlCache = new Map<string, ScreenDetail>();
            else
            {
                return MapControlCache;
            }

            // Store own form.
            ScreenDetail screenDetail = new ScreenDetail();
            screenDetail.ObjOwner = this;
            screenDetail.Text = ScreenAttribute.GetScreenAttribute(this.GetType()).ScreenDescription;
            screenDetail.Name = this.Name;
            screenDetail.Type = ScreenDetail.TYPE_FORM;
            m_mapControlCache.Put(this.Name, screenDetail);

            // Store recursive child controls.
            for (int i = 0; i < this.Controls.Count; i++)
            {
                RetrieveControls(MapControlCache, this.Controls[i]);
            }
            return MapControlCache;
        }

        /// <summary>
        /// Deep search in ControlCollection to retrieve available control.
        /// </summary>
        /// <param name="map">Map that use to store control</param>
        /// <param name="control">Parent control which will deep search.</param>
        private void RetrieveControls(Map<string, ScreenDetail> map, Control control)
        {

            // Store myself.
            if (!(control is UserControl))
            {
                ScreenDetail screenDetail = new ScreenDetail();

                if (control is IControlIdentify)
                {
                    screenDetail.Name = ((IControlIdentify)control).ControlID;
                    if (String.IsNullOrEmpty(screenDetail.Name))
                        screenDetail.Name = control.Name;

                }
                else
                {
                    screenDetail.Name = control.Name;
                }

                screenDetail.Text = control.Text;
                screenDetail.ObjOwner = control;

                if (control is Label)
                {
                    screenDetail.Type = ScreenDetail.TYPE_LABEL;
                    map.Put(screenDetail.Name, screenDetail);
                    return;
                }

                if (control is CheckBox)
                {
                    screenDetail.Type = ScreenDetail.TYPE_CHECKBOX;
                    map.Put(screenDetail.Name, screenDetail);
                    return;
                }

                if (control is RadioButton)
                {
                    screenDetail.Type = ScreenDetail.TYPE_RADIOBUTTON;
                    map.Put(screenDetail.Name, screenDetail);
                    return;
                }

                if (control is Button)
                {
                    screenDetail.Type = ScreenDetail.TYPE_BUTTON;
                    map.Put(screenDetail.Name, screenDetail);
                    return;
                }


                if (control is GroupBox)
                {
                    screenDetail.Type = ScreenDetail.TYPE_GROUPBOX;
                    map.Put(screenDetail.Name, screenDetail);
                }
                else if (control is TabPage)
                {
                    screenDetail.Type = ScreenDetail.TYPE_TABPAGE;
                    map.Put(screenDetail.Name, screenDetail);

                }
                else if (control is FpSpread)
                {
                    FpSpread spread = (FpSpread)control;
                    SheetView sheetView = spread.Sheets[0];
                    for (int i = 0; i < sheetView.Columns.Count; i++)
                    {
                        Column column = sheetView.Columns[i];
                        if (column.Tag == null || column.Tag.ToString().Trim() == string.Empty)
                            continue;

                        screenDetail = new ScreenDetail();
                        screenDetail.Name = String.Format("{0}.{1}", spread.Name, column.Tag);
                        screenDetail.Text = column.Label;
                        screenDetail.Type = ScreenDetail.TYPE_SPREAD_COLUMN;
                        screenDetail.ObjOwner = column;
                        map.Put(screenDetail.Name, screenDetail);
                    }
                }
            }


            // Store child controls.
            for (int i = 0; i < control.Controls.Count; i++)
            {
                RetrieveControls(map, control.Controls[i]);
            } // end for

        }


        #endregion

        #region Form Close controlling
        private bool m_bForceClose = false;
        /// <summary>
        /// Forge to Close Form.
        /// </summary>
        /// <param name="forceClose"></param>
        public void Close(bool forceClose)
        {
            m_bForceClose = forceClose;
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (m_bForceClose)
            {
                e.Cancel = false;
                return;
            }

            base.OnFormClosing(e);
        }
        #endregion
    }
}
