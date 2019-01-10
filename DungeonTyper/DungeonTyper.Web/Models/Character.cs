using System;
using System.Collections.Generic;

namespace DungeonTyper.Web.Models
{
    public partial class Character
    {
        public int CharacterId { get; set; }
        public int? CharacterClassId { get; set; }
        public bool Alive { get; set; }
    }
}
