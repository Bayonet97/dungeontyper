using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Common.Models
{
    public class CharacterClass : ICharacterClass
    {
        public string ClassName { get; set; }
        public List<IAbility> CharacterClassAbilities { get; set; }

        // Create class for each characterclass in the game.
    }
}
