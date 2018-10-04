/*
 *		Author: Mr.Teerayut S
 *      Team : SI-EVO
 * 		Writed On 2553/07/23
 * 		Time : 11:12 AM
 *  	This is DTO for TZ_SYS_CONFIG Table.
 *		From Templates Version : 1.0.0
 *		Last Modify Template On : 2009/08/27
 */
#region Using Namespace
using System;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Database;
using System.Collections.Generic;
#endregion

namespace Rubik.DTO
{
    [Serializable()]
    [DataTransferObject("TZ_SYS_CONFIG", typeof(eColumns))]
    public class SysConfigDTO : AbstractDTO
    {
        #region " Enums Columns "
        public enum eColumns
        {
            SYS_GROUP_ID,
            SYS_KEY,
            CHAR_DATA,
            EDIT_FLAG,

        };
        #endregion

        #region " Variables "
        private NZString m_strSYS_GROUP_ID = new NZString();
        private NZString m_strSYS_KEY = new NZString();
        private NZString m_strCHAR_DATA = new NZString();
        private NZInt m_intEDIT_FLAG = new NZInt(); 
        #endregion

        #region " Constructor "

        #endregion

        #region " Getter and Setter properties "
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "SYS_GROUP_ID", 0, 0, 30)]
        public NZString SYS_GROUP_ID
        {
            get { return m_strSYS_GROUP_ID; }
            set
            {
                if (value == null)
                    m_strSYS_GROUP_ID.Value = value;
                else
                    m_strSYS_GROUP_ID = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "SYS_KEY", 0, 0, 30)]
        public NZString SYS_KEY
        {
            get { return m_strSYS_KEY; }
            set
            {
                if (value == null)
                    m_strSYS_KEY.Value = value;
                else
                    m_strSYS_KEY = value;
            }
        }
        [Field(typeof(System.String), typeof(NZString), DataType.VarChar, "CHAR_DATA", 0, 0, 200)]
        public NZString CHAR_DATA
        {
            get { return m_strCHAR_DATA; }
            set
            {
                if (value == null)
                    m_strCHAR_DATA.Value = value;
                else
                    m_strCHAR_DATA = value;
            }
        }
        //[Field(typeof(System.Int32), typeof(NZInt), DataType.Int32, "EDIT_FLAG", 0, 0, 200)]
        public NZInt EDIT_FLAG
        {
            get { return m_intEDIT_FLAG; }
            set
            {
                if (value == null)
                    m_intEDIT_FLAG.Value = value;
                else
                    m_intEDIT_FLAG = value;
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
        public override MapKeyValue<string, List<string>> PrimaryKey
        {
            get
            {
                List<string> values = new List<string>();

                //Add MemberColums of PrimaryKey
                values.Add(eColumns.SYS_GROUP_ID.ToString());
                values.Add(eColumns.SYS_KEY.ToString());

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("PK__TZ_SYS_CONFIG__4C6B5938", values);
            }
        }
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			SysConfigDTO dto = new SysConfigDTO();
			dto.SYS_GROUP_ID = 
			dto.SYS_KEY = 
			dto.CHAR_DATA = 
		}
		*/
        #endregion
    }
}

