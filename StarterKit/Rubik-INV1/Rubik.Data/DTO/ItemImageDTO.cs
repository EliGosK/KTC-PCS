/*
 *		Author: Mr.Teerayut S
 *      Team : SI-EVO
 * 		Writed On 2009/10/09
 * 		Time : 04:00 PM
 *  	This is DTO for TB_ITEM_IMAGE_MS Table.
 *		From Templates Version : 1.0.0
 *		Last Modify Template On : 2009/08/27
 */
#region Using Namespace

using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Database;
using System.Collections.Generic;
#endregion

namespace Rubik.DTO
{
    [DataTransferObject("TB_ITEM_IMAGE_MS", typeof(eColumns))]
    public class ItemImageDTO : AbstractDTO
    {
        #region " Enums Columns "
        public enum eColumns
        {
            ITEM_CD,
            IMAGE
        };
        #endregion

        #region " Variables "
        private NZString m_strITEM_CD = new NZString();
        private NZByteArray m_baIMAGE = new NZByteArray();
        #endregion

        #region " Constructor "

        #endregion

        #region " Getter and Setter properties "
        [FieldNotNull]
        [Field(typeof(System.String), typeof(NZString), DataType.NVarChar, "ITEM_CD", 0, 0, 20)]
        public NZString ITEM_CD
        {
            get { return m_strITEM_CD; }
            set
            {
                if (value == null)
                    m_strITEM_CD.Value = value;
                else
                    m_strITEM_CD = value;
            }
        }
        [Field(typeof(System.Byte[]), typeof(NZByteArray), DataType.Default, "IMAGE", 0, 0, 16)]
        public NZByteArray IMAGE
        {
            get { return m_baIMAGE; }
            set
            {
                if (value == null)
                    m_baIMAGE.Value = value;
                else
                    m_baIMAGE = value;
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
                values.Add(eColumns.ITEM_CD.ToString());

                //Add PrimaryKey Name
                return new MapKeyValue<string, List<string>>("PK_TB_ITEM_IMAGE_MS", values);
            }
        }
        #endregion

        #region " Helper "
        /*
		public void SaveDTO() {
			ItemImageDTO dto = new ItemImageDTO();
			dto.ITEM_CD = 
			dto.IMAGE = 
		}
		*/
        #endregion
    }
}

