﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Logic.Models
{
    public interface ICreature
    {
        string Name { get; }
        int HitPoints { get; }
        void TakeDamage(int damage);
        string StartBattle();
        string CharacterWinsBattle();
        string CharacterLosesBattle();
    }
}
