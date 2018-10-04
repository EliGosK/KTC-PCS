using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using EVOFramework;
using EVOFramework.Data;
using SystemMaintenance.DTO;

namespace SystemMaintenance.UIDataModel
{
    #region DTO and Collection
    /*public class MenuSubList : CollectionBase
    {
        public MenuSubList() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException">MenuGroupList index out of range.</exception>
        public MenuSub this[int index]
        {
            get
            {
                if (index < 0 || index > List.Count - 1)
                    throw new IndexOutOfRangeException("MenuGroupList index out of range.");

                return List[index] as MenuSub;
            }
            set
            {
                if (index < 0 || index > List.Count - 1)
                    throw new IndexOutOfRangeException("MenuGroupList index out of range.");

                List[index] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SubCD"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException">MenuGroupList index out of range.</exception>
        public MenuSub this[string SubCD]
        {
            get
            {
                MenuSub item = null;
                for (int i = 0; i < List.Count; i++)
                {
                    item = List[i] as MenuSub;
                    if (item.MENU_SUB_CD.StrongValue == SubCD)
                        return item;
                }

                throw new IndexOutOfRangeException("MenuGroupList index out of range.");

            }
            set
            {
                MenuSub item = null;
                for (int i = 0; i < List.Count; i++)
                {
                    item = List[i] as MenuSub;
                    if (item.MENU_SUB_CD.StrongValue == SubCD)
                    {
                        List[i] = value;
                        return;
                    }
                }

                throw new IndexOutOfRangeException("MenuGroupList index out of range.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Add(MenuSub item)
        {
            List.Add(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Remove(MenuSub item)
        {
            List.Remove(item);
        }
    }*/

    [DataTransferObject("TZ_MENU_SUB_MS", typeof(eColumns))]
    public class MenuSub : AbstractDTO
    {
        #region " Enums Columns "
        public enum eColumns
        {
            MENU_SUB_CD,
            MENU_SUB_NAME,
            MENU_SUB_DESC,
            IMAGE_CD,
            WORKFLOW_ID,
        }
        #endregion

        private NZString m_strMenuSubCD = new NZString();
        private NZString m_strMenuSubName = new NZString();
        private NZString m_strMenuSubDesc = new NZString();
        private NZString m_imageCD = new NZString();
        private NZString m_workflowID = new NZString();

        private List<MenuSubItemDTO> m_menuSubItemList = new List<MenuSubItemDTO>();

        public MenuSub() { }

        public NZString MENU_SUB_CD
        {
            get { return m_strMenuSubCD; }
            set {
                if (value == null)
                    m_strMenuSubCD.Value = value;
                else
                    m_strMenuSubCD = value;
            }
        }
        public NZString MENU_SUB_NAME
        {
            get { return m_strMenuSubName; }
            set {
                if (value == null)
                    m_strMenuSubName.Value = value;
                else
                    m_strMenuSubName = value;
            }
        }
        public NZString MENU_SUB_DESC
        {
            get { return m_strMenuSubDesc; }
            set {
                if (value == null)
                    m_strMenuSubDesc.Value = value;
                else
                    m_strMenuSubDesc = value;
            }
        }
        public NZString IMAGE_CD
        {
            get { return m_imageCD; }
            set {
                if (value == null)
                    m_imageCD.Value = value;
                else
                    m_imageCD = value;
            }
        }

        public NZString WORKFLOW_ID
        {
            get { return m_workflowID; }
            set {
                if (value == null)
                    m_workflowID.Value = value;
                else
                    m_workflowID = value;
            }
        }

        public List<MenuSubItemDTO> MenuSubItemList
        {
            get { return m_menuSubItemList; }
            set { m_menuSubItemList = value;}
        }
    }

