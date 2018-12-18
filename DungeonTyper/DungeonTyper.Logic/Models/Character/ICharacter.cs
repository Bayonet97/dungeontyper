namespace DungeonTyper.Logic.Models
{
    public interface ICharacter : ICreature
    {
        ICharacterClass CharacterClass { get; }
        int Constitution { get; }
        int Strength { get; }
        int Dexterity { get; }
        int Intelligence { get; }
        void OpenInventory();
        void EquipItem(IItem item);
        void Attack(IAbility ability);
    }
}