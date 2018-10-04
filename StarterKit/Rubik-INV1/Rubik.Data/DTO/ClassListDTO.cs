/*
 *		Author: Teerayut S. And Kung I.
 *      Team : SI-EVO
 * 		Writed On 2009/09/18
 * 		Time : 04:08 PM
 *  	This is DTO for TB_CLASS_LIST_MS Table.
 *		From Templates Version : 1.0.0
 *		Last Modify Template On : 2009/08/24
 */
#region Using Namespace

using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Database;
using System.Collections.Generic;
using System;
#endregion

namespace Rubik.DTO {
    [Serializable()]
    [DataTransferObject("TB_CLASS_LIST_MS", typeof(eColumns))]
    public class ClassListDTO : AbstractDTO {
        #region " Enums Columns "
        public enum eColumns {
            CLS_INFO_CD,
            CLS_CD,
            CLS_DESC,
            SEQ,
            EDIT_FLAG
        };
        #endregion

        #region " Variables "
        private NZString m_strCLS_INFO_CD = new NZString();
        private NZString m_strCLS_CD = new NZString();
        private NZString m_strCLS_DESC = new NZString();
        private NZInt m_iSEQ = new NZInt();
        private NZInt m_iEDIT_FLAG = new NZInt();
        #endregion

        #region " Constructor "

        #endregion

        #region " Getter and Setter properties "
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "CLS_INFO_CD", 0, 0, 100)]
        public NZString CLS_INFO_CD {
            get { return m_strCLS_INFO_CD; }
            set {
                if (value == null)
                    m_strCLS_INFO_CD.Value = value;
                else
                    m_strCLS_INFO_CD = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "CLS_CD", 0, 0, 8)]
        public NZString CLS_CD {
            get { return m_strCLS_CD; }
            set {
                if (value == null)
                    m_strCLS_CD.Value = value;
                else
                    m_strCLS_CD = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "CLS_DESC", 0, 0, 120)]
        public NZString CLS_DESC {
            get { return m_strCLS_DESC; }
            set {
                if (value == null)
                    m_strCLS_DESC.Value = value;
                else
                    m_strCLS_DESC = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Int32, "SEQ", 10, 0, 4)]
        public NZInt SEQ {
            get { return m_iSEQ; }
            set {
                if (value == null)
                    m_iSEQ.Value = value;
                else
                    m_iSEQ = value;
            }
        }
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Int32, "EDIT_FLAG", 10, 0, 4)]
        public NZInt EDIT_FLAG
        {
            get { return m_iEDIT_FLAG; }
            set
            {
                if (value == null)
                    m_iEDIT_FLAG.Value = value;
                else
                    m_iEDIT_FLAG = value;
            }
        }
        #endregion

        #region " Overriden method "
        /// <summary>
        /// Return array of primary key fields.
        /// </summary>
        /// <remarks>
        /// If this table mapping has not primary key, return null value.
        /// </remarks>
        public override MapKeyValue<string, List<string>> PrimaryKey {
            get {
                List<string> values = new List<string>();

                //Add MemberColums of PrimaryKey
                values.Add(eColumns.CLS_INFO_CD.ToString());
                values.Add(eColumns.CLS_CD.ToString());

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("T_CLASS_LIST_MS_PK", values);
            }
        }
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			ClassListDTO dto = new ClassListDTO();
			dto.CLS_INFO_CD = 
			dto.CLS_CD = 
			dto.CLS_DESC = 
		}
		*/
        #endregion
    }
}

