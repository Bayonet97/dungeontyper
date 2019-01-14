using DungeonTyper.Logic.Models;
using DungeonTyper.Common.Models;
using ICharacterCommon = DungeonTyper.Common.Models.ICharacterCommon;
using ICreature = DungeonTyper.Logic.Models.ICreature;

namespace DungeonTyper.Logic.GameStates
{
    public interface ICombatState
    {
        void EndBattleDefeat();
        void EndBattleVictory();
        void HandleDamage(int damage, ICreature defender);
        void StartBattle(ICharacterCommon character, ICreature enemy);
        void Reinstantiate(ICharacterCommon character, ICreature enemy);
        void WriteOutput(string output);
    }
}