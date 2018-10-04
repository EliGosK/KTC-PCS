//Create Date 12 Oct 2010
//Author: Bunyapat L.
//Object Name: Base DAO
//Description: Parent class of all DAO to share method


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;
using EVOFramework;

namespace Rubik.DAO
{
    public abstract class BaseDAO
    {
        protected Database m_db;


        public Database CurrentDatabase
        {
            get { return m_db; }
        }
        protected Database UseDatabase(Database specificDB)
        {
            if (specificDB != null)
                return specificDB;

            if (this.m_db != null)
                return this.m_db;

            throw new DataAccessException(ResourceBundle.ALL.S_CANNOT_USE_DB);
        }

        protected object CheckNull(object oInput)
        {
            if (oInput == null || oInput.ToString() == "")
                return DBNull.Value;
            else
                return oInput;
        }
    }
}
