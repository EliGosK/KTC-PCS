using System;
using System.Reflection;
using EVOFramework.Windows.Forms;
using EVOFramework.Data;

namespace SystemMaintenance
{
    /* รายละเอียด 
         * =======
         * เก็บรายการ Screen จากระบบ 2 ส่วนใหญ่ๆ คือ
         *   1. SystemMaintenance Module
         *   2. Business Registered Modules.
         * 
         * ซึ่งจาก Module เหล่านี้เราจะต้องอ่านรายการ Screen ทั้งหมดจาก Assembly แล้วเก็บ Cache ไว้
         * รายการ Screen เหล่านี้เป็นข้อมูลที่ยังไม่ได้กรองออกจากข้อมูลในฐานข้อมูล
         * 
         * */

    /// <summary>
    /// Singleton internal defined class screen cache.
    /// </summary>
    public class InternalScreenCache : IDisposable
    {        
        #region Variables
        /// <summary>
        /// Store cache.
        /// </summary>
        private readonly InternalScreenList m_internalScreenList = null;

        private static InternalScreenCache m_instance = null;
        #endregion

        #region Constructor

        private InternalScreenCache() {
            m_internalScreenList = new InternalScreenList();

            InitializeInternalScreen();
        }

        private void InitializeInternalScreen() {
            Assembly assembly = Assembly.GetExecutingAssembly();
            LoadScreensFromAssembly(assembly);
        }

        public static InternalScreenCache GetInstance() {
            if (m_instance == null)
                m_instance = new InternalScreenCache();

            return m_instance;
        }

        public static void ReleaseIntance() {
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
        public InternalScreen this[string screenCD]
        {
            get
            {
                return this.Get(screenCD);
            }
        }

        /// <summary>
        /// Get internal screen
        /// </summary>
        /// <param name="screenCD">Specific screen code.</param>
        /// <returns></returns>
        public InternalScreen Get(string screenCD)
        {
            if (!IsFoundInternalScreen(screenCD))
            {
                return null;
            }

            return InternalScreenList[screenCD];
        }
        #endregion

        #region Properties
        /// <summary>
        /// Store cache.
        /// </summary>
        public InternalScreenList InternalScreenList {
            get { return m_internalScreenList; }
        }

        #endregion

        #region Public method
        /// <summary>
        /// Load all screens from assembly into cache.
        /// </summary>
        /// <param name="assembly"></param>
        public void LoadScreensFromAssembly(Assembly assembly) {            
            Type[] types = assembly.GetTypes();

            // Loop for search all type in this assembly to retrieve Screen class.
            for (int i = 0; i < types.Length; i++)
            {
                // Find class which define ScreenAttribute over class name.

                Type currentType = types[i];

                if (InternalScreen.CheckValidScreen(currentType))
                {
                    // Store Cache.
                    InternalScreen internalScreen = new InternalScreen(currentType);
                    m_internalScreenList.Add(internalScreen);
                }
            } // end for
        }       

        /// <summary>
        /// Load all screens from assembly into cache.
        /// </summary>
        /// <param name="filename"></param>
        public void LoadScreensFromAssembly(string filename) {
            LoadScreensFromAssembly(Assembly.LoadFile(filename));
        }

        /// <summary>
        /// Check if that found internal screen.
        /// If found screen, will cache it.
        /// </summary>
        /// <param name="screenCode">screenCode</param>
        /// <returns>Boolean</returns>
        public bool IsFoundInternalScreen(string screenCode)
        {
            if (!m_internalScreenList.ContainKeys(screenCode))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Get internal screen list filter by ScreenType.
        /// </summary>
        /// <param name="screenTypes">Array of ScreenType which need to filter.</param>
        /// <returns></returns>
        public InternalScreenList Get(params eScreenType[] screenTypes) {
            InternalScreenList list = new InternalScreenList();
            
            for (int i=0; i<m_internalScreenList.Count; i++) {
                InternalScreen screen = m_internalScreenList[i];
                
                for (int iType=0; iType < screenTypes.Length; iType++) {
                    if (screen.ScreenAttribute.ScreenType.Equals(screenTypes[iType])) {
                        list.Add(screen);
                    }
                }
            }

            return list;
        }
        #endregion

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            m_internalScreenList.Clear();
            m_instance = null;
        }

        #endregion
    }

