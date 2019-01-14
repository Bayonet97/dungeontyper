using System.Collections.Generic;

namespace DungeonTyper.Common.Models
{
    public interface ICharacterCommon : ICreatureCommon
    {
        int CharacterId { get; }
        CharacterClassCommon CharacterClass { get; }
        int Constitution { get; }
        int Strength { get; }
        int Dexterity { get; }
        int Intelligence { get; }
        void OpenInventory();
        void EquipItem(IItem item);
        string Attack(IAbilityCommon ability);
        void SetCharacterClass(CharacterClassCommon characterClass);
    }
}