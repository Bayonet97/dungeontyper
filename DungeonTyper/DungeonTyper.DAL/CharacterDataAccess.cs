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
    public class CharacterDataAccess : ICharacterDataAccess
    { 
        private readonly IFactory<SqlConnection> _connectionFactory;
        private readonly ICharacterClassDataAccess _characterClassDataAccess;

        public CharacterDataAccess(IFactory<SqlConnection> connectionFactory, ICharacterClassDataAccess characterClassDataAccess)
        {
           _connectionFactory = connectionFactory;
            _characterClassDataAccess = characterClassDataAccess;
        }

        public int CreateCharacter(string characterClass, string characterName = "TempName")
        {
            int characterId;
            //var connectionString = _configuration.GetConnectionString("FontysDataBase"); //notice the structure of this string
            using (SqlConnection cnn = _connectionFactory.Create())
            {
                SqlCommand cmd = new SqlCommand("[DungeonTyper].[spCharacter_CreateNew]", cnn);

                // set command type
                cmd.CommandType = CommandType.StoredProcedure;
                // add one or more parameters
                cmd.Parameters.AddWithValue("@CharacterName", characterName);
                cmd.Parameters.AddWithValue("@ClassName", characterClass); 

                cnn.Open();

                characterId = Convert.ToInt32(cmd.ExecuteScalar());

                cnn.Close();

            }

            return characterId;
        }
        public ICharacter GetCharacterById(int id)
        {
            ICharacter character = null;
            //var connectionString = _configuration.GetConnectionString("FontysDataBase"); //notice the structure of this string
            using (SqlConnection cnn = _connectionFactory.Create())
            {
                SqlCommand cmd = new SqlCommand("[DungeonTyper].[spCharacter_GetById]", cnn);

                // set command type
                cmd.CommandType = CommandType.StoredProcedure;
                // add one or more parameters
                cmd.Parameters.AddWithValue("@CharacterId", id);

                cnn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    character = new Character(Convert.ToInt16(reader["Id"]), reader["CharacterName"].ToString(), _characterClassDataAccess.GetCharacterClassById(Convert.ToInt16(reader["CharacterClassId"])));
                }

                cnn.Close();

            }

            return character;
        }

        public string GetCountCharacterAliveAndDead()
        {
            string totalAliveAndDead = "";
            using (SqlConnection cnn = _connectionFactory.Create())
            {
                SqlCommand cmd = new SqlCommand("[DungeonTyper].[spCharacterGetAllAliveAndDeadCount]", cnn);
    
                // set command type
                cmd.CommandType = CommandType.StoredProcedure;

                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    totalAliveAndDead = "Living Adventurers: " + reader["Alive"].ToString() + " Fallen Adventurers: " + reader["Dead"].ToString();
                }
                cnn.Close();      
            }
            return totalAliveAndDead;
        }
    }
}
