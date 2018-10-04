using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using EVOFramework.Data;
using SystemMaintenance.Oracle.DAO;
using SystemMaintenance.DTO;
using SystemMaintenance.BIZ;
using EVOFramework.Windows.Forms;

namespace SystemMaintenance
{
    /// <summary>
    /// Store all screen which persist on database into memory cache.
    /// </summary>
    public class DatabaseScreenCache : IDisposable
    {

        #region Variables
        private static DatabaseScreenCache m_instance = null;
        private readonly ScreenBIZ m_bizScreen = new ScreenBIZ();
        private readonly DatabaseScreenList m_databaseScreenList = new DatabaseScreenList();
        #endregion

        #region Constructor
        private DatabaseScreenCache() {            

            this.InitializeCache();
        }        

        public static DatabaseScreenCache GetInstance() {
            if (m_instance == null)
                m_instance = new DatabaseScreenCache();

            return m_instance;
        }

        public static void ReleaseInstance() {
            if (m_instance != null)
                m_instance.Dispose();
        }
        #endregion

        #region Indexer & Method Get by Index

        /// <summary>
        /// 
        /// </summary>
        /// <param name="screenCD"></param>
        /// <returns></returns>
        public DatabaseScreen this[string screenCD] {
            get {
                return this.Get(screenCD);         
            }
        }

        /// <summary>
        /// Get database screen
        /// </summary>
        /// <param name="screenCD">Specific screen code.</param>
        /// <returns></returns>
        public DatabaseScreen Get(string screenCD) {
            if (!IsFoundDatabaseScreen(screenCD))
            {
                return null;
            }

            return DatabaseScreenList[screenCD];      
        }
        #endregion

        #region Public method
        /// <summary>
        /// Initialize cache by load all data on db.
        /// </summary>
        private void InitializeCache() {
            // Load all data screen on DB to make cache.
            DatabaseScreenList listScreen = m_bizScreen.LoadScreens();

            DatabaseScreenList.Clear();
            for (int i=0; i<listScreen.Count; i++) {                
                DatabaseScreenList.Add(listScreen[i]);
            }
        }

        /// <summary>
        /// Check if that found database screen.
        /// If found database screen, will cache it.
        /// </summary>
        /// <param name="screenCode">screenCode</param>
        /// <returns>Boolean</returns>
        public bool IsFoundDatabaseScreen(string screenCode)
        {
            if (!DatabaseScreenList.ContainKeys(screenCode))
            {
                // Load from database and store into cache.
                DatabaseScreen databaseScreen = m_bizScreen.LoadScreen(new NZString(null, screenCode));

                if (databaseScreen == null)
                    return false;

                // Add to image cache.
                DatabaseScreenList.Add(databaseScreen);                
                return true;
            }

            return true;
        }

        #endregion

        #region Properties
        public DatabaseScreenList DatabaseScreenList
        {
            get { return m_databaseScreenList; }
        }
        #endregion

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            m_databaseScreenList.Clear();            
            m_instance = null;
        }

