namespace DungeonTyper.DAL
{
    public interface ICharacterClassDataAccess : IDataAccess
    {
        object GetCharacterClass(string characterClass);
    }
}