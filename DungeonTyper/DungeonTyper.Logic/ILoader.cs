using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Logic
{
    public interface ILoader
    {
        void LoadGame();

        List<string> GetLoadedOutput();
    }
}
