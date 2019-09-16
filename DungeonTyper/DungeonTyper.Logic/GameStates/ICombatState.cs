using DungeonTyper.Logic.Models;
using DungeonTyper.Common.Models;
using ICharacter = DungeonTyper.Common.Models.ICharacter;
using ICreature = DungeonTyper.Logic.Models.ICreature;

namespace DungeonTyper.Logic.GameStates
{
    public interface ICombatState
    {
        void EndBattleDefeat();
        void EndBattleVictory();
        void HandleDamage(int damage, ICreature defender);
        void StartBattle(ICharacter character, ICreature enemy);
        void Reinstantiate(ICharacter character, ICreature enemy);
        void WriteOutput(string output);
    }
}