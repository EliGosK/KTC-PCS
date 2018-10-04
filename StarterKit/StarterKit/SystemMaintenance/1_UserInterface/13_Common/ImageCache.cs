using System;
using System.IO;
using System.Drawing;
using EVOFramework;
using EVOFramework.Data;
using SystemMaintenance.Oracle.DAO;
using SystemMaintenance.DTO;
using System.Collections.Generic;

namespace SystemMaintenance
{
    /// <summary>
    /// <para>Image Cache. So own process will has one instance only!!!.</para>
    /// <para>Before call GetInstance method, should be finish to create database connect.</para>
    /// </summary>
    public class ImageCache : IDisposable
    {
        #region Varaibles

        /// <summary>
        /// Singleton instance.
        /// </summary>
        private static ImageCache m_instance = null;

        /// <summary>
        /// Data access for image.
        /// </summary>
        private readonly ImageDAO m_daoImage = new ImageDAO(null);

        /// <summary>
        /// Get image item list.
        /// </summary>
        private readonly ImageItemList m_imageItemList = new ImageItemList();
        #endregion

        #region Constructor

        private ImageCache() {
            
        }

        /// <summary>
        /// Get singleton static instance.
        /// </summary>
        /// <returns></returns>
        public static ImageCache GetInstance() {
            if (m_instance == null)
                m_instance = new ImageCache();

            return m_instance;
        }

        /// <summary>
        /// Release all resource and reset singleton instance.
        /// </summary>
        public static void ReleaseInstance() {
            if (m_instance != null)
                m_instance.Dispose();
        }

        #endregion

        #region Indexer
        /// <summary>
        /// Get image from key by indexer.
        /// </summary>
        /// <param name="imageCode">Image code.</param>
        /// <returns>If not found specified image code, return null. Otherwise return ImageItem instance.</returns>
        public ImageItem this[string imageCode] {
            get {
                return this.Get(imageCode);           
            }
        }

        /// <summary>
        /// Get image from key by name.
        /// </summary>
        /// <param name="imageCode"></param>
        /// <returns>If not found specified image code, return null. Otherwise return ImageItem instance.</returns>
        public ImageItem Get(string imageCode) {
            if (!IsFoundImage(imageCode))
            {
                //throw new ApplicationException(String.Format("Not found specified key on database : \"{0}\"", imageCode));
                return null;
            }

            // return image from cache.
            return m_imageItemList[imageCode];     
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get image item list.
        /// </summary>
        public ImageItemList ImageItemList {
            get { return m_imageItemList; }
        }
        #endregion

        #region Public method
        /// <summary>
        /// Remove all cache.
        /// </summary>
        public void RemoveAllCache() {
            m_imageItemList.Clear();
        }

        /// <summary>
        /// Remvoe cahce that specific imageCode.
        /// </summary>
        /// <param name="imageCode"></param>
        public void RemoveCache(string imageCode) {            
            m_imageItemList.Remove(imageCode);
        }
        /// <summary>
        /// Get new instance of all image on database. This method will store to cache together.
        /// </summary>
        /// <returns>Image Item List</returns>
        public ImageItemList GetAllImages() {
            ImageItemList list = new ImageItemList();

            List<ImageDTO> imgList  = m_daoImage.LoadAll(CommonLib.Common.CurrentDatabase);
            for (int i=0; i<imgList.Count; i++) {

                // Convert byte array to Image.
                byte[] byteArray = imgList[i].IMAGE_BIN.StrongValue;
                MemoryStream memoryStream = new MemoryStream(byteArray);
                Image img = Image.FromStream(memoryStream);
                memoryStream.Close();

                // Add to image cache.
                ImageItem item = new ImageItem(imgList[i].IMAGE_CD.StrongValue, img);
                //m_imageItemList.Add(item);

                list.Add(item);
            }

            // Check cache which not has on.
            for (int i = 0; i < list.Count; i++) {
                if (!m_imageItemList.ContainKeys(list[i].ImageCD))
                    m_imageItemList.Add(list[i]);
            }

            return list;
        }
        /// <summary>
        /// Check if that found image.
        /// If found image and this image yet is not cache, it will cache this image.
        /// </summary>
        /// <param name="imageCode">Image Code.</param>
        /// <returns>Boolean</returns>
        public bool IsFoundImage(string imageCode) {
            if (!ImageItemList.ContainKeys(imageCode))
            {
                // Load from database and store into cache.
                ImageDTO imageDTO = m_daoImage.LoadByPK(CommonLib.Common.CurrentDatabase, new NZString(null, imageCode));

                if (imageDTO == null)
                    return false;

                // Convert byte array to Image.
                byte[] byteArray = imageDTO.IMAGE_BIN.StrongValue;
                MemoryStream memoryStream = new MemoryStream(byteArray);
                Image img = Image.FromStream(memoryStream);
                memoryStream.Close();

                // Add to image cache.
                ImageItem item = new ImageItem(imageCode, img);
                m_imageItemList.Add(item);                
            }

            return true;
        }
     
        #endregion

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            this.ImageItemList.Clear();
            m_instance = null;
        }

