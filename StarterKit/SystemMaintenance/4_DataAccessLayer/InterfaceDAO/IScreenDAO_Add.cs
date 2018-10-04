using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;
using EVOFramework;
using System.Data;
using SystemMaintenance.DTO;
using EVOFramework.Windows.Forms;

namespace SystemMaintenance.DAO
{
    public partial interface IScreenDAO
    {
        // Four steps to add Table Schema
        // 1. Check for already exist table name in TZ_SCREEN_MS
        // 2. If Table not exist then add table to TZ_SCREEN_MS
        // 3. Add Table details (column) to TZ_SCREEN_DETAIL_MS
        // 4. Add Multi Lang for Table details (column)

        bool isScreenAlreadyExist(Database database, string TableName);

        int AddTableSchema(Database database, string TableName);

        int AddTableDetail(Database database, string TableName, string Owner);

        int AddMultiLangforTableDetail(Database database, string TableName, string Owner, string[] LangCD);

        #region Screen Manager
        /// <summary>
        /// Select all screen on database.
        /// </summary>
        /// <returns>All Screens.</returns>
        DatabaseScreenList SelectScreens(Database database, NZString userLangCD, NZString defLangCD);

        /// <summary>
        /// Select the specific screen code.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="screenCD">Screen Code</param>
        /// <param name="userLangCD">User language.</param>
        /// <returns></returns>
        DatabaseScreen SelectScreen(Database database, NZString screenCD, NZString userLangCD, NZString defLangCD);

        /// <summary>
        /// Select all screen on database which is the main screen for set authorize
        /// </summary>
        /// <param name="database"></param>
        /// <param name="userLangCD"></param>
        /// <param name="defLangCD"></param>
        /// <returns></returns>
        DatabaseScreenList SelectScreenWithAuthorize(Database database, NZString userLangCD, NZString defLangCD);
        #endregion

        int DeleteByScreenCD(Database database, string ScreenCD);

        int UpdateScreenImage(Database database, ScreenDTO dto);

        void UpdateIsUsed(Database database, ScreenDTO dto);

        void ResetUsageFlag();
    }
}
