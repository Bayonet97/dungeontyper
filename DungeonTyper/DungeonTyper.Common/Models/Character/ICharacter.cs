﻿using System.Collections.Generic;

namespace DungeonTyper.Common.Models
{
    public interface ICharacter : ICreature
    {
        int CharacterId { get; }
        CharacterClass CharacterClass { get; }
        int Constitution { get; }
        int Strength { get; }
        int Dexterity { get; }
        int Intelligence { get; }
        void OpenInventory();
        void EquipItem(IItem item);
        string Attack(IAbility ability);
        void SetCharacterClass(CharacterClass characterClass);
    }
}