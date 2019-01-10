//using DungeonTyper.Common.Models;
using DungeonTyper.Common.Utils;
using DungeonTyper.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Logic.Factories
{
    public class CharacterClassFactory : IFactory<ICharacterClass>
    {
        public ICharacterClass Create()
        {
            return new CharacterClass();
        }

    }
}
