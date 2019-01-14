using DungeonTyper.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Logic.Builders
{
    class SkeletonBuilder : ISkeletonBuilder
    {
        private ICreatureCommon _creature;

        public ICreatureCommon GetCreature()
        {
            return _creature;
        }
    }
}
