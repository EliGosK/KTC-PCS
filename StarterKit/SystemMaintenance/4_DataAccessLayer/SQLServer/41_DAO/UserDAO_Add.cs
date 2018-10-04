using System;
using System.Text;
using EVOFramework.Database;
using SystemMaintenance.DTO;
using System.Collections.Generic;
using EVOFramework;
using System.Data;

namespace SystemMaintenance.SQLServer.DAO
{
    internal partial class UserDAO
    {
        public int ChangePassword(Database database, NZString UserCD, NZString newPassword, NZString UpdateByUser, NZString updateUserMachine)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" UPDATE TZ_USER_MS ");
            sb.AppendLine(" SET PASS = :PASSWORD");
            sb.AppendLine("     , UPD_DATE = GETDATE()");
            sb.AppendLine("     , UPD_BY = :UPD_USER");
            sb.AppendLine("     , UPD_MACHINE = :UPD_MACHINE ");
            sb.AppendLine(" WHERE UPPER_USER_ACCOUNT = :UPPER_USER_ACCOUNT");
            sb.AppendLine("   AND LOWER_USER_ACCOUNT = :LOWER_USER_ACCOUNT");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("PASSWORD", DataType.VarChar, newPassword.Value);
            req.Parameters.Add("UPPER_USER_ACCOUNT", DataType.VarChar, UserCD.StrongValue.ToUpper());
            req.Parameters.Add("LOWER_USER_ACCOUNT", DataType.VarChar, UserCD.StrongValue.ToLower());
            req.Parameters.Add("UPD_USER", DataType.VarChar, UpdateByUser.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, updateUserMachine.Value);

