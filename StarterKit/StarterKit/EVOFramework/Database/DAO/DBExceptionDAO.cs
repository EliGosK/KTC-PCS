using System;
using System.Data;
using System.Data.OracleClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVOFramework.Database
{
    internal class DBExceptionDAO
    {
        public DBExceptionDAO()
        {
        }

        public static void AddNew(byte[] RAW_REQUEST, string STACK_TRACE, string MESSAGE)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" INSERT INTO TZ_DB_EXCEPTION (ERR_DATE, ERR_SEQ, RAW_REQUEST, STACK_TRACE, MESSAGE) VALUES(");
            sb.AppendLine(" FNC_GET_SYSDATE, SEQ_DBERR.NEXTVAL, :RAW_REQUEST, :STACK_TRACE, :MESSAGE)");
           

            try
            {
                
                Database db = DatabaseManager.GetErrorDatabase;
                if (db.Credential.Provider == DatabaseProvider.ORACLE)
                {
                    OracleCommand comm = db.CreateConnection().CreateCommand() as OracleCommand;

                    comm.Connection.Open();
                    {
                        comm.CommandText = sb.ToString();
                        comm.CommandType = CommandType.Text;
                        comm.Parameters.Add("RAW_REQUEST", OracleType.Blob).Value = RAW_REQUEST;
                        comm.Parameters.Add("STACK_TRACE", OracleType.Clob).Value = STACK_TRACE;
                        comm.Parameters.Add("MESSAGE", OracleType.Clob).Value = MESSAGE;
                        comm.ExecuteNonQuery();

                    }
                    comm.Connection.Close();                    
                    comm.Dispose();
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
