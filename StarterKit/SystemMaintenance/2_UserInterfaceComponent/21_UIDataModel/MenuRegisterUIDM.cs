using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;

namespace SystemMaintenance.UIDM
{
    /// <summary>
    /// Structure of MenuList to display, so contain MenuSet and child MenuSub.
    /// </summary>
    public class MenuRegisterUIDM
    {
        public class MenuSet
        {
            private NZString m_MENU_SET_CD = new NZString();
            private NZString m_MENU_SET_NAME = new NZString();
            private readonly List<MenuSub> m_listMenuSub = new List<MenuSub>();

            

            public List<MenuSub> ListMenuSub {
                get { return m_listMenuSub; }
            }

            public NZString MENU_SET_CD {
                get { return m_MENU_SET_CD; }
                set { m_MENU_SET_CD = value; }
            }

            public NZString MENU_SET_NAME {
                get { return m_MENU_SET_NAME; }
                set { m_MENU_SET_NAME = value; }
            }
        }
        public class MenuSub {

            private readonly MenuSet m_parent = null;
            private NZString m_MENU_SUB_CD = new NZString();
            private NZString m_MENU_SUB_NAME = new NZString();
            private NZString m_MENU_SUB_DESC = new NZString();
            

            public MenuSub(MenuSet menuSet) {
                m_parent = menuSet;
            }                       

            public MenuSet Parent {
                get { return m_parent; }
            }

            public NZString MENU_SUB_CD {
                get { return m_MENU_SUB_CD; }
                set { m_MENU_SUB_CD = value; }
            }

            public NZString MENU_SUB_NAME {
                get { return m_MENU_SUB_NAME; }
                set { m_MENU_SUB_NAME = value; }
            }

            public NZString MENU_SUB_DESC {
                get { return m_MENU_SUB_DESC; }
                set { m_MENU_SUB_DESC = value; }
            }
        }

        private readonly List<MenuSet> m_listMenuSet = new List<MenuSet>();

        /// <summary>
        /// Get list of menu hierachy.
        /// </summary>
        public List<MenuSet> ListMenuHierachy {
            get { return m_listMenuSet; }
        }
    }
}
