using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Common
{
    public enum GameState
    {
        Stateless = 0,
        CharCreation = 1,
        Exploration = 2,
        Combat = 3,
        Dialogue = 4,
        Inventory = 5,
        Menu = 6,
        Paused = 7
    }

    public class GameStateHandler : IStateHandler
    {
        private GameState _currentGameState = 0;

        public void ChangeState(GameState state)
        {
            _currentGameState = state;
        }

        public GameState GetState()
        {
            return _currentGameState;
        }

        public void SetState()
        {
            // Not used. Likely delete.
        }
    }
}
