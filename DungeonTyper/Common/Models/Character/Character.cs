using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Common.Models
{
    public class Character : ICharacter
    {
        public string Name { get; private set; }
        public int HitPoints { get; private set; }
        public bool Alive { get; private set; }
        public List<IAbility> CharacterAbilities { get; private set; }
        public ICharacterClass CharacterClass { get; private set; }
        //public int Constitution { get; private set; }
        //public int Strength { get; private set; }
        //public int Dexterity { get; private set; }
        //public int Intelligence { get; private set; }

    }
}
