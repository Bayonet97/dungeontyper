using DungeonTyper.Logic.Handlers;
using DungeonTyper.Logic.Models;
using DungeonTyper.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ICharacter = DungeonTyper.Common.Models.ICharacter;
using ICreature = DungeonTyper.Logic.Models.ICreature;

namespace DungeonTyper.Logic.GameStates
{
    public class CombatState : ICombatState
    {
        private readonly IOutputHandler _outputHandler;
        private ICharacter _character;
        private ICreature _creature;

        public CombatState(IOutputHandler outputHandler)
        {
            _outputHandler = outputHandler;
        }
        // TO BE DELETED WHEN STORED IN SESSION.
        public void Reinstantiate(ICharacter character, ICreature enemy)
        {
            _character = character;
            _creature = enemy;
        }
        public void StartBattle(ICharacter character, ICreature enemy)
        {
            _character = character;
            _creature = enemy;
            WriteOutput(_character.StartBattle());
            WriteOutput(_creature.StartBattle());
        }

        public void EndBattleVictory()
        {
            WriteOutput(_creature.CharacterWinsBattle());
            WriteOutput(_character.CharacterWinsBattle());
        }
        public void EndBattleDefeat()
        {
            WriteOutput(_creature.CharacterLosesBattle());
            WriteOutput(_character.CharacterLosesBattle());
        }

        public void HandleDamage(int damage, ICreature defender)
        {
            
        }

        public void WriteOutput(string output)
        {
            _outputHandler.HandleOutput(output);
        }
    }
}
