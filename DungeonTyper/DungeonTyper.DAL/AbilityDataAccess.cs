using DungeonTyper.Common.Factories;
using DungeonTyper.Common.Models;
using DungeonTyper.Common.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DungeonTyper.DAL
{
    public class AbilityDataAccess
    {

        private readonly IConfiguration _configuration;

        private readonly string _connectionString;

        public AbilityDataAccess(IConfiguration config)
        {
            _configuration = config;
            _connectionString = _configuration.GetConnectionString("FontysDataBase");
        }

        public List<IAbility> GetCharacterClassAbilities(ICharacterClass characterClass)
        {
            List<IAbility> allCharacterClassAbilities = new List<IAbility>();

            using (SqlConnection cnn = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand("[DungeonTyper].[spCharacterClassAbilities_GetAllByClassName]", cnn);

                // set command type
                cmd.CommandType = CommandType.StoredProcedure;

                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    allCharacterClassAbilities.Add(new Ability() { AbilityName = reader["AbilityName"].ToString(), AbilityDescription = reader["AbilityName"].ToString() });
                }
                cnn.Close();

                return allCharacterClassAbilities;
            }
        }

        public List<IAbility> GetAllCharacterAbilities(ICharacter character)
        {
            List<IAbility> allCharacterAbilities = new List<IAbility>();

            using (SqlConnection cnn = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand("[DungeonTyper].[spCharacterClassAbilities_GetAllByClassName]", cnn);

                // set command type
                cmd.CommandType = CommandType.StoredProcedure;

                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    allCharacterClassAbilities.Add(new Ability() { AbilityName = reader["AbilityName"].ToString(), AbilityDescription = reader["AbilityName"].ToString() });
                }
                cnn.Close();

                return allCharacterClassAbilities;
            }
        }
    }

}
