using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SystemMaintenance;
using EVOFramework.Windows.Forms;
using EVOFramework.Database;
using Rubik.BIZ;
using Rubik.DTO;

namespace Rubik.Master
{
    public partial class ItemImageList : EVOFramework.Windows.Forms.EVOForm
    {
        public Image SelectedImage { get; set; }
        public string SelectedImageCode { get; set; }

        public ItemImageList(string ImageCode)
        {
            InitializeComponent();

            SelectedImageCode = ImageCode;

            InitialShowImage();

            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        /// <summary>
        /// Get new instance of all image on database. This method will store to cache together.
        /// </summary>
        /// <returns>Image Item List</returns>
        public ImageItemList GetAllImages()
        {
            ImageItemList list = new ImageItemList();
            ItemImageBIZ bizImage = new ItemImageBIZ();
            List<ItemImageDTO> imgList = bizImage.LoadAllImage();
            for (int i = 0; i < imgList.Count; i++)
            {

                // Convert byte array to Image.
                byte[] byteArray = imgList[i].IMAGE.StrongValue;
                MemoryStream memoryStream = new MemoryStream(byteArray);
                Image img = Image.FromStream(memoryStream);
                memoryStream.Close();

                // Add to image cache.
                ImageItem item = new ImageItem(imgList[i].ITEM_CD.StrongValue, img);
                //m_imageItemList.Add(item);

                list.Add(item);
            }

            return list;
        }

        private void InitialShowImage()
        {
            try
            {
                imageViewer.ClearAllImages();

                // get image at Item Image Table
                ImageItemList imageItemList = GetAllImages();

                int ImageCount = imageItemList.Count;
                for (int i = 0; i < ImageCount; i++)
                {
                    imageViewer.AddImage(imageItemList[i].ImageCD, imageItemList[i].ImageBin);
                }

                if (SelectedImageCode == String.Empty)
                {
                    if (imageItemList.Count > 0)
                        imageViewer.SelectedImage = imageItemList[0].ImageBin;
                }
                else
                {
                    Image image = imageViewer.GetImageByName(SelectedImageCode);
                    if (image == null)
                    {
                        imageViewer.SelectedImage = imageViewer.GetThumbnailButtonAt(0).Image;
                    }
                    else
                    {
                        imageViewer.SelectedImage = image;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = @"Image Type (gif, ico, jpg, jpeg, png)|*.gif;*.ico;*.jpg;*.jpeg;*.png;
                                        |Icon (ico)|*.ico
                                        |Icon (gif)|*.gif
                                        |Image (jpg, jpeg, png)|*.jpg;*.jpeg;*.png;
                                        |All File|*.*";
                fileDialog.Multiselect = true;
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    int selectedFileCount = fileDialog.FileNames.Length;
                    List<Image> imgListFromFile = new List<Image>();

                    for (int i = 0; i < selectedFileCount; i++)
                    {
                        imgListFromFile.Add(Image.FromFile(fileDialog.FileNames[i]));

                    }
                    AddNewImage(imgListFromFile);

                    InitialShowImage();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (RemoveImage(imageViewer.SelectedThumbnailButton.Name))
            {
                //if (SelectedImageCode == OldImageCode)
                //{
                //    OldImageCode = imageList.Images.Keys[0];
                //}

                //SelectedImageCode = imageList.Images.Keys[0];

                InitialShowImage();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            ThumbnailButton btn = imageViewer.SelectedThumbnailButton;
            if (btn == null)
            {
                SelectedImageCode = string.Empty;
                SelectedImage = null;
            }
            else
            {
                SelectedImageCode = imageViewer.SelectedThumbnailButton.Name;
                SelectedImage = imageViewer.SelectedImage;
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }



        private bool AddNewImage(List<Image> imgList)
        {
            try
            {
                for (int i = 0; i < imgList.Count; i++)
                {
                    MemoryStream memStream = new MemoryStream();
                    imgList[i].Save(memStream, imgList[i].RawFormat); //System.Drawing.Imaging.ImageFormat.Png);
                    memStream.Position = 0;

                    byte[] byteArray = memStream.ToArray();
                    memStream.Close();

                    string sql = @"INSERT INTO TZ_IMAGE_MS
                                    VALUES
                                      (TO_CHAR(SYSDATE, 'ddMMyyhhmiss')||" + i.ToString() + "," +
                                 @"    :pImage,
                                        '',
                                        :CRT_BY,
                                        :CRT_DATE,
                                        :CRT_MACHINE,
                                        :UPD_BY,
                                        :UPD_DATE,
                                        :UPD_MACHINE )
                                    ";
                    DataRequest req = new DataRequest(sql);
                    req.Parameters.Add("pImage", DataType.Binary, byteArray);
                    req.Parameters.Add("CRT_BY", DataType.VarChar, CommonLib.Common.CurrentUserInfomation.UserCD.StrongValue);
                    req.Parameters.Add("CRT_DATE", DataType.DateTime, CommonLib.Common.GetDatabaseDateTime());
                    req.Parameters.Add("CRT_MACHINE", DataType.VarChar, CommonLib.Common.CurrentUserInfomation.Machine.StrongValue);
                    req.Parameters.Add("UPD_BY", DataType.VarChar, CommonLib.Common.CurrentUserInfomation.UserCD.StrongValue);
                    req.Parameters.Add("UPD_DATE", DataType.DateTime, CommonLib.Common.GetDatabaseDateTime());
                    req.Parameters.Add("UPD_MACHINE", DataType.VarChar, CommonLib.Common.CurrentUserInfomation.Machine.StrongValue);
                    CommonLib.Common.CurrentDatabase.ExecuteNonQuery(req);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
                return false;
            }
            return true;
        }
        private bool RemoveImage(string ImageCD)
        {
            try
            {
                string sql = @"DELETE FROM TZ_IMAGE_MS T WHERE T.IMAGE_CD = :pImageCD";
                DataRequest req = new DataRequest(sql);
                req.Parameters.Add("pImageCD", DataType.VarChar, ImageCD);
                CommonLib.Common.CurrentDatabase.ExecuteNonQuery(req);
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
                return false;
            }
            return true;
        }

        private void ScreenImageList_Load(object sender, EventArgs e)
        {

        }

        private void ScreenImageList_Shown(object sender, EventArgs e)
        {
            imageViewer.SelectedImage = imageViewer.GetImageByName(SelectedImageCode);
        }
    }
}
