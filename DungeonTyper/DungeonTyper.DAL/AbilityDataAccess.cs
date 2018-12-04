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
    public class AbilityDataAccess : IAbilityDataAccess
    {
        public string GetConnectionString(string connectionName = "GameDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public object LoadData(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query(sql);
            }
        }
    }
}
