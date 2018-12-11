using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Logic
{
    public class LoadProgress : ILoader
    {
        private List<string> _loadedOutput = new List<string>();

        public void LoadGame()
        {
            _loadedOutput.Add("Welcome");
            _loadedOutput.Add("Choose your class");
        }

        public List<string> GetLoadedOutput()
        {
            return _loadedOutput;
        }

  
    }
}
