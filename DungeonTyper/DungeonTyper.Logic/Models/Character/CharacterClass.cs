using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Logic.Models
{
    public class CharacterClass : ICharacterClass
    {
        public string ClassName { get; set; }
        public List<Ability> ClassAbilities { get; set; }

        // Create class for each characterclass in the game.
    }
}
