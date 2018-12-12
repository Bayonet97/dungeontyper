using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace DungeonTyper.DAL
{
    public class CharacterClassDataAccess : ICharacterClassDataAccess
    {
        private readonly IConfiguration _configuration;

        public CharacterClassDataAccess(IConfiguration config)
        {
            _configuration = config;
            
        }

        public string GetConnectionString(string connectionName = "GameDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        //TO DO: GET THE DATA FROM DATABASE
        public object GetCharacterClass(string characterClass)
        {
            var connectionString = _configuration.GetConnectionString("FontysDataBase"); //notice the structure of this string

            SqlConnection cnn = new SqlConnection(connectionString);

            using (SqlCommand cmd = new SqlCommand("GetCharacterClass", cnn))
            {
                // set command type
                cmd.CommandType = CommandType.StoredProcedure;
                // add one or more parameters
                cmd.Parameters.AddWithValue("@ClassName", characterClass);
            
                // the usual
                
                    return cmd.ExecuteReader();

            }
        }

        public object LoadData(string sql)
        {
            var connectionString = _configuration.GetConnectionString("FontysDataBase"); //notice the structure of this string

            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("CustOrderHist", cnn);

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // 3. add parameter to command, which will be passed to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@CustomerID", sql));
            return cnn.Query(sql);
        }
    }
    
}
