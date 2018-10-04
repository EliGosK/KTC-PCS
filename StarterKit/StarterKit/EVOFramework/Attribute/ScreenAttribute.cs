using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVOFramework.Windows.Forms
{
    public enum eShowAction
    {
        Normal = 0,     // Show with MDI
        Popup = 1,      // Show windowless
        PopupModal = 2,  // Show window modal.
        ExternalProgram = 3,
    }
    
    public enum eScreenType
    {
        Screen = 0,
        Dialog = 1,
        FindDialog = 2,
        Report = 3,        
        Process = 4,                
        Table = 99,
        ScreenPane = 100,
        //SystemScreen = 100,
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ScreenAttribute : Attribute
    {
        #region Variables
        /// <summary>
        /// Screen Code
        /// <para>Maxlength = 15</para>
        /// </summary>
        private string m_strCD = String.Empty;

        /// <summary>
        /// Screen Name
        /// </summary>
        private string m_strName = String.Empty;
        /// <summary>
        /// Show Action
        /// </summary>
        private eShowAction m_showAction = eShowAction.Normal;

        /// <summary>
        /// Screen Type
        /// </summary>
        private eScreenType m_screenType = eScreenType.Screen;

        /// <summary>
        /// Screen Description
        /// <para>Maxlength = 100</para>
        /// </summary>
        private string m_strDesc = String.Empty;
        #endregion

        private ScreenAttribute() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ScreenCD">Screen code, max length = 15</param>
        /// <param name="ScreenName">Screen name, max length = 50</param>
        /// <param name="ShowAction">Show Action</param>
        /// <param name="ScreenType">Screen Type</param>
        /// <param name="ScreenDesc">Screen description, max length = 100</param>
        /// <exception cref="ApplicationException"><c>ApplicationException</c>.</exception>
        public ScreenAttribute(string ScreenCD, string ScreenName, eShowAction ShowAction, eScreenType ScreenType, string ScreenDesc)
        {
            if (ScreenCD.Length > 30)
                throw new ApplicationException(String.Format("{0}-{1} value is over than {2} character", "Screen code", ScreenCD, 30));
            else
                this.m_strCD = ScreenCD;

            if (ScreenName.Length > 50)
                throw new ApplicationException(String.Format("{0}-{1} value is over than {2} character", "Screen name", ScreenName, 50));
            else
                this.m_strName = ScreenName;

            if (ScreenDesc.Length > 100)
                throw new ApplicationException(String.Format("{0}-{1} value is over than {2} character", "Screen description", ScreenDesc, 100));
            else
                this.m_strDesc = ScreenDesc;

            this.m_showAction = ShowAction;
            this.m_screenType = ScreenType;
        }

        /// <summary>
        /// Get screenID, can't modify ScreenID on runtime.
        /// </summary>
        public string ScreenCD
        {
            get { return this.m_strCD; }
        }

        public string ScreenName
        {
            get { return this.m_strName; }
        }
        public string ScreenDescription
        {
            get { return this.m_strDesc; }
        }
        public eShowAction ShowAction
        {
            get { return this.m_showAction; }
        }
        public eScreenType ScreenType
        {
            get { return this.m_screenType; }
        }

        public override string ToString()
        {
            return String.Format("{0},{1}", ScreenCD, ScreenName);
        }

        /// <summary>
        /// Get ScreenAttribute from class
        /// </summary>
        /// <param name="type">type of class</param>
        /// <returns></returns>
        public static ScreenAttribute GetScreenAttribute(Type type)
        {
            object[] objs = type.GetCustomAttributes(typeof(ScreenAttribute), false);
            if (objs == null || objs.Length == 0)
                return null;

            return objs[0] as ScreenAttribute;
        }
    }

    #region Old Code.

    ///// <summary>
    ///// Define this attribute to form class for identify business screen.
    ///// If specified this attribute, form will can display on System's MainFrame.
    ///// </summary>
    //[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    //public class ScreenAttribute : Attribute
    //{
    //    #region Constant

    //    /// <summary>
    //    /// Max length of specific screen code.
    //    /// </summary>
    //    private const int C_MAX_SCREEN_CODE = 50;
    //    /// <summary>
    //    /// Max length of specific screen name.
    //    /// </summary>
    //    private const int C_MAX_SCREEN_NAME = 100;
    //    /// <summary>
    //    /// Max length of specific screen description.
    //    /// </summary>
    //    private const int C_MAX_SCREEN_DESCRIPTION = 255;

    //    #endregion

    //    #region Variables
    //    /// <summary>
    //    /// Screen Code. It should be unique on this class and another business.
    //    /// </summary>
    //    private readonly string m_screenCode = String.Empty;
    //    /// <summary>
    //    /// Screen Name.
    //    /// </summary>
    //    private string m_screenName = String.Empty;
    //    /// <summary>
    //    /// Screen Description.
    //    /// </summary>
    //    private string m_screenDescription = String.Empty;

    //    #endregion

    //    #region Constructor

    //    public ScreenAttribute(string screenCode) {
    //        m_screenCode = screenCode;
    //    }

    //    #endregion

    //    #region Properties

    //    /// <summary>
    //    /// Screen Code. It should be unique on this class and another business.
    //    /// </summary>
    //    public string ScreenCode {
    //        get { return m_screenCode; }            
    //    }

    //    /// <summary>
    //    /// Screen Name.
    //    /// </summary>
    //    public string ScreenName {
    //        get { return m_screenName; }
    //        set { m_screenName = value; }
    //    }

    //    /// <summary>
    //    /// Screen Description.
    //    /// </summary>
    //    public string ScreenDescription {
    //        get { return m_screenDescription; }
    //        set { m_screenDescription = value; }
    //    }

    //    #endregion
    //}
    #endregion
}