    /*public class MenuSubItemList : CollectionBase
    {
        public MenuSubItemList() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException">MenuScreenList index out of range.</exception>
        public MenuSubItem this[int index]
        {
            get
            {
                if (index < 0 || index > List.Count - 1)
                    throw new IndexOutOfRangeException("MenuScreenList index out of range.");

                return List[index] as MenuSubItem;
            }
            set
            {
                if (index < 0 || index > List.Count - 1)
                    throw new IndexOutOfRangeException("MenuScreenList index out of range.");

                List[index] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ScreenCD"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException">MenuScreenList index out of range.</exception>
        public MenuSubItem this[string ScreenCD]
        {
            get
            {
                MenuSubItem item = null;
                for (int i = 0; i < List.Count; i++)
                {
                    item = List[i] as MenuSubItem;
                    if (item.MenuItem.DatabaseScreenData.ScreenCD.StrongValue == ScreenCD)
                        return item;
                }

                throw new IndexOutOfRangeException("MenuScreenList index out of range.");

            }
            set
            {
                MenuSubItem item = null;
                for (int i = 0; i < List.Count; i++)
                {
                    item = List[i] as MenuSubItem;
                    if (item.MenuItem.DatabaseScreenData.ScreenCD.StrongValue == ScreenCD)
                    {
                        List[i] = value;
                        return;
                    }
                }

                throw new IndexOutOfRangeException("MenuScreenList index out of range.");
            }
        }

        public void Add(MenuSubItem item)
        {
            List.Add(item);
        }
        public void Remove(MenuSubItem item)
        {
            List.Remove(item);
        }


    }*/
    /*public class MenuSubItem
    {
        private readonly DatabaseScreen m_databaseScreen = null;        
        private readonly MenuSub m_menuSub = null;

        public MenuSubItem(MenuSub menuSub, string ScreenCD)
        {
            DatabaseScreenCache cache = DatabaseScreenCache.GetInstance();
            m_databaseScreen = cache.Get(ScreenCD);                        

            //เก็บ reference Parent ProgramGroup
            m_menuSub = menuSub;
        }

        public MenuSub ParentMenuSub
        {
            get { return m_menuSub; }
        }

        public DatabaseScreen MenuItem
        {
            get { return m_databaseScreen; }
        }
    }*/

    //public class MenuProgramGroup
    //{
    //    private string m_strProgramGroupCD = String.Empty;
    //    private string m_strProgramGroupDesc = String.Empty;
    //    private MenuSubItemList m_menuSubItemList = new MenuSubItemList();
    //    private MenuSub m_menuSub = null;

    //    public MenuProgramGroup(MenuSub parentMenuSub)
    //    {
    //        m_menuSub = parentMenuSub;
    //    }

    //    public string ProgramGroupCD
    //    {
    //        get { return m_strProgramGroupCD; }
    //        set { m_strProgramGroupCD = value; }
    //    }
    //    public string ProgramGroupDesc
    //    {
    //        get { return m_strProgramGroupDesc; }
    //        set { m_strProgramGroupDesc = value; }
    //    }
    //    public MenuSubItemList MenuSubItems
    //    {
    //        get { return m_menuSubItemList; }
    //        set { m_menuSubItemList = value; }
    //    }
    //    public MenuSub ParentMenuSub
    //    {
    //        get { return m_menuSub; }
    //    }
    //}
    //public class MenuProgramGroupList : CollectionBase
    //{
    //    public MenuProgramGroupList() { }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="index"></param>
    //    /// <returns></returns>
    //    /// <exception cref="IndexOutOfRangeException">MenuSectionList index out of range.</exception>
    //    public MenuProgramGroup this[int index]
    //    {
    //        get
    //        {
    //            if (index < 0 || index > List.Count - 1)
    //                throw new IndexOutOfRangeException("MenuSectionList index out of range.");

    //            return List[index] as MenuProgramGroup;
    //        }
    //        set
    //        {
    //            if (index < 0 || index > List.Count - 1)
    //                throw new IndexOutOfRangeException("MenuSectionList index out of range.");

    //            List[index] = value;
    //        }
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="ScreenTypeCD"></param>
    //    /// <returns></returns>
    //    /// <exception cref="IndexOutOfRangeException">MenuSectionList index out of range.</exception>
    //    public MenuProgramGroup this[string ScreenTypeCD]
    //    {
    //        get
    //        {
    //            MenuProgramGroup item = null;
    //            for (int i = 0; i < List.Count; i++)
    //            {
    //                item = List[i] as MenuProgramGroup;
    //                if (item.ProgramGroupCD.ToString() == ScreenTypeCD)
    //                    return item;
    //            }

    //            throw new IndexOutOfRangeException("MenuSectionList index out of range.");

    //        }
    //        set
    //        {
    //            MenuProgramGroup item = null;
    //            for (int i = 0; i < List.Count; i++)
    //            {
    //                item = List[i] as MenuProgramGroup;
    //                if (item.ProgramGroupCD.ToString() == ScreenTypeCD)
    //                {
    //                    List[i] = value;
    //                    return;
    //                }
    //            }

    //            throw new IndexOutOfRangeException("MenuSectionList index out of range.");
    //        }
    //    }

    //    public void Add(MenuProgramGroup item)
    //    {
    //        List.Add(item);
    //    }
    //    public void Remove(MenuProgramGroup item)
    //    {
    //        List.Remove(item);
    //    }
    //}
    #endregion
}
