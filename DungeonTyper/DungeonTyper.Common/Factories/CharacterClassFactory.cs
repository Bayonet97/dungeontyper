using DungeonTyper.Common.Models;
using DungeonTyper.Common.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Common.Factories
{
    public class CharacterClassFactory : IFactory<ICharacterClass>
    {
        public ICharacterClass Create()
        {
            return new CharacterClass();
        }

    }
}
