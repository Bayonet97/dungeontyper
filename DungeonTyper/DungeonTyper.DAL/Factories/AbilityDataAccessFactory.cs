using System;
using System.Collections.Generic;
using System.Text;
using DungeonTyper.Common.Models;
using DungeonTyper.DAL;
using DungeonTyper.Common.Utils;
using Microsoft.Extensions.Configuration;

namespace DungeonTyper.DAL
{
    public class AbilityDataAccessFactory : IFactory<IDataAccess>
    {
        private readonly IConfiguration _config;
        public AbilityDataAccessFactory(IConfiguration config)
        {
            _config = config;
        }
        public IDataAccess Create()
        {
           return new AbilityDataAccess(_config);
        }
    }
}