            return db.ExecuteNonQuery(req);
        }

        public int UpdateUserDefaultValue(Database database, NZString UserCD, NZString username, NZInt dateFormat, NZInt langCD, NZString updateUserCD, NZString updateUserMachine)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" UPDATE TZ_USER_MS ");
            sb.AppendLine(" SET ");
            sb.AppendLine("     FULL_NAME = :FULL_NAME ");
            sb.AppendLine("     , DATE_FORMAT = :DATE_FORMAT ");
            sb.AppendLine("     , LANG_CD = :LANG_CD ");
            sb.AppendLine("     , UPD_DATE = GETDATE()");
            sb.AppendLine("     , UPD_BY = :UPD_USER");
            sb.AppendLine("     , UPD_MACHINE = :UPD_MACHINE ");
            sb.AppendLine(" WHERE UPPER_USER_ACCOUNT = :UPPER_USER_ACCOUNT");
            sb.AppendLine("   AND LOWER_USER_ACCOUNT = :LOWER_USER_ACCOUNT");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("FULL_NAME", DataType.NVarChar, username.Value);
            req.Parameters.Add("DATE_FORMAT", DataType.NVarChar, dateFormat.Value);
            req.Parameters.Add("LANG_CD", DataType.NVarChar, langCD.Value);
            req.Parameters.Add("UPPER_USER_ACCOUNT", DataType.VarChar, UserCD.StrongValue.ToUpper());
            req.Parameters.Add("LOWER_USER_ACCOUNT", DataType.VarChar, UserCD.StrongValue.ToLower());
            req.Parameters.Add("UPD_USER", DataType.NVarChar, updateUserCD.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, updateUserMachine.Value);

            return db.ExecuteNonQuery(req);
        }
        public bool IsResetPassword(Database database, string UserCD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT T.PASS");
            sb.AppendLine(" FROM TZ_USER_MS T");
            sb.AppendLine(" WHERE T.UPPER_USER_ACCOUNT = :UPPER_USER_ACCOUNT");
            sb.AppendLine("   AND T.LOWER_USER_ACCOUNT = :LOWER_USER_ACCOUNT");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("UPPER_USER_ACCOUNT", DataType.VarChar, UserCD.ToUpper());
            req.Parameters.Add("LOWER_USER_ACCOUNT", DataType.VarChar, UserCD.ToLower());

            object objRet = db.ExecuteScalar(req);
            if (objRet == null || objRet == DBNull.Value || objRet.ToString() == String.Empty)
            {
                return true;
            }
            return false;
        }

        public int DeleteUser(Database database, string UserCD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" DELETE FROM TZ_USER_MS ");
            sb.AppendLine(" WHERE UPPER_USER_ACCOUNT = :UPPER_USER_ACCOUNT");
            sb.AppendLine("   AND LOWER_USER_ACCOUNT = :LOWER_USER_ACCOUNT");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("UPPER_USER_ACCOUNT", DataType.VarChar, UserCD.ToUpper());
            req.Parameters.Add("LOWER_USER_ACCOUNT", DataType.VarChar, UserCD.ToLower());

            return db.ExecuteNonQuery(req);

        }

        public bool Exist_Username(Database database, string UserCD)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT 1 FROM TZ_USER_MS T ");
            sb.AppendLine(" WHERE T.UPPER_USER_ACCOUNT = UPPER(:USER_ACCOUNT) ");
            sb.AppendLine("   AND T.LOWER_USER_ACCOUNT = LOWER(:USER_ACCOUNT) ");
            //sb.AppendLine("   AND ROWNUM = 1");
            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("USER_ACCOUNT", DataType.VarChar, UserCD);

            return (db.ExecuteQuery(req).Rows.Count > 0);
        }

        public List<UserDTO> LoadAllByGroupCD(Database database, bool ascending, string GroupCD, params UserDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" SELECT ");
            sb.AppendLine("   USER_ACCOUNT");
            sb.AppendLine("   ,MENU_SET_CD");
            sb.AppendLine("   ,GROUP_CD");
            sb.AppendLine("   ,DEPARTMENT_CD");
            sb.AppendLine("   ,LANG_CD");
            sb.AppendLine("   ,DATE_FORMAT");
            sb.AppendLine("   ,PASS");
            sb.AppendLine("   ,FULL_NAME");
            sb.AppendLine("   ,APPLY_DATE");
            sb.AppendLine("   ,FLG_RESIGN");
            sb.AppendLine("   ,FLG_ACTIVE");
            sb.AppendLine("   ,CRT_BY");
            sb.AppendLine("   ,CRT_DATE");
            sb.AppendLine("   ,CRT_MACHINE");
            sb.AppendLine("   ,UPD_BY");
            sb.AppendLine("   ,UPD_DATE");
            sb.AppendLine("   ,UPD_MACHINE");
            sb.AppendLine("   ,UPPER_USER_ACCOUNT");
            sb.AppendLine("   ,LOWER_USER_ACCOUNT");
            sb.AppendLine(" FROM TZ_USER_MS ");
            sb.AppendLine(" WHERE GROUP_CD = :GROUP_CD ");
            if (orderByColumns != null && orderByColumns.Length > 0)
            {
                sb.AppendLine(" ORDER BY ");
                string sort = ascending ? "asc" : "desc";

                for (int i = 0; i < orderByColumns.Length; i++)
                {
                    if (i == 0)
                        sb.AppendLine(String.Format("   {0} {1}", orderByColumns[i], sort));
                    else
                        sb.AppendLine(String.Format("   ,{0} {1}", orderByColumns[i], sort));
                }
            }
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("GROUP_CD", DataType.VarChar, GroupCD);
            return db.ExecuteForList<UserDTO>(req);
        }

        public int RemoveUserFromGroup(Database database, UserDTO userDTO)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" UPDATE TZ_USER_MS ");
            sb.AppendLine("    SET GROUP_CD = '',  ");
            sb.AppendLine("        UPD_BY = :UPD_BY,  ");
            sb.AppendLine("        UPD_DATE = :UPD_DATE, ");
            sb.AppendLine("        UPD_MACHINE = :UPD_MACHINE ");
            sb.AppendLine("  WHERE USER_ACCOUNT = :USER_ACCOUNT ");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("USER_ACCOUNT", DataType.NVarChar, userDTO.USER_ACCOUNT.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, userDTO.UPD_BY.Value);
            req.Parameters.Add("UPD_DATE", DataType.DateTime, userDTO.UPD_DATE.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, userDTO.UPD_MACHINE.Value);

            return db.ExecuteNonQuery(req);
        }
        public int AddUserToGroup(Database database, UserDTO userDTO)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" UPDATE TZ_USER_MS ");
            sb.AppendLine("    SET GROUP_CD = :GROUP_CD,  ");
            sb.AppendLine("        UPD_BY = :UPD_BY,  ");
            sb.AppendLine("        UPD_DATE = :UPD_DATE, ");
            sb.AppendLine("        UPD_MACHINE = :UPD_MACHINE ");
            sb.AppendLine("  WHERE USER_ACCOUNT = :USER_ACCOUNT ");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("GROUP_CD", DataType.NVarChar, userDTO.GROUP_CD.Value);
            req.Parameters.Add("USER_ACCOUNT", DataType.NVarChar, userDTO.USER_ACCOUNT.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, userDTO.UPD_BY.Value);
            req.Parameters.Add("UPD_DATE", DataType.DateTime, userDTO.UPD_DATE.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, userDTO.UPD_MACHINE.Value);

            return db.ExecuteNonQuery(req);
        }
        public List<UserDTO> LoadAllUserNotInGroup(Database database, bool ascending, string GroupCD, params UserDTO.eColumns[] orderByColumns)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" SELECT ");
            sb.AppendLine("   USER_ACCOUNT");
            sb.AppendLine("   ,MENU_SET_CD");
            sb.AppendLine("   ,GROUP_CD");
            sb.AppendLine("   ,DEPARTMENT_CD");
            sb.AppendLine("   ,LANG_CD");
            sb.AppendLine("   ,DATE_FORMAT");
            sb.AppendLine("   ,PASS");
            sb.AppendLine("   ,FULL_NAME");
            sb.AppendLine("   ,APPLY_DATE");
            sb.AppendLine("   ,FLG_RESIGN");
            sb.AppendLine("   ,FLG_ACTIVE");
            sb.AppendLine("   ,CRT_BY");
            sb.AppendLine("   ,CRT_DATE");
            sb.AppendLine("   ,CRT_MACHINE");
            sb.AppendLine("   ,UPD_BY");
            sb.AppendLine("   ,UPD_DATE");
            sb.AppendLine("   ,UPD_MACHINE");
            sb.AppendLine("   ,UPPER_USER_ACCOUNT");
            sb.AppendLine("   ,LOWER_USER_ACCOUNT");
            sb.AppendLine(" FROM TZ_USER_MS ");
            sb.AppendLine(" WHERE GROUP_CD != :GROUP_CD  OR GROUP_CD IS NULL");
            if (orderByColumns != null && orderByColumns.Length > 0)
            {
                sb.AppendLine(" ORDER BY ");
                string sort = ascending ? "asc" : "desc";

                for (int i = 0; i < orderByColumns.Length; i++)
                {
                    if (i == 0)
                        sb.AppendLine(String.Format("   {0} {1}", orderByColumns[i], sort));
                    else
                        sb.AppendLine(String.Format("   ,{0} {1}", orderByColumns[i], sort));
                }
            }
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("GROUP_CD", DataType.VarChar, GroupCD);
            return db.ExecuteForList<UserDTO>(req);
        }

        public int UpdateWithoutPK(Database database, UserDTO data, bool isPasswordChange)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            sb.AppendLine(" UPDATE TZ_USER_MS");
            sb.AppendLine(" SET ");
            sb.AppendLine("    USER_ACCOUNT=:USER_ACCOUNT");
            sb.AppendLine("    ,MENU_SET_CD=:MENU_SET_CD");
            sb.AppendLine("    ,GROUP_CD=:GROUP_CD");
            sb.AppendLine("    ,DEPARTMENT_CD=:DEPARTMENT_CD");
            sb.AppendLine("    ,LANG_CD=:LANG_CD");
            sb.AppendLine("    ,DATE_FORMAT=:DATE_FORMAT");
            if (isPasswordChange)
                sb.AppendLine("    ,PASS=:PASS");
            sb.AppendLine("    ,FULL_NAME=:FULL_NAME");
            sb.AppendLine("    ,APPLY_DATE=:APPLY_DATE");
            sb.AppendLine("    ,FLG_RESIGN=:FLG_RESIGN");
            sb.AppendLine("    ,FLG_ACTIVE=:FLG_ACTIVE");
            sb.AppendLine("    ,CRT_BY=:CRT_BY");
            sb.AppendLine("    ,CRT_DATE=:CRT_DATE");
            sb.AppendLine("    ,CRT_MACHINE=:CRT_MACHINE");
            sb.AppendLine("    ,UPD_BY=:UPD_BY");
            sb.AppendLine("    ,UPD_DATE=:UPD_DATE");
            sb.AppendLine("    ,UPD_MACHINE=:UPD_MACHINE");
            sb.AppendLine(" WHERE ");
            sb.AppendLine("    UPPER_USER_ACCOUNT=:UPPER_USER_ACCOUNT");
            sb.AppendLine("    AND LOWER_USER_ACCOUNT=:LOWER_USER_ACCOUNT");
            #endregion

            DataRequest req = new DataRequest(sb.ToString());
            #region Parameters
            req.Parameters.Add("USER_ACCOUNT", DataType.NVarChar, data.USER_ACCOUNT.Value);
            req.Parameters.Add("MENU_SET_CD", DataType.NVarChar, data.MENU_SET_CD.Value);
            req.Parameters.Add("GROUP_CD", DataType.NVarChar, data.GROUP_CD.Value);
            req.Parameters.Add("DEPARTMENT_CD", DataType.NVarChar, data.DEPARTMENT_CD.Value);
            req.Parameters.Add("LANG_CD", DataType.NVarChar, data.LANG_CD.Value);
            req.Parameters.Add("DATE_FORMAT", DataType.Number, data.DATE_FORMAT.Value);
            if (isPasswordChange)
                req.Parameters.Add("PASS", DataType.NVarChar, data.PASS.Value);
            req.Parameters.Add("FULL_NAME", DataType.NVarChar, data.FULL_NAME.Value);
            req.Parameters.Add("APPLY_DATE", DataType.DateTime, data.APPLY_DATE.Value);
            req.Parameters.Add("FLG_RESIGN", DataType.Number, data.FLG_RESIGN.Value);
            req.Parameters.Add("FLG_ACTIVE", DataType.Number, data.FLG_ACTIVE.Value);
            req.Parameters.Add("CRT_BY", DataType.NVarChar, data.CRT_BY.Value);
            req.Parameters.Add("CRT_DATE", DataType.DateTime, data.CRT_DATE.Value);
            req.Parameters.Add("CRT_MACHINE", DataType.NVarChar, data.CRT_MACHINE.Value);
            req.Parameters.Add("UPD_BY", DataType.NVarChar, data.UPD_BY.Value);
            req.Parameters.Add("UPD_DATE", DataType.DateTime, data.UPD_DATE.Value);
            req.Parameters.Add("UPD_MACHINE", DataType.NVarChar, data.UPD_MACHINE.Value);
            req.Parameters.Add("UPPER_USER_ACCOUNT", DataType.NVarChar, data.UPPER_USER_ACCOUNT.Value);
            req.Parameters.Add("LOWER_USER_ACCOUNT", DataType.NVarChar, data.LOWER_USER_ACCOUNT.Value);
            #endregion

            return db.ExecuteNonQuery(req);
        }

        public DataTable LoadPermissionTable(string strUsername)
        {
            DataTable dtPermission = null;

            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = "S_PERMISSION_LoadPcPermission";
            req.CommandType = CommandType.StoredProcedure;
            req.Parameters.Add("@pVar_USER_ACCOUNT", strUsername);

            DataSet dsResult = db.ExecuteDataSet(req);

            if (dsResult != null && dsResult.Tables.Count >= 1)
            {
                dtPermission = dsResult.Tables[0];
            }
            else
            {
                dtPermission = new DataTable();
            }

            return dtPermission;
        }

        public void RegisterMachine(Database database, string UserCD)
        {
            Database db = m_db;

            DataRequest req = new DataRequest();
            req.CommandText = @"MERGE TZ_USER_MACHINE_MS AS um
                                USING (
	                                SELECT HOST_NAME() MachineName, @UserAccount UserAccount
                                ) AS logon(MachineName, UserAccount)
                                ON (um.MACHINE_NAME = logon.MachineName)
                                WHEN MATCHED 
                                    THEN UPDATE SET um.USER_ACCOUNT = UserAccount
                                WHEN NOT MATCHED 
                                    THEN INSERT (MACHINE_NAME,USER_ACCOUNT) VALUES (logon.MachineName, logon.UserAccount);";
            req.CommandType = CommandType.Text;
            req.Parameters.Add("@UserAccount", UserCD);

            db.ExecuteNonQuery(req);
        }


        public List<UserDTO> LoadPersonInCharge(Database database)
        {
            Database db = UseDatabase(database);

            StringBuilder sb = new StringBuilder();
            #region SQL Statement
            string tableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(UserDTO));

            sb.AppendLine(" SELECT ");
            sb.AppendLine("  " + UserDTO.eColumns.USER_ACCOUNT);
            sb.AppendLine("  ," + UserDTO.eColumns.MENU_SET_CD);
            sb.AppendLine("  ," + UserDTO.eColumns.GROUP_CD);
            sb.AppendLine("  ," + UserDTO.eColumns.DEPARTMENT_CD);
            sb.AppendLine("  ," + UserDTO.eColumns.LANG_CD);
            sb.AppendLine("  ," + UserDTO.eColumns.DATE_FORMAT);
            sb.AppendLine("  ," + UserDTO.eColumns.PASS);
            sb.AppendLine("  ," + UserDTO.eColumns.FULL_NAME);
            sb.AppendLine("  ," + UserDTO.eColumns.APPLY_DATE);
            sb.AppendLine("  ," + UserDTO.eColumns.FLG_RESIGN);
            sb.AppendLine("  ," + UserDTO.eColumns.FLG_ACTIVE);
            sb.AppendLine("  ," + UserDTO.eColumns.CRT_BY);
            sb.AppendLine("  ," + UserDTO.eColumns.CRT_DATE);
            sb.AppendLine("  ," + UserDTO.eColumns.CRT_MACHINE);
            sb.AppendLine("  ," + UserDTO.eColumns.UPD_BY);
            sb.AppendLine("  ," + UserDTO.eColumns.UPD_DATE);
            sb.AppendLine("  ," + UserDTO.eColumns.UPD_MACHINE);
            sb.AppendLine("  ," + UserDTO.eColumns.UPPER_USER_ACCOUNT);
            sb.AppendLine("  ," + UserDTO.eColumns.LOWER_USER_ACCOUNT);
            sb.AppendLine(" FROM " + tableName);
            sb.AppendLine(" WHERE ISNULL(" + UserDTO.eColumns.HIDDEN_PERSON_IN_CHARGE + ",0) <> 1 ");

            #endregion

            DataRequest req = new DataRequest(sb.ToString());

            return db.ExecuteForList<UserDTO>(req);
        }
    }
}
