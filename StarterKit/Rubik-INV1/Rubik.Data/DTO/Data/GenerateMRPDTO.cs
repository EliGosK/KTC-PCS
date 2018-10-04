/*
 *		Author: Ms. Sansanee K
 *      Team : MOU-FUSION
 * 		Writed On 2011/06/08
 * 		Time : 05:17 PM 
 */
#region Using Namespace
using System;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Database;
using System.Collections.Generic;
#endregion

namespace Rubik.DTO {
	[Serializable()]	
	public class GenerateMRPDTO : AbstractDTO{
		#region " Enums Columns "
		
        #endregion
		
		#region " Variables "

        private NZDateTime m_dtSTART_DATE = new NZDateTime();
        private NZInt m_iRECOVER_DURATION = new NZInt();
        private NZString m_strITEM_CD_FROM = new NZString();
        private NZString m_strITEM_CD_TO = new NZString();
        private NZString m_strREMARK = new NZString();
        private NZBoolean m_bItemFlag = new NZBoolean();
        private NZString m_strUSER_CD = new NZString();
        private NZString m_strMACHINE = new NZString();
		
        #endregion
		
		#region " Constructor "
		
        #endregion

        #region " Getter and Setter properties "

        public NZDateTime START_DATE {
            get { return m_dtSTART_DATE; }
            set {
                if (value == null)
                    m_dtSTART_DATE.Value = value;
                else
                    m_dtSTART_DATE = value;
            }
        }
        public NZString ITEM_CD_FROM {
            get { return m_strITEM_CD_FROM; }
			set {
				if (value==null)
                    m_strITEM_CD_FROM.Value = value;
				else
                    m_strITEM_CD_FROM = value;
			}
		}
        public NZString ITEM_CD_TO {
            get { return m_strITEM_CD_TO; }
            set {
                if (value == null)
                    m_strITEM_CD_TO.Value = value;
                else
                    m_strITEM_CD_TO = value;
            }
        }
        public NZInt RECOVER_DURATION {
            get { return m_iRECOVER_DURATION; }
			set {
				if (value==null)
                    m_iRECOVER_DURATION.Value = value;
				else
                    m_iRECOVER_DURATION = value;
			}
		}
        public NZString REMARK {
            get { return m_strREMARK; }
            set {
                if (value == null)
                    m_strREMARK.Value = value;
                else
                    m_strREMARK = value;
            }
        }
        public NZBoolean ITEM_FLAG {
            get { return m_bItemFlag; }
            set {
                if (value == null)
                    m_bItemFlag.Value = value;
                else
                    m_bItemFlag = value;
            }
        }
        public NZString USER_CD {
            get { return m_strUSER_CD; }
            set {
                if (value == null)
                    m_strUSER_CD.Value = value;
                else
                    m_strUSER_CD = value;
            }
        }
        public NZString MACHINE {
            get { return m_strMACHINE; }
            set {
                if (value == null)
                    m_strMACHINE.Value = value;
                else
                    m_strMACHINE = value;
            }
        }
	
        #endregion
		
	}
}
	
