/*
 *		Author: Teerayut S. And Kung I.
 *      Team : SI-EVO
 * 		Writed On 2009/09/16
 * 		Time : 11:08 AM
 *  	This is DTO for TZ_FAVORITE Table.
 *		From Templates Version : 1.0.0
 *		Last Modify Template On : 2009/08/24
 */
#region Using Namespace

using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Database;
using System.Collections.Generic;
#endregion

namespace SystemMaintenance.DTO
{
    [DataTransferObject("TZ_FAVORITE", typeof(eColumns))]
    public class MenuFavoriteDTO : AbstractDTO
    {
        #region " Enums Columns "
        public enum eColumns
        {
            USER_ACCOUNT,
            SCREEN_CD,
            SEQ
        };
        #endregion

        #region " Variables "
        private NZString m_strUSER_ACCOUNT = new NZString();
        private NZString m_strSCREEN_CD = new NZString();
        private NZInt m_iSEQ = new NZInt();
        #endregion

        #region " Constructor "

        #endregion

        #region " Getter and Setter properties "
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "USER_ACCOUNT", 0, 0, 30)]
        public NZString USER_ACCOUNT
        {
            get { return m_strUSER_ACCOUNT; }
            set
            {
                if (value == null)
                    m_strUSER_ACCOUNT.Value = value;
                else
                    m_strUSER_ACCOUNT = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "SCREEN_CD", 0, 0, 60)]
        public NZString SCREEN_CD
        {
            get { return m_strSCREEN_CD; }
            set
            {
                if (value == null)
                    m_strSCREEN_CD.Value = value;
                else
                    m_strSCREEN_CD = value;
            }
        }
        [FieldNotNull]
        [Field(typeof(System.Int32), typeof(NZInt), DataType.Number, "SEQ", 3, 0, 0)]
        public NZInt SEQ
        {
            get { return m_iSEQ; }
            set
            {
                if (value == null)
                    m_iSEQ.Value = value;
                else
                    m_iSEQ = value;
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
                values.Add(eColumns.USER_ACCOUNT.ToString());
                values.Add(eColumns.SCREEN_CD.ToString());

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("TZ_FAVORITE_PK", values);
            }
        }
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			MenuFavoriteDTO dto = new MenuFavoriteDTO();
			dto.USER_ACCOUNT = 
			dto.SCREEN_CD = 
			dto.SEQ = 
		}
		*/
        #endregion
    }
}

