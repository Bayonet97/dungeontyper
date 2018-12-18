using DungeonTyper.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Logic
{
    public class ProgressLoader : IProgressLoader
    {
        private List<string> _loadedOutput = new List<string>();

        public void Load()
        {   
            if(GameFound())
            {
                LoadCharacter();
                LoadGameState();
                LoadOutput();
            }
        }

        private bool GameFound()
        {
            // NOT IMPLEMENTED
            return false;
        }

        private void LoadCharacter()
        {
            throw new NotImplementedException();
        }

        private void LoadGameState()
        {
            throw new NotImplementedException();
        }

        private void LoadOutput()
        {
            throw new NotImplementedException();
        }

        public GameState GetLoadedGameState()
        {
            throw new NotImplementedException();
        }
        public ICharacter GetLoadedCharacter()
        {
            throw new NotImplementedException();
        }

        public List<string> GetLoadedOutput()
        {
            return _loadedOutput;
        }

  
    }
}
