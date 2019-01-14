using DungeonTyper.Common.Models;
using DungeonTyper.Common.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Common.Factories
{
    public class CharacterClassFactory : IFactory<ICharacterClassCommon>
    {
        public ICharacterClassCommon Create()
        {
            return new CharacterClassCommon();
        }

    }
}
