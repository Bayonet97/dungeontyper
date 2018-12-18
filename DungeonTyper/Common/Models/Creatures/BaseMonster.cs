using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Common.Models
{
    abstract class BaseMonster : ICreature
    {
        public abstract string Name { get; }
        public abstract int HitPoints { get; }
    }
}
