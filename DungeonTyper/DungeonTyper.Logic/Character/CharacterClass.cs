using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Logic.Character
{
    class CharacterClass
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public List<Ability> Abilities { get; set; }
    }
}
