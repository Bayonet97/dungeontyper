using DungeonTyper.Common.Models;
using DungeonTyper.Common.Utils;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DungeonTyper.DAL
{
    public class AbilityDataAccess : IAbilityDataAccess
    {

        private readonly IFactory<SqlConnection> _connectionFactory;

        public AbilityDataAccess(IFactory<SqlConnection> connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public List<string> GetAllAbilities_CharacterClass()
        {
            List<string> allAbilities = new List<string>(); 
            using (SqlConnection cnn = _connectionFactory.Create())
            {

                SqlCommand cmd = new SqlCommand("[DungeonTyper].[spAbility_CharacterClass_GetAll]", cnn);

                // set command type
                cmd.CommandType = CommandType.StoredProcedure;

                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    allAbilities.Add(reader["AbilityName"].ToString() + (reader["CharacterClassName"].ToString() != "" ? " Learned by: " + reader["CharacterClassName"].ToString() : ""));
                }
                cnn.Close();

                return allAbilities;
            }
        }

        public List<IAbility> GetCharacterClass_Abilities(string className)
        {
            List<IAbility> allCharacterClassAbilities = new List<IAbility>();

            using (SqlConnection cnn = _connectionFactory.Create())
            {

                SqlCommand cmd = new SqlCommand("[DungeonTyper].[spCharacterClassAbilities_GetByName]", cnn);

                // set command type
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ClassName", className);
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    allCharacterClassAbilities.Add(new Ability() { AbilityName = reader["AbilityName"].ToString() /*, AbilityDescription = reader["AbilityDescription"].ToString()*/ });
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
