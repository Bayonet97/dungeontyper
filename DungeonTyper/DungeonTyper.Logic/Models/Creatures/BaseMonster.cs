using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Logic.Models
{
    abstract class BaseMonster : ICreature
    {
        public string Name => throw new NotImplementedException();

        public int HitPoints => throw new NotImplementedException();
    }
}
