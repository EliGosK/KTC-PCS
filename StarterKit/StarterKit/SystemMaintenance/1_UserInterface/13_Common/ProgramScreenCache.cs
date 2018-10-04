using System;
using EVOFramework.Data;
using SystemMaintenance.DTO;
using EVOFramework.Windows.Forms;

namespace SystemMaintenance
{
    /// <summary>
    /// <para>Screen Cache. So own process will has one instance only!!!.</para>
    /// <para>Before call GetInstance method, should be finish to create database connect.</para>
    /// </summary>
    public class ProgramScreenCache : IDisposable
    {
        /// <summary>
        /// Reason for check found screen code.
        /// </summary>
        public enum eFoundReason {
            /// <summary>
            /// Found screen code on both of InternalScreen and DatabaseScreen.
            /// </summary>
            FoundOnBothScreen = 0,

            /// <summary>
            /// Found screen code on InternalScreen only.
            /// </summary>
            FoundOnInternalScreen,

            /// <summary>
            /// Found screen code on DatabaseScreen only.
            /// </summary>
            FoundOnDatabaseScreen,

            /// <summary>
            /// Not found on the both.
            /// </summary>
            NotFoundOnBoth,
        }
                
        #region Variables
        /// <summary>
        /// Singleton instance.
        /// </summary>
        private static ProgramScreenCache m_instance = null;

        private readonly InternalScreenCache m_internalScreenCache = null;
        private readonly DatabaseScreenCache m_databaseScreenCache = null;        

        /// <summary>
        /// Get program screen list.
        /// </summary>
        private readonly ProgramScreenList m_programScreenList = new ProgramScreenList();
        #endregion

        #region Constructor       
        private ProgramScreenCache()
        {
            m_internalScreenCache = InternalScreenCache.GetInstance();
            m_databaseScreenCache = DatabaseScreenCache.GetInstance();

            InitializeProgramScreens();
        }

        /// <summary>
        /// Initialize program screen cache.
        /// If any time has change, should be dispose and call GetInstance method again to reset cache.
        /// </summary>
        private void InitializeProgramScreens() {
            m_programScreenList.Clear();

            for (int i=0; i<m_internalScreenCache.InternalScreenList.Count; i++) {
                InternalScreen internalScreen = m_internalScreenCache.InternalScreenList[i];

                if (m_databaseScreenCache.IsFoundDatabaseScreen(internalScreen.ScreenAttribute.ScreenCD)) {

                    // Store program screen cache.
                    ProgramScreen programScreen = new ProgramScreen(internalScreen, m_databaseScreenCache[internalScreen.ScreenAttribute.ScreenCD]);
                    m_programScreenList.Add(programScreen);
                }
            }
        }

