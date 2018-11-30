using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonTyper.Web.Models
{
    public class CharacterModel
    {
        public int CharacterID { get; private set; }
        public int CharacterClassID { get; private set; }
        public bool Alive { get; private set; }
    }
}
