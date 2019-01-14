using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Common.Models
{
    public class CharacterClassCommon : ICharacterClassCommon
    {
        public string ClassName { get; set; }
        public List<IAbilityCommon> CharacterClassAbilities { get; set; }

        // Create class for each characterclass in the game.
    }
}
