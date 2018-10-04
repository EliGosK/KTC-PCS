using System;
using System.Drawing;
using System.Windows.Forms;
using WorkFlowDiagram.DTO;

namespace WorkFlowDiagram
{
    public class WorkflowButtonArgs : EventArgs
    {
        private string m_text = String.Empty;
        private Image m_image = null;
        private ButtonDTO m_data = null;
        public WorkflowButtonArgs() {
            
        }

        /// <summary>
        /// Get or set Text to display on button.
        /// </summary>
        public string Text {
            get { return m_text; }
            set { m_text = value; }
        }

        /// <summary>
        /// Get or set Image to display on button.
        /// </summary>
        public Image Image {
            get { return m_image; }
            set { m_image = value; }
        }

        /// <summary>
        /// Get data.
        /// </summary>
        public ButtonDTO Data {
            get { return m_data; }    
            internal set { m_data = value;}
        }
    }
}
