using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Cube.AFD.Windows.Controls.CalendarControls {

    [Flags()]
    public enum EditorWhen : short{
        None = 1 << 0,
        DoubleClick = 1 << 1,
        F2 = 1 << 2,
        Enter = 1 << 3
    }

    public enum EditorMode {
        Alway, DisplayWhenEdit
    }

    public enum EditorView{
        Default // Use default drawing
        , ForeControl // Capture editor control as a graphics object and then using this graphics to draw
        , OwnerDraw // Onwer draw the control, method IEditorControl.DrawDay will be invoked.
    }

    //public interface IEditorControl {
    //    DayObject DayObject { get; set;}
    //    object Value { get; set;}
    //    bool IsValueChanged { get;}
    //    void SetFocus();
    //    Bitmap Bitmap { get; set;}
    //    void PaintDay(Calendar calendar, Graphics g, MonthObject monthObj, DayObject dayObj);
    //}

    [Browsable(false), ToolboxItem(false)]
    public class DayEditor : UserControl{
        protected DayObject m_dayObject = null;
        protected bool m_bIsValueChanged = false;
        private Bitmap m_bmp;

        public DayEditor() {
            m_bIsValueChanged = false;
        }

        public Bitmap Bitmap {
            get {
                return m_bmp;
            }
            set {
                m_bmp = value;
            }
        }

        public virtual void SetFocus() {
            //this.SetFocus();
        }

        public virtual bool IsValueChanged {
            get {
                return m_bIsValueChanged;
            }
        }

        public virtual object Value {
            get {
                return this.Tag;
            }
            set {
                if (this.Tag != value) {
                    this.Tag = value;
                    m_bIsValueChanged = true;
                } else {
                    m_bIsValueChanged = false;
                }
            }
        }

        public virtual DayObject DayObject {
            get {
                return m_dayObject;
            }
            set {
                m_dayObject = value;
            }
        }

        public virtual void PaintDay(Calendar calendar, Graphics g, MonthObject monthObj, DayObject dayObj) {
            calendar.PaintDay(g, monthObj, dayObj);
        }

        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // DayEditor
            // 
            this.Controls.Add(this.label1);
            this.Name = "DayEditor";
            this.Size = new System.Drawing.Size(154, 102);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label label1;
    }
    /*
    [ToolboxItem(false)]
    public partial class DayEdit1 : UserControl, IEditorControl {
        
        private DayObject m_dayObject = null;
        private bool m_bIsValueChanged = false;
        private Bitmap m_bmp;
        private Brush[] br = new Brush[] { Brushes.Red, Brushes.Blue, Brushes.Beige, Brushes.OldLace, Brushes.Yellow, Brushes.Green, Brushes.Pink };
        private static int iCount = 0;


        public DayEdit1() {
            InitializeComponent();
            m_bIsValueChanged = false;
        }

        public void PaintDay(Calendar calendar, Graphics g, MonthObject monthObj, DayObject dayObj) {
            calendar.PaintDay(g, monthObj, dayObj);
            if (dayObj.Show) {
                iCount++;
                if (iCount >= br.Length - 1) {
                    iCount = 0;
                }

                g.DrawString(textBox1.Text, calendar.Font, br[iCount], dayObj.ClientRectangle);

            }
        }


        public Bitmap Bitmap {
            get {
                return m_bmp;
            }
            set {
                m_bmp = value;
            }
        }

        public void SetFocus() {
            textBox1.Focus();
            textBox1.SelectAll();
        }

        public bool IsValueChanged {
            get {
                return m_bIsValueChanged;
            }
        }

        public object Value {
            get {
                return textBox1.Text;
            }
            set {
                string strValue = (value == null ? string.Empty : Convert.ToString(value));
                if (textBox1.Text != strValue) {
                    textBox1.Text = strValue;
                    m_bIsValueChanged = true;
                } else {
                    m_bIsValueChanged = false;
                }
            }
        }


        public DayObject DayObject {
            get {
                return m_dayObject;
            }
            set {
                m_dayObject = value;
                if (m_dayObject.Date.Month != m_dayObject.MonthObject.Month) {
                    this.BackColor = Color.FromArgb(239, 243, 247);
                    textBox1.BackColor = this.BackColor;
                } else if (m_dayObject.Date.DayOfWeek == DayOfWeek.Saturday || m_dayObject.Date.DayOfWeek == DayOfWeek.Sunday) {
                    this.BackColor = Color.FromArgb(255, 251, 239);
                    textBox1.BackColor = this.BackColor;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            m_bIsValueChanged = true;
        }
    }*/
}
