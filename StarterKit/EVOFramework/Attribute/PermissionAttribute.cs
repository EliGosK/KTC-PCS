using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVOFramework.Windows.Forms
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class PermissionAttribute : Attribute
    {
        public PermissionAttribute() { }

        bool m_view;
        bool m_add;
        bool m_chg;
        bool m_del;

        public PermissionAttribute(bool bView, bool bAdd, bool bChg, bool bDel) 
        {
            m_view = bView;
            m_add = bAdd;
            m_chg = bChg;
            m_del = bDel;
        }

        public bool CanView
        {
            get { return m_view; }
        }

        public bool CanAdd
        {
            get { return m_add; }
        }

        public bool CanChange
        {
            get { return m_chg; }
        }

        public bool CanDelete
        {
            get { return m_del; }
        }
    }
}
