using DungeonTyper.Common.Utils;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DungeonTyper.DAL.Factories
{
    public class ConnectionFactory : IFactory<SqlConnection>
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public SqlConnection Create()
        {
            return new SqlConnection(_configuration.GetConnectionString("FontysDatabase"));
        }
    }
}
