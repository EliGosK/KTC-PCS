using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EVOFramework.Windows.Forms
{
    /// <summary>
    /// Thumbnail Viewer for preview image collection.
    /// </summary>
    [ToolboxItem(true)]
    public partial class ThumbnailViewer : FlowLayoutPanel
    {
        #region Variables
        /// <summary>
        /// Default image same size on width and height
        /// </summary>
        private int m_imageSizeSymmetric = 100;        

        /// <summary>
        /// Current selected thumbnail button.
        /// </summary>
        private ThumbnailButton m_selectedThumbnailButton = null;
        #endregion

        #region Constructor
        public ThumbnailViewer()
        {
            InitializeComponent();

            base.AutoScroll = true;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the container enables the user to scroll to any controls placed outside of its visible boundaries.
        /// </summary>
        /// <returns>
        /// true if the container enables auto-scrolling; otherwise, false. The default value is false. 
        /// </returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public override bool AutoScroll
        {
            get { return true; }
            set { }
        }

        /// <summary>
        /// Get or set selected Image.
        /// </summary>
        public Image SelectedImage {
            get {
                ThumbnailButton btn = SelectedThumbnailButton;
                if (btn == null)
                    return null;

                return btn.Image;                
            }
            set {
                if (value == null)
                    return;

                ThumbnailButton btn = GetThumbnailButtonByImage(value);
                m_selectedThumbnailButton = btn;

                if (btn != null)
                    btn.Focus();
            }
        }

        /// <summary>
        /// Get selected ThumbnailButton
        /// </summary>
        public ThumbnailButton SelectedThumbnailButton {
            get {
                return m_selectedThumbnailButton;
            }
        }

        /// <summary>
        /// Default image same size on width and height
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><c>value</c> is out of range.</exception>
        public int ImageSizeSymmetric {
            get { return m_imageSizeSymmetric; }
            set {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("value", value, "Must input value more than zero.");

                m_imageSizeSymmetric = value;

                for (int i=0; i<this.Controls.Count; i++) {
                    ThumbnailButton btn = this.Controls[i] as ThumbnailButton;
                    if (btn == null)
                        continue;

                    btn.AdjustSize(new Size(m_imageSizeSymmetric, m_imageSizeSymmetric));
                }                
            }
        }
    
        #endregion     
   
        #region Add/Remove Image
        /// <summary>
        /// Add Image to display thumbnail
        /// </summary>
        /// <param name="name"></param>
        /// <param name="image"></param>
        public void AddImage(string name, Image image) {
            ThumbnailButton btn = new ThumbnailButton();
            btn.Name = name;
            btn.ImageSizeSymmetric = ImageSizeSymmetric;
            btn.Image = image;
            
            btn.Click += thumbnailButton_Click;
            this.Controls.Add(btn);
        }

        void thumbnailButton_Click(object sender, EventArgs e)
        {
            m_selectedThumbnailButton = sender as ThumbnailButton;
        }

        /// <summary>
        /// Remove Image button.
        /// </summary>
        /// <param name="name">Name of image.</param>
        public void RemoveImage(string name) {            

            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is ThumbnailButton)
                {
                    ThumbnailButton button = this.Controls[i] as ThumbnailButton;
                    if (button == null)
                        continue;

                    if (button.Name.Equals(name))
                    {
                        this.Controls.Remove(button);
                        return;
                    }
                }
            } // end for.
        }

        /// <summary>
        /// Get image count.
        /// </summary>
        public int ImageCount {
            get { return this.Controls.Count; }
        }

        /// <summary>
        /// Remove all image on thumbnail viewer.
        /// </summary>
        public void ClearAllImages() {
            this.Controls.Clear();
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Get Image.
        /// </summary>
        /// <param name="name">Name of image.</param>
        /// <returns></returns>
        public Image GetImageByName(string name) {
            for (int i=0; i<this.Controls.Count; i++) {
                ThumbnailButton btn = (ThumbnailButton) this.Controls[i];
                if (btn.Name.Equals(name)) {
                    return btn.Image;
                }
            }
            return null;
        }

        /// <summary>
        /// Get Thumbnail button by Image object.
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public ThumbnailButton GetThumbnailButtonByImage(Image image) {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                ThumbnailButton btn = (ThumbnailButton)this.Controls[i];
                if (btn.Image.Equals(image))
                {
                    return btn;
                }
            }

            return null;
        }
        
        /// <summary>
        /// Get thumbnail button at index of control collection.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ThumbnailButton GetThumbnailButtonAt(int index) {
            return this.Controls[index] as ThumbnailButton;
        }
        #endregion
    }
}
