using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using System.Linq;
using Microsoft.Extensions.Configuration;
using DungeonTyper.Common.Models;
using DungeonTyper.Common.Factories;
using DungeonTyper.Common.Utils;

namespace DungeonTyper.DAL
{
    public class CharacterClassDataAccess : ICharacterClassDataAccess
    {
        private readonly IConfiguration _configuration;
        private readonly IFactory<ICharacterClass> _characterClassFactory = new CharacterClassFactory();
        private readonly string _connectionString;
        public CharacterClassDataAccess(IConfiguration config)
        {
            _configuration = config;
            _connectionString = _configuration.GetConnectionString("FontysDataBase");
        }

        public string GetConnectionString(string connectionName = "GameDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public ICharacterClass GetCharacterClass(string characterClass)
        {
            //var connectionString = _configuration.GetConnectionString("FontysDataBase"); //notice the structure of this string

            ICharacterClass chosenClass = _characterClassFactory.Create();

            using (SqlConnection cnn = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand("[DungeonTyper].[spCharacterClass_GetByName]", cnn);

                // set command type
                cmd.CommandType = CommandType.StoredProcedure;
                // add one or more parameters
                cmd.Parameters.AddWithValue("@ClassName", characterClass);

                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    chosenClass.ClassName = reader["ClassName"].ToString();
                }
                cnn.Close();

                return chosenClass;
            }
        }

        public List<ICharacterClass> GetAllCharacterClasses()
        {
            List<ICharacterClass> allCharacterClasses = new List<ICharacterClass>();

            using (SqlConnection cnn = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand("[DungeonTyper].[spCharacterClass_GetAll]", cnn);

                // set command type
                cmd.CommandType = CommandType.StoredProcedure;

                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    allCharacterClasses.Add(new CharacterClass() { ClassName = reader["ClassName"].ToString() });
                }
                cnn.Close();

                return allCharacterClasses;
            }
        }
    }
}
}
