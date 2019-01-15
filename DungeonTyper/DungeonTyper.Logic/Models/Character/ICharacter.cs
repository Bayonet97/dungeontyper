namespace DungeonTyper.Logic.Models
{
    public interface ICharacter : ICreature
    {
        int CharacterId { get; }
        ICharacterClass CharacterClass { get; }
        int Constitution { get; }
        int Strength { get; }
        int Dexterity { get; }
        int Intelligence { get; }
        void OpenInventory();
        void EquipItem(IItem item);
        string Attack(IAbility ability);
        void SetCharacterClass(ICharacterClass characterClass);
    }
}