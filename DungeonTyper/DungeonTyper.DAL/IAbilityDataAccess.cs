using System.Collections.Generic;

namespace DungeonTyper.DAL
{
    public interface IAbilityDataAccess
    {
        string GetConnectionString(string connectionName = "GameDB");
        object LoadData(string sql);
    }
}