        #endregion
    }

    /// <summary>
    /// Represents Image Item. Contains the ImageCD and ImageBin
    /// </summary>
    public class ImageItem
    {
        private string m_strImageCD = String.Empty;
        private Image m_imgBin = null;

        #region Constructor
        public ImageItem() { }

        public ImageItem(string imageCD, Image imgBin)
        {
            this.m_strImageCD = imageCD;
            this.m_imgBin = imgBin;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Image code.
        /// </summary>
        public string ImageCD
        {
            get { return this.m_strImageCD; }
            internal set { this.m_strImageCD = value; }
        }
        /// <summary>
        /// Image binary data.
        /// </summary>
        public Image ImageBin
        {
            get { return this.m_imgBin; }
            internal set { m_imgBin = value; }
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class ImageItemList
    {
        private readonly Map<string, ImageItem> m_mapImageList = new Map<string, ImageItem>();

        #region Constructor
        
        #endregion

        #region Indexer
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"><c>IndexOutOfRangeException</c>.</exception>
        public ImageItem this[int index]
        {
            get
            {
                if (index < 0 || index > this.Count)
                    throw new IndexOutOfRangeException();

                MapKeyValue<string, ImageItem> keyValue = m_mapImageList[index];
                if (keyValue == null)
                    return null;

                return keyValue.Value;
            }
            set
            {
                if (index < 0 || index > this.Count)
                    throw new IndexOutOfRangeException();

                MapKeyValue<string, ImageItem> keyValue = m_mapImageList[index];
                if (keyValue != null)
                    keyValue.Value = value;

                throw new IndexOutOfRangeException(String.Format("Not found item at index: {0}", index));
            }
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageCD"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"><c>IndexOutOfRangeException</c>.</exception>
        public ImageItem this[string imageCD]
        {
            get {
                if (m_mapImageList.FoundKey(imageCD))
                    return m_mapImageList[imageCD].Value;

                return null;
            }
            set {
                if (m_mapImageList.FoundKey(imageCD))
                    m_mapImageList[imageCD].Value = value;

                throw new IndexOutOfRangeException(String.Format("Not found item at specified key: {0}", imageCD));
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="ArgumentNullException"><c>item</c> is null.</exception>
        /// <exception cref="ArgumentException"><c>ArgumentException</c>.</exception>
        public void Add(ImageItem item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            if (m_mapImageList.FoundKey(item.ImageCD)) 
                throw new ArgumentException(String.Format("Key: \"{0}\" has already exists.", item.ImageCD));

            this.m_mapImageList.Put(item.ImageCD, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageCD"></param>
        public void Remove(string imageCD)
        {
            this.m_mapImageList.Remove(imageCD);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Remove(ImageItem item)
        {
            this.m_mapImageList.Remove(item.ImageCD);
        }


        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return m_mapImageList.Count; }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            this.m_mapImageList.RemoveAll();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contain(ImageItem item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i] == item)
                    return true;
            }
            return false;                

            //return this.m_mapImageList.FoundKey(item.ImageCD);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageCD"></param>
        /// <returns></returns>
        public bool ContainKeys(string imageCD)
        {
            return this.m_mapImageList.FoundKey(imageCD);
        }
        //public bool ContainValues(ImageItem item)
        //{
        //    for (int i = 0; i < this.Count; i++) {
        //        if (this[i] == item)
        //            return true;
        //    }
        //    return false;                
        //}
        #endregion
    }
}
