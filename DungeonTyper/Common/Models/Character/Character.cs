using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Common.Models
{
    public class Character : ICreature
    {
        public ICharacterClass CharacterClass { get; set; }
    }
}