    /// <summary>
    /// Represent data about internal screen.
    /// </summary>
    public class InternalScreen {
        private readonly string m_assemblyName = string.Empty;
        private readonly Type m_classType = null;
        private readonly ScreenAttribute m_screenAttribute = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="screenType"></param>
        /// <exception cref="ArgumentException">Screen Type is invalid.</exception>
        public InternalScreen(Type screenType) {
            if (!CheckValidScreen(screenType))
                throw new ArgumentException("Screen Type is invalid.");

            m_classType = screenType;
            m_assemblyName = ClassType.GetType().Assembly.FullName;
            m_screenAttribute = (ScreenAttribute)ClassType.GetCustomAttributes(typeof (ScreenAttribute), false)[0];
        }

        #region Properties
        public string AssemblyName {
            get { return m_assemblyName; }
        }

        public Type ClassType {
            get { return m_classType; }
        }

        public ScreenAttribute ScreenAttribute {
            get { return m_screenAttribute; }
        }
        #endregion

        #region static method
        /// <summary>
        /// Check the specified screen type that has corrent rule.
        /// </summary>
        /// <param name="typeScreen"></param>
        /// <returns></returns>
        internal static bool CheckValidScreen(Type typeScreen)
        {
            if (!typeScreen.IsClass)
                return false;

            if (!typeScreen.IsSubclassOf(typeof(EVOForm)))
                return false;

            object[] attributes = typeScreen.GetCustomAttributes(typeof(ScreenAttribute), false);
            if (attributes == null || attributes.Length == 0)
                return false;

            return true;
        }
        #endregion
    }

    /// <summary>
    /// Represents list of DatabaseScreen object.
    /// </summary>
    public class InternalScreenList
    {

        private readonly Map<string, InternalScreen> m_internalScreenList = new Map<string, InternalScreen>();

        #region Constructor

        #endregion

        #region Indexer
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"><c>IndexOutOfRangeException</c>.</exception>
        public InternalScreen this[int index]
        {
            get
            {
                if (index < 0 || index > this.Count)
                    throw new IndexOutOfRangeException();

                MapKeyValue<string, InternalScreen> keyValue = m_internalScreenList[index];
                if (keyValue == null)
                    return null;

                return keyValue.Value;
            }
            set
            {
                if (index < 0 || index > this.Count)
                    throw new IndexOutOfRangeException();

                MapKeyValue<string, InternalScreen> keyValue = m_internalScreenList[index];
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
        public InternalScreen this[string screenCD]
        {
            get
            {
                if (m_internalScreenList.FoundKey(screenCD))
                    return m_internalScreenList[screenCD].Value;

                return null;
            }
            set
            {
                if (m_internalScreenList.FoundKey(screenCD))
                    m_internalScreenList[screenCD].Value = value;

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
        public void Add(InternalScreen item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            string screenCD = item.ScreenAttribute.ScreenCD;
            if (m_internalScreenList.FoundKey(screenCD))
                throw new ArgumentException(String.Format("Key: \"{0}\" has already exists.", screenCD));

            this.m_internalScreenList.Put(screenCD, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="screenCD"></param>
        public void Remove(string screenCD)
        {
            this.m_internalScreenList.Remove(screenCD);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Remove(InternalScreen item)
        {
            string screenCD = item.ScreenAttribute.ScreenCD;
            this.m_internalScreenList.Remove(screenCD);
        }


        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return m_internalScreenList.Count; }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            this.m_internalScreenList.RemoveAll();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contain(InternalScreen item)
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
            return this.m_internalScreenList.FoundKey(screenCD);
        }

        #endregion

    }
}
