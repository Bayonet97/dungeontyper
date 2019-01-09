using DungeonTyper.Common.Factories;
using DungeonTyper.Common.Models;
using DungeonTyper.Common.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DungeonTyper.DAL
{
    public class AbilityDataAccess : IAbilityDataAccess
    {

        private readonly IConfiguration _configuration;
        private readonly IFactory<SqlConnection> _connectionFactory;

        public AbilityDataAccess(IConfiguration config, IFactory<SqlConnection> connectionFactory)
        {
            _configuration = config;
            _connectionFactory = connectionFactory;
        }

        public string GetConnectionString(string connectionName = "GameDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }
        public List<string> GetAllAbilities_CharacterClass()
        {
            List<string> allAbilities = new List<string>(); 
            using (SqlConnection cnn = _connectionFactory.Create())
            {

                SqlCommand cmd = new SqlCommand("[DungeonTyper].[spCharacterClassAbilities_GetAllByClassName]", cnn);

                // set command type
                cmd.CommandType = CommandType.StoredProcedure;

                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    allAbilities.Add(reader["AbilityName"].ToString() + (reader["CharacterClassName"] != null ? " Learned by: " + reader["CharacterClassName"].ToString() : ""));
                }
                cnn.Close();

                return allAbilities;
            }
        }

        public List<IAbility> GetCharacterClass_Abilities(ICharacterClass characterClass)
        {
            List<IAbility> allCharacterClassAbilities = new List<IAbility>();

            using (SqlConnection cnn = _connectionFactory.Create())
            {

                SqlCommand cmd = new SqlCommand("[DungeonTyper].[spCharacterClassAbilities_GetAllByClassName]", cnn);

                // set command type
                cmd.CommandType = CommandType.StoredProcedure;

                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    allCharacterClassAbilities.Add(new Ability() { AbilityName = reader["AbilityName"].ToString(), AbilityDescription = reader["AbilityDescription"].ToString() });
                }
                cnn.Close();

                return allCharacterClassAbilities;
            }
        }

        public List<IAbility> GetAllCharacter_Abilities(int characterId)
        {
            List<IAbility> allCharacterAbilities = new List<IAbility>();

            using (SqlConnection cnn = _connectionFactory.Create())
            {

                SqlCommand cmd = new SqlCommand("[DungeonTyper].[spCharacter_Abilities_GetAllNameAndDescriptionByCharacterId]", cnn);

                // set command type
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CharacterId", characterId);

                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    allCharacterAbilities.Add(new Ability() { AbilityName = reader["AbilityName"].ToString(), AbilityDescription = reader["AbilityDescription"].ToString() });
                }
                cnn.Close();

                return allCharacterAbilities;
            }
        }
        public List<string> GetAllCharacterClass_AbilitiesCount()
        {
            List<string> allCharacterClassAbilityCount = new List<string>();

            using (SqlConnection cnn = _connectionFactory.Create())
            {

                SqlCommand cmd = new SqlCommand("[DungeonTyper].[spCharacterClass_Abilities_GetAllCount]", cnn);

                // set command type
                cmd.CommandType = CommandType.StoredProcedure;

                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    allCharacterClassAbilityCount.Add(reader["ClassName"].ToString() + "has " + reader["AbilityCount"].ToString() + " Abilities.");
                }
                cnn.Close();

                return allCharacterClassAbilityCount;
            }
        }

    }

}
