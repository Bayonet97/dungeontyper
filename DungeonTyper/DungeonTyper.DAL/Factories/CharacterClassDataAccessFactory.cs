using System;
using System.Collections.Generic;
using System.Text;
using DungeonTyper.Common.Models;
using DungeonTyper.DAL;
using DungeonTyper.Common.Utils;
using Microsoft.Extensions.Configuration;

namespace DungeonTyper.DAL
{
    public class CharacterClassDataAccessFactory : IFactory<IDataAccess>
    {
        private readonly IConfiguration _config;
        public CharacterClassDataAccessFactory(IConfiguration config)
        {
            _config = config;
        }
        public IDataAccess Create()
        {
           return new CharacterClassDataAccess(_config);
        }
    }
}
