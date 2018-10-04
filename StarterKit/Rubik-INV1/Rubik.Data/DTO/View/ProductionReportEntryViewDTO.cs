using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Data;
using EVOFramework;
using EVOFramework.Database;

namespace Rubik.DTO
{
    [Serializable]
    [DataTransferObject("TB_INV_TRANS_TR", typeof(eColumns))]
    public class ProductionReportEntryViewDTO : AbstractDTO
    {
        #region Enum
        public enum eColumns 
        {
            TRANS_ID,
            NG_TRANS_ID,
            PROCESS_CD,
            NG_CRITERIA_CD,
            NG_CRITERIA_DESC,
            NG_WEIGHT,
            NG_QTY
        }
        #endregion

        #region Variables

        private NZString m_TRANS_ID = new NZString();
        private NZString m_NG_TRANS_ID = new NZString();
        private NZString m_PROCESS_CD = new NZString();
        private NZString m_NG_CRITERIA_CD = new NZString();
        private NZString m_NG_CRITERIA_DESC = new NZString();        
        private NZDecimal m_NG_QTY = new NZDecimal();
        private NZDecimal m_NG_WEIGHT = new NZDecimal();
        
        #endregion

        #region Properties

        public NZString TRANS_ID {
            get { return m_TRANS_ID; }
            set { m_TRANS_ID = value; }
        }
        public NZString NG_TRANS_ID {
            get { return m_NG_TRANS_ID; }
            set { m_NG_TRANS_ID = value; }
        }
        public NZString PROCESS_CD {
            get { return m_PROCESS_CD; }
            set { m_PROCESS_CD = value; }
        }
        public NZString NG_CRITERIA_CD {
            get { return m_NG_CRITERIA_CD; }
            set { m_NG_CRITERIA_CD = value; }
        }
        public NZString NG_CRITERIA_DESC
        {
            get { return m_NG_CRITERIA_DESC; }
            set { m_NG_CRITERIA_DESC = value; }
        }
        public NZDecimal NG_QTY {
            get { return m_NG_QTY; }
            set { m_NG_QTY = value; }
        }
        public NZDecimal NG_WEIGHT {
            get { return m_NG_WEIGHT; }
            set { m_NG_WEIGHT = value; }
        }

        
        #endregion      
    }
}

