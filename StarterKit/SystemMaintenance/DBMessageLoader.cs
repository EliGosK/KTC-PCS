using System;
using EVOFramework;
using EVOFramework.Database;
using SystemMaintenance.Oracle.DAO;
using SystemMaintenance.DTO;
using CommonLib;


namespace SystemMaintenance
{
    /// <summary>
    /// Load message from database.
    /// </summary>
    public class DBMessageLoader : IMessageLoader
    {
        #region Variables        
        private readonly MessageDAO m_dao;
        private string m_languageCode = String.Empty;
        #endregion

        #region Constructor

        public DBMessageLoader(Database db) : this(db, String.Empty) {
            this.m_languageCode = Common.SystemLanguage.StrongValue;
        }

        /// <summary>
        /// Lanaugage of message will dependency by language code.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="languageCode"></param>
        public DBMessageLoader(Database db, string languageCode) {
            this.m_dao = new MessageDAO(db);            
            this.m_languageCode = languageCode;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Get or set language code.
        /// </summary>
        public string LanguageCode
        {
            get { return m_languageCode; }
            set { m_languageCode = value; }
        }
        #endregion

        #region IMessageLoader Members

        /// <summary>
        /// Load message description
        /// </summary>
        /// <param name="msgCode">Message Code.</param>        
        /// <returns>Description.</returns>
        public string LoadDecription(string msgCode)
        {            
            // Select between two language.
            NZString languageCD = new NZString();
            if (Common.CurrentUserInfomation != null)
                languageCD = Common.CurrentUserInfomation.LanguageCD;
            else {
                languageCD = Common.SystemLanguage;
            }

            MessageDTO dto = this.m_dao.LoadByPK(null, 
                new NZString(null, msgCode),
                languageCD);           

            if (dto == null)
                return String.Format(ResourceBundle.ALL.S_NOT_FOUND_MESSAGE_CODE, msgCode, languageCD.StrongValue);

            return dto.MSG_DESC.StrongValue;            
        }

        #endregion
    }
}
