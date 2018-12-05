using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using System.Linq;

namespace DungeonTyper.DAL
{
    public class AbilityDataAccess : IDataAccess
    {
        private string _connectionString;

        public AbilityDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
        public string GetConnectionString(string connectionName = "GameDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public object LoadData(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(_connectionString))
            {
                return cnn.Query(sql);
            }
        }
    }
}
