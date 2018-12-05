using System.Collections.Generic;

namespace DungeonTyper.DAL
{
    public interface IDataAccess
    {
        string GetConnectionString(string connectionName = "GameDB");
        object LoadData(string sql);
    }
}