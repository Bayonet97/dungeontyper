using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Common.Models
{
    public class Character : ICharacter
    {
        public int CharacterId { get; private set; }
        public string Name { get; private set; }
        public int HitPoints { get; private set; }
        public bool Alive { get; private set; }
        public List<IAbility> CharacterAbilities { get; private set; }
        public ICharacterClass CharacterClass { get; private set; }
        //public int Constitution { get; private set; }
        //public int Strength { get; private set; }
        //public int Dexterity { get; private set; }
        //public int Intelligence { get; private set; }

        public Character (int characterId, string name, ICharacterClass characterClass, bool alive)
        {
            CharacterId = characterId;
            Name = name;
            CharacterClass = characterClass;
            Alive = alive;
        }
    }
}
