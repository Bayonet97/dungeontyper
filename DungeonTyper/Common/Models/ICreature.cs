﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Common.Models
{
    public interface ICreature
    {
        string Name { get; }
        int HitPoints { get; }
    }
}
