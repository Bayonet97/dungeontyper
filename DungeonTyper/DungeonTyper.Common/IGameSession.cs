using DungeonTyper.Common.Models;

namespace DungeonTyper.Common
{
    public interface IGameSession
    {
        Character Character { get; set; }
        GameState CurrentGameState { get; set; }
    }
}