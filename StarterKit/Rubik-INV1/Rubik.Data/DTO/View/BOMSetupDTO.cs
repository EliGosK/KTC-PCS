using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Database;
using Rubik.DTO;

namespace Rubik.DTO
{
    [Serializable()]
    [DataTransferObject("TB_BOM_MS", typeof(eColumns))]
    public class BOMSetupDTO : BOMDTO
    {
        #region " Enums Columns "
        public new enum eColumns
        {
            UPPER_ITEM_CD,
            LOWER_ITEM_CD,
            LEVEL,
            PATH,
            SEQ,
            UPPER_QTY,
            LOWER_QTY,
        };
        #endregion

        #region " Variables "        
        private NZInt m_iLEVEL = new NZInt();
        private NZString m_strPATH = new NZString();        
        #endregion

        #region " Constructor "

        #endregion

        #region " Getter and Setter properties "        
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Number, "LEVEL", 5, 0, 5)]
        public NZInt LEVEL
        {
            get { return m_iLEVEL; }
            set
            {
                if (value == null)
                    m_iLEVEL.Value = value;
                else
                    m_iLEVEL = value;
            }
        }

        [Field(typeof(System.String), typeof(NZString), DataType.Number, "PATH", 0, 0, 1000)]
        public NZString PATH
        {
            get { return m_strPATH; }
            set
            {
                if (value == null)
                    m_strPATH.Value = value;
                else
                    m_strPATH = value;
            }
        }

        #endregion
        
    }
}
