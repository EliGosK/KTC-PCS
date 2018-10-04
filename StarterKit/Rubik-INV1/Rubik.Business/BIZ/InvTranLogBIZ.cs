using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rubik.DAO;
using Rubik.DTO;
using EVOFramework.Data;
using System.Data;

namespace Rubik.BIZ
{
    public class InvTranLogBIZ
    {
        public System.Data.DataTable LoadAllInvTranLogPeriod(EVOFramework.NZDateTime FromDate, EVOFramework.NZDateTime ToDate, EVOFramework.NZString ScreenType)
        {
            //EVOFramework.Database.DatabaseCredential dbCre = CommonLib.Common.CurrentDatabase.Credential;//new EVOFramework.Database.DatabaseCredential ();
            //dbCre.DatabaseName = dbCre.DatabaseName + "_HIST";


            EVOFramework.Database.DatabaseCredential dbCre = new EVOFramework.Database.DatabaseCredential();
            dbCre.DatabaseName = CommonLib.Common.CurrentDatabase.Credential.DatabaseName + "_HIST";
            dbCre.Password = CommonLib.Common.CurrentDatabase.Credential.Password;
            dbCre.Provider = CommonLib.Common.CurrentDatabase.Credential.Provider;
            dbCre.ServerName = CommonLib.Common.CurrentDatabase.Credential.ServerName;
            dbCre.Username = CommonLib.Common.CurrentDatabase.Credential.Username;

            EVOFramework.Database.Database db = EVOFramework.Database.DatabaseManager.CreateDatabase(dbCre);
            InvTranLogDAO dao = new InvTranLogDAO(db);
            List<InvTranLogDTO> dtoList = dao.LoadAllInvTranLogPeriod(db, FromDate, ToDate, ScreenType);
            return DTOUtility.ConvertListToDataTable(dtoList);
        }


        public DataTable LoadLogData(LogInquiryCriteriaDTO criteria)
        {
            EVOFramework.Database.DatabaseCredential dbCre = new EVOFramework.Database.DatabaseCredential();
            dbCre.DatabaseName = CommonLib.Common.CurrentDatabase.Credential.DatabaseName + "_HIST";
            dbCre.Password = CommonLib.Common.CurrentDatabase.Credential.Password;
            dbCre.Provider = CommonLib.Common.CurrentDatabase.Credential.Provider;
            dbCre.ServerName = CommonLib.Common.CurrentDatabase.Credential.ServerName;
            dbCre.Username = CommonLib.Common.CurrentDatabase.Credential.Username;

            EVOFramework.Database.Database db = EVOFramework.Database.DatabaseManager.CreateDatabase(dbCre);
            InvTranLogDAO dao = new InvTranLogDAO(db);
            return dao.LoadLogData(null, criteria);
        }
    }
}
