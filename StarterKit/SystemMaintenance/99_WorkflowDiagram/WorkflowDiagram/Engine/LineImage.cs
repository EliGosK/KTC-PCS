using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace WorkFlowDiagram
{
    /// <summary>
    /// Line Image: Line , Connector and Arrow.
    /// </summary>
    public class LineImage
    {
        public Image EMPTY = null;

        #region "  One direction  "
        public  Image VLINE = null;
        public  Image HLINE = null;
        public  Image ARROW_LEFT = null;
        public  Image ARROW_UP = null;
        public  Image ARROW_RIGHT = null;
        public  Image ARROW_DOWN = null;
        #endregion

        #region "  Four direction  "
        public  Image CONNECTOR_CROSS = null;
        #endregion

        #region "  Three direction  "
        //LRTB
        public  Image CONNECTOR_LEFT_RIGHT_TOP = null;
        public  Image CONNECTOR_RIGHT_TOP_BOTTOM = null;
        public  Image CONNECTOR_LEFT_RIGHT_BOTTOM = null;
        public  Image CONNECTOR_LEFT_TOP_BOTTOM = null;
        #endregion

        #region "  Two direction  "
        public  Image CONNECTOR_LEFT_TOP = null;
        public  Image CONNECTOR_LEFT_BOTTOM = null;
        public  Image CONNECTOR_RIGHT_TOP = null;
        public  Image CONNECTOR_RIGHT_BOTTOM = null;
        #endregion

        public Size CONNECTOR_SIZE = new Size(24, 24);

        public LineImage() {
            string image_path = Path.Combine(Application.StartupPath, "WorkflowLine");

            EMPTY = Bitmap.FromFile(Path.Combine(image_path, "EMPTY.png"));
            VLINE = Bitmap.FromFile(Path.Combine(image_path, "VLINE.png"));
            HLINE = Bitmap.FromFile(Path.Combine(image_path, "HLINE.png"));

            ARROW_LEFT = Bitmap.FromFile(Path.Combine(image_path, "ARROW_LEFT.png"));
            ARROW_UP = Bitmap.FromFile(Path.Combine(image_path, "ARROW_UP.png"));
            ARROW_RIGHT = Bitmap.FromFile(Path.Combine(image_path, "ARROW_RIGHT.png"));
            ARROW_DOWN = Bitmap.FromFile(Path.Combine(image_path, "ARROW_DOWN.png"));

            CONNECTOR_CROSS = Bitmap.FromFile(Path.Combine(image_path, "CONNECTOR_CROSS.png"));

            CONNECTOR_LEFT_RIGHT_TOP = Bitmap.FromFile(Path.Combine(image_path, "CONNECTOR_LRT.png"));
            CONNECTOR_RIGHT_TOP_BOTTOM = Bitmap.FromFile(Path.Combine(image_path, "CONNECTOR_RTB.png"));
            CONNECTOR_LEFT_RIGHT_BOTTOM = Bitmap.FromFile(Path.Combine(image_path, "CONNECTOR_LRB.png"));
            CONNECTOR_LEFT_TOP_BOTTOM = Bitmap.FromFile(Path.Combine(image_path, "CONNECTOR_LTB.png"));

            CONNECTOR_LEFT_TOP = Bitmap.FromFile(Path.Combine(image_path, "CONNECTOR_LT.png"));
            CONNECTOR_LEFT_BOTTOM = Bitmap.FromFile(Path.Combine(image_path, "CONNECTOR_LB.png"));
            CONNECTOR_RIGHT_TOP = Bitmap.FromFile(Path.Combine(image_path, "CONNECTOR_RT.png"));
            CONNECTOR_RIGHT_BOTTOM = Bitmap.FromFile(Path.Combine(image_path, "CONNECTOR_RB.png"));
        }
        /// <summary>
        /// Load schema XML that store link to file image of each line image.
        /// </summary>
        public void LoadFromXML() {
            // Directory reference to file XML.    
        }
    }
}