        /// <summary>
        /// Get singleton static instance.
        /// </summary>
        /// <returns></returns>
        public static ProgramScreenCache GetInstance() {
            if (m_instance == null)
                m_instance = new ProgramScreenCache();

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
        /// <param name="screenCode">Screen code.</param>
        /// <returns>Image object.</returns>
        /// <exception cref="ApplicationException"><c>ApplicationException</c>.</exception>
        public ProgramScreen this[string screenCode]
        {
            get
            {
                if (!IsFoundProgramScreen(screenCode))
                {
#warning Save log: Not found specified key on database
                    //throw new ApplicationException(String.Format("Not found specified key on database : \"{0}\"", screenCode));
                    return null;
                }

                // return image from cache.
                return m_programScreenList[screenCode];
            }
        }
        #endregion

        #region Public method
        /// <summary>
        /// Check if that found specified screen CD.
        /// If found screen it will cache this screen.
        /// </summary>
        /// <param name="screenCD">Screen Code.</param>
        /// <returns>Boolean</returns>
        public eFoundReason GetFoundScreenReason(string screenCD)
        {                        
            if (m_internalScreenCache.Get(screenCD) != null && m_databaseScreenCache.Get(screenCD) != null) {
                return eFoundReason.FoundOnBothScreen;
            }
            
            if (m_internalScreenCache.Get(screenCD) != null && m_databaseScreenCache.Get(screenCD) == null) {
                return eFoundReason.FoundOnDatabaseScreen;
            }
            
            if (m_internalScreenCache.Get(screenCD) == null && m_databaseScreenCache.Get(screenCD) != null)
            {
                return eFoundReason.FoundOnInternalScreen;
            } 

            return eFoundReason.NotFoundOnBoth;           
        }

        /// <summary>
        /// Check if found program screen.
        /// </summary>
        /// <param name="screenCD"></param>
        /// <returns>True if found program screen. Otherwise not found program screen.</returns>
        public bool IsFoundProgramScreen(string screenCD) {
            if (GetFoundScreenReason(screenCD) == eFoundReason.FoundOnBothScreen) {
                return true;
            }

            return false;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get program screen list.
        /// </summary>
        public ProgramScreenList ProgramScreenList {
            get { return m_programScreenList; }
        }
        #endregion

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            this.ProgramScreenList.Clear();
            m_instance = null;
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class ProgramScreen
    {
        private readonly InternalScreen m_internalScreen = null;
        private readonly DatabaseScreen m_databaseScreen = null;

        public ProgramScreen(InternalScreen internalScreen, DatabaseScreen databaseScreen)
        {
            this.m_internalScreen = internalScreen;
            this.m_databaseScreen = databaseScreen;

        }

        /// <summary>
        /// Create screen with parameters
        /// </summary>
        /// <param name="args">If no has parameter, input null value.</param>
        public void CreateScreen(params object[] args) {
            object obj = Activator.CreateInstance(this.m_internalScreen.ClassType, args);
            EVOForm form = (EVOForm)obj;

            if (m_databaseScreen.ScreenType == eScreenType.ScreenPane)
            {
                if (m_internalScreen.ClassType.IsSubclassOf(typeof(SystemMaintenance.Forms.CustomizeListPaneBaseForm)))
                {
                    InternalVariable.MenuFrame_Instance.AssignFormToScreenPane(form);
                    return;
                }

                form.ShowInTaskbar = true;
                form.Show();
            }
            else if (m_databaseScreen.ScreenType == eScreenType.Screen)
            {
                form.ShowInTaskbar = true;
                form.ShowDialog();
            }
            else
            {
                form.ShowInTaskbar = true;
                form.Show();
            }
        }
        //public Type ClassType { get; set; }
        //public string ScreenCD { get; set; }
        //public string ScreenName { get; set; }
        //public string ScreenDescription { get; set; }
        //public eShowAction ShowAction { get; set; }
        //public string ExternalProgram { get; set; }
        //public string ImageCD { get; set; }
        //public eScreenType ScreenType { get; set; }

        /// <summary>
        /// Get information about internal screen.
        /// </summary>
        public InternalScreen InternalScreenData
        {
            get { return m_internalScreen; }
        }

        /// <summary>
        /// Get information about database screen.
        /// </summary>
        public DatabaseScreen DatabaseScreenData
        {
            get { return m_databaseScreen; }
        }

        #region Properties

        ///// <summary>
        ///// Get or set Type reference of Screen for reflection process.
        ///// </summary>
        //public Type ClassType
        //{
        //    get { return m_internalScreen.ClassType; }
        //    set { m_internalScreen.ClassType = value; }
        //}

        ///// <summary>
        ///// Get or set screen ID
        ///// </summary>
        //public string ScreenCD
        //{
        //    get { return m_databaseScreen.ScreenCD; }
        //    set { m_databaseScreen.ScreenCD = value; }
        //}

        ///// <summary>
        ///// Get or set screen name.
        ///// </summary>
        //public string ScreenName
        //{
        //    get { return m_databaseScreen.ScreenName; }
        //    set { m_databaseScreen.ScreenName = value; }
        //}

        ///// <summary>
        ///// Get or set screen description.
        ///// </summary>
        //public string ScreenDescription
        //{
        //    get { return m_databaseScreen.ScreenDescription; }
        //    set { m_databaseScreen.ScreenDescription = value; }
        //}

        ///// <summary>
        ///// Get or set ScreenKind.
        ///// Window or Popup
        ///// </summary>
        //public eShowAction ShowAction
        //{
        //    get { return m_databaseScreen.ShowAction; }
        //    set { m_databaseScreen.ShowAction = value; }
        //}

        ///// <summary>
        ///// Get or set external program.
        ///// </summary>
        //public string ExternalProgram
        //{
        //    get { return m_databaseScreen.ExternalProgram; }
        //    set { m_databaseScreen.ExternalProgram = value; }
        //}

        ///// <summary>
        ///// Get or set Image index.
        ///// </summary>
        //public string ImageCD
        //{
        //    get { return m_databaseScreen.ImageCD; }
        //    set { m_databaseScreen.ImageCD = value; }
        //}

        //public eScreenType ScreenType
        //{
        //    get { return m_databaseScreen.ScreenType; }
        //    set { m_databaseScreen.ScreenType = value; }
        //}
        #endregion

        #region Public method
        public bool CheckFoundScreen(ScreenDTO data)
        {
            return true;
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class ProgramScreenList
    {
        private readonly Map<string, ProgramScreen> m_programScreenList = new Map<string, ProgramScreen>();

        #region Constructor

        #endregion

        #region Indexer
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"><c>IndexOutOfRangeException</c>.</exception>
        public ProgramScreen this[int index]
        {
            get
            {
                if (index < 0 || index > this.Count)
                    throw new IndexOutOfRangeException();

                MapKeyValue<string, ProgramScreen> keyValue = m_programScreenList[index];
                if (keyValue == null)
                    return null;

                return keyValue.Value;
            }
            set
            {
                if (index < 0 || index > this.Count)
                    throw new IndexOutOfRangeException();

                MapKeyValue<string, ProgramScreen> keyValue = m_programScreenList[index];
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
        public ProgramScreen this[string screenCD]
        {
            get
            {
                if (m_programScreenList.FoundKey(screenCD))
                    return m_programScreenList[screenCD].Value;

                return null;
            }
            set
            {
                if (m_programScreenList.FoundKey(screenCD))
                    m_programScreenList[screenCD].Value = value;

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
        public void Add(ProgramScreen item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            if (m_programScreenList.FoundKey(item.DatabaseScreenData.ScreenCD.StrongValue))
                throw new ArgumentException(String.Format("Key: \"{0}\" has already exists.", item.DatabaseScreenData.ImageCD.StrongValue));

            this.m_programScreenList.Put(item.DatabaseScreenData.ScreenCD.StrongValue, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="screenCD"></param>
        public void Remove(string screenCD)
        {
            this.m_programScreenList.Remove(screenCD);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Remove(ProgramScreen item)
        {
            this.m_programScreenList.Remove(item.DatabaseScreenData.ScreenCD.StrongValue);
        }


        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return m_programScreenList.Count; }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            this.m_programScreenList.RemoveAll();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contain(ProgramScreen item)
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
            return this.m_programScreenList.FoundKey(screenCD);
        }

        
        #endregion

        #region Overriden method
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return "Count: " + this.Count;
        }
        #endregion
    }
    
}
