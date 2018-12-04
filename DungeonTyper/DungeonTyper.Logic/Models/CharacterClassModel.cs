using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Logic.Models
{
    class CharacterClassModel
    {
        public int CharacterClassId { get; set; }
        public string Name { get; set; }
        public List<AbilityModel> Abilities { get; set; }
    }
}
