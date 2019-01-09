using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Logic.Models
{
    public class Character : ICharacter
    {
        public int CharacterId { get; private set; }
        public string Name { get; private set; }
        public int HitPoints { get; private set; }
        public ICharacterClass CharacterClass { get; private set; }
        public int Constitution { get; private set; }
        public int Strength { get; private set; }
        public int Dexterity { get; private set; }
        public int Intelligence { get; private set; }

        public void Attack(IAbility ability)
        {
            throw new NotImplementedException();
        }

        public void EquipItem(IItem item)
        {
            throw new NotImplementedException();
        }

        public void OpenInventory()
        {
            throw new NotImplementedException();
        }

        public void SetCharacterClass(ICharacterClass characterClass)
        {
            CharacterClass = characterClass;
        }
    }
}
