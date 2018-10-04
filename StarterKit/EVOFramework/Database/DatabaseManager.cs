using System;

namespace EVOFramework.Database
{
    public class DatabaseManager
    {

        /// <summary>
        /// Create instance to connect database.
        /// </summary>
        /// <param name="credential"></param>
        /// <returns>If can create instance return Database object. Otherwise return null.</returns>
        public static Database CreateDatabase(DatabaseCredential credential)
        {
            Database database = null;
            switch (credential.Provider)
            {
                case DatabaseProvider.ORACLE:
                    database = new OracleDatabase(credential);
                    break;
                case DatabaseProvider.SQLSERVER:
                    database = new SqlDatabase(credential);
                    break;
            }

            return database;
        }

        /// <summary>
        /// Test connection to databse.
        /// </summary>
        /// <param name="credential">Credential.</param>
        /// <returns>If test successful will return null value. Otherwise return the error item.</returns>
        public static ErrorItem TestConnection(DatabaseCredential credential)
        {

            Database db = CreateDatabase(credential);

            try
            {
                db.Open();
                db.Close();
                return null;
            }
            catch (Exception)
            {
                ErrorItem error = new ErrorItem(null, ResourceBundle.MESSAGES.SYS00001.Key, ResourceBundle.MESSAGES.SYS00001.Value);
                return error;
            }
        }
    }
}
