using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;

namespace SystemMaintenance.DAO
{
    partial interface ILangDAO
    {
        /// <summary>
        /// Load system default language.
        /// </summary>
        /// <param name="database">Alternative database connection.</param>
        /// <returns></returns>
        string LoadSystemDefautLanguage(Database database);

        /// <summary>
        /// Load screen description by given language code.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="screenCD"></param>
        /// <param name="langCD"></param>
        /// <returns>Screen description.</returns>
        string LoadScreenDescriptionByLangCD(Database database, string screenCD, string langCD);
        
    }
}
