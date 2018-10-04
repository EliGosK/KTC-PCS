using System.Text;
using EVOFramework;
using EVOFramework.Database;
using System.Data;
using System.Collections.Generic;
using SystemMaintenance.DTO;

namespace SystemMaintenance.DAO
{
    partial interface IMenuSubDAO
    {
        /// <summary>
        /// Load all menu sub with own description depend on the specific language.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="langCD"></param>
        /// <returns></returns>
        DataTable LoadAllMenuSubWithDescription(Database database, NZString langCD);

        /// <summary>
        /// Load menu sub with own description depend on the specific language.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="menuSubCD"></param>
        /// <param name="langCD"></param>
        /// <returns></returns>
        DataTable LoadMenuSubWithDescription(Database database, NZString menuSubCD, NZString langCD);

        /// <summary>
        /// Update menu sub description depend on specific language.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="menuSubCD">Update on MenuSub CD</param>
        /// <param name="langCD">Update on Language CD</param>
        /// <param name="description">Value to update</param>
        /// <returns></returns>
        int UpdateMenuSubDescription(Database database, NZString menuSubCD, NZString langCD, NZString description);

    }
}
