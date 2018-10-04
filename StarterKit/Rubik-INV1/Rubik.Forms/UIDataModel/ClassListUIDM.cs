using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Data;
using EVOFramework;
using System.Data;
using Rubik.DTO;

namespace Rubik.UIDataModel
{
    public class ClassListUIDM : IUIDataModel
    {
        private NZString m_txtClsInfoCd = new NZString();
        private NZString m_txtClsCd = new NZString();
        private NZString m_txtClsDesc = new NZString();
        private NZInt m_txtSEQ = new NZInt();
        private NZInt m_txtEditFlag = new NZInt();
        private DataTable m_dtView = null;

        public NZString ClsInfoCd
        {
            get { return m_txtClsInfoCd; }
            set { m_txtClsInfoCd = value; }
        }
        public NZString ClsCd
        {
            get { return m_txtClsCd; }
            set { m_txtClsCd = value; }
        }
        public NZString ClsDesc
        {
            get { return m_txtClsDesc; }
            set { m_txtClsDesc = value; }
        }
        public NZInt SEQ
        {
            get { return m_txtSEQ; }
            set { m_txtSEQ = value; }
        }
        public DataTable DATA_VIEW
        {
            get { return m_dtView; }
            set { m_dtView = value; }
        }
        public NZInt EditFlag
        {
            get { return m_txtEditFlag; }
            set { m_txtEditFlag = value; }
        }
    }
}
