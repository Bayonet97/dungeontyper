using DungeonTyper.Logic.Models;

namespace DungeonTyper.Logic
{
    public interface IGameSession
    {
        Character Character { get; set; }
        GameState CurrentGameState { get; set; }
    }
}