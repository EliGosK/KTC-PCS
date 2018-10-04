using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using EVOFramework.Data;

namespace Rubik.DTO 
{
    [DataTransferObject("TB_BOM_MS", typeof(eColumns))]
    public class ComponentUsageDTO : AbstractDTO
    {
        #region " Enums Columns "
        public enum eColumns 
        {            
            LOWER_ITEM_CD,
            USAGE_QTY
        };
        #endregion

        private NZString m_strLOWER_ITEM_CD = new NZString();
        private NZDecimal m_dUSAGE_QTY = new NZDecimal();

        public NZString LOWER_ITEM_CD {
            get { return m_strLOWER_ITEM_CD; }
            set {
                if (value == null)
                    m_strLOWER_ITEM_CD.Value = value;
                else
                    m_strLOWER_ITEM_CD = value;
            }
        }

        public NZDecimal USAGE_QTY {
            get { return m_dUSAGE_QTY; }
            set {
                if (value == null)
                    m_dUSAGE_QTY.Value = value;
                else
                    m_dUSAGE_QTY = value;
            }
        }
    }
}