        #endregion
    }

    /// <summary>
    /// Represent data structure of DatabaseScreen.
    /// </summary>
    public class DatabaseScreen
    {
        #region Variables
        private  NZString m_strScreenCD = new NZString();
        private  NZString m_strScreenName = new NZString();
        private  NZString m_strScreenDescription = new NZString();
        private eShowAction m_screenShowAction = eShowAction.Normal;
        private eScreenType m_screenType = eScreenType.Screen;
        private  NZString m_strExternalProgram = new NZString();
        private  NZString m_iImageCD = new NZString();
        #endregion

        #region Constructor
        public DatabaseScreen()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// รหัส Screen
        /// </summary>
        public NZString ScreenCD
        {
            get { return m_strScreenCD; }
            set { m_strScreenCD = value; }
        }

        /// <summary>
        /// ชื่อ Screen ,ไม่มีผลต่อการแสดงผลหน้าจอ
        /// </summary>
        public NZString ScreenName
        {
            get { return m_strScreenName; }
            set { m_strScreenName = value; }
        }

        /// <summary>
        /// รายละเอียด Screen ซึ่งจะนำไปเป็น Title ของ Screen
        /// </summary>
        public NZString ScreenDescription
        {
            get { return m_strScreenDescription; }
            set { m_strScreenDescription = value; }
        }

        /// <summary>
        /// ประเภทของ Screen
        /// </summary>
        public eScreenType ScreenType
        {
            get { return m_screenType; }
            set { m_screenType = value; }
        }

        /// <summary>
        /// ประเภทการแสดงผลหน้าจอ
        /// </summary>
        public eShowAction ShowAction
        {
            get { return m_screenShowAction; }
            set { m_screenShowAction = value; }
        }

        /// <summary>
        /// ที่อยู่ของ External Program
        /// </summary>
        public NZString ExternalProgram
        {
            get { return m_strExternalProgram; }
            set { m_strExternalProgram = value; }
        }

        /// <summary>
        /// ตำแหน่งรูปภาพ
        /// </summary>
        public NZString ImageCD
        {
            get { return m_iImageCD; }
            set { m_iImageCD = value; }
        }
        #endregion

        #region Overriden methods
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param><exception cref="T:System.NullReferenceException">The <paramref name="obj"/> parameter is null.</exception><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj is DatabaseScreen) {
                if (this.ScreenCD.Value.Equals(((DatabaseScreen)obj).ScreenCD.Value))
                    return true;
                else {
                    return false;
                }
            }

            return base.Equals(obj);
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}",m_strScreenCD.Value,m_strScreenName.Value, m_strScreenDescription.Value);
        }
        #endregion
    }

    /// <summary>
    /// Represents list of DatabaseScreen object.
    /// </summary>
    public class DatabaseScreenList
    {

        private readonly Map<string, DatabaseScreen> m_databaseScreenList = new Map<string, DatabaseScreen>();

        #region Constructor

        #endregion

        #region Indexer
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"><c>IndexOutOfRangeException</c>.</exception>
        public DatabaseScreen this[int index]
        {
            get
            {
                if (index < 0 || index > this.Count)
                    throw new IndexOutOfRangeException();

                MapKeyValue<string, DatabaseScreen> keyValue = m_databaseScreenList[index];
                if (keyValue == null)
                    return null;

                return keyValue.Value;
            }
            set
            {
                if (index < 0 || index > this.Count)
                    throw new IndexOutOfRangeException();

                MapKeyValue<string, DatabaseScreen> keyValue = m_databaseScreenList[index];
                if (keyValue != null)
                    keyValue.Value = value;

                throw new IndexOutOfRangeException(String.Format("Not found item at index: {0}", index));
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="screenCD"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"><c>IndexOutOfRangeException</c>.</exception>
        public DatabaseScreen this[string screenCD]
        {
            get
            {
                if (m_databaseScreenList.FoundKey(screenCD))
                    return m_databaseScreenList[screenCD].Value;

                return null;
            }
            set
            {
                if (m_databaseScreenList.FoundKey(screenCD))
                    m_databaseScreenList[screenCD].Value = value;

                throw new IndexOutOfRangeException(String.Format("Not found item at specified key: {0}", screenCD));
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
        public void Add(DatabaseScreen item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            string screenCD = item.ScreenCD.NVL(string.Empty);            
            if (m_databaseScreenList.FoundKey(screenCD))
                throw new ArgumentException(String.Format("Key: \"{0}\" has already exists.", screenCD));

            this.m_databaseScreenList.Put(screenCD, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="screenCD"></param>
        public void Remove(string screenCD)
        {
            this.m_databaseScreenList.Remove(screenCD);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Remove(DatabaseScreen item)
        {
            string screenCD = item.ScreenCD.NVL(string.Empty);
            this.m_databaseScreenList.Remove(screenCD);
        }


        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return m_databaseScreenList.Count; }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            this.m_databaseScreenList.RemoveAll();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contain(DatabaseScreen item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i] == item)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="screenCD"></param>
        /// <returns></returns>
        public bool ContainKeys(string screenCD)
        {
            return this.m_databaseScreenList.FoundKey(screenCD);
        }

        #endregion

    }
}
