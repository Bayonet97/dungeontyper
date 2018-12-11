using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Logic.Character
{
    class CharacterClass
    {
        public int CharacterClassId { get; set; }
        public string Name { get; set; }
        public List<Ability> Abilities { get; set; }
    }
}
