using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Database;
using System.Data;
using Rubik.DTO;


namespace Rubik.DAO
{
    public class QueryLunchDAO
    {
        private readonly Database m_db;

        private QueryLunchDAO() { }

        public QueryLunchDAO(Database db)
        {
            this.m_db = db;
        }

        public DataSet ExecuteSQLCommand(QueryLunchDTO dto)
        {
            Database db = m_db;
            string sql = @" begin tran
                            exec (@SqlCommand)
                            rollback";

            DataRequest req = new DataRequest();
            req.CommandText = sql;
            req.CommandType = CommandType.Text;


            req.Parameters.Add("@SqlCommand", dto.SQLCommand.Value);
            return db.ExecuteDataSet(req);
        }

        public DataTable GetQueryList()
        {
            Database db = m_db;
            string sql = @"select * from " + EVOFramework.Data.DTOUtility.ReadTableName(typeof(QueryLunchDTO));

            DataRequest req = new DataRequest();
            req.CommandText = sql;
            req.CommandType = CommandType.Text;
            DataSet ds = db.ExecuteDataSet(req);

            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }

        }
    }
}
