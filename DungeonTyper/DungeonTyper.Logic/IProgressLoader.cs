﻿using System.Collections.Generic;
using DungeonTyper.Common;
using DungeonTyper.Logic.Models;

namespace DungeonTyper.Logic
{
    public interface IProgressLoader : ILoader
    {
        ICharacter GetLoadedCharacter();
        GameState GetLoadedGameState();
        List<string> GetLoadedOutput();
    }
}