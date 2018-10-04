using System;

namespace EVOFramework.Windows.Forms
{    
    public class ScreenDetail
    {
        #region Type Constants

        public const string TYPE_FORM = "Form";
        public const string TYPE_LABEL = "Label";
        public const string TYPE_CHECKBOX = "CheckBox";
        public const string TYPE_RADIOBUTTON = "RadioButton";
        public const string TYPE_BUTTON = "Button";
        public const string TYPE_GROUPBOX = "GroupBox";
        public const string TYPE_TABPAGE = "TabPage";
        public const string TYPE_SPREAD_COLUMN = "FpColumn";
        #endregion

        #region Variables
        private object m_objOwner = null;
        private string m_name = String.Empty;
        private string m_text = String.Empty;
        private string m_type = String.Empty;
        #endregion

        #region Constructor
        public ScreenDetail() {
            
        }

        public ScreenDetail(string name, string text, string type, object objOwner) {
            Name = name;
            Text = text;
            Type = type;
            ObjOwner = objOwner;
        }
        #endregion

        #region Properties
        public object ObjOwner {
            get { return m_objOwner; }
            set { m_objOwner = value; }
        }

        public string Name {
            get { return m_name; }
            set { m_name = value; }
        }

        public string Text {
            get { return m_text; }
            set { m_text = value; }
        }

        public string Type {
            get { return m_type; }
            set { m_type = value; }
        }
        #endregion
    }
}
