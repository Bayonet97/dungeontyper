using DungeonTyper.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Logic.Builders
{
    class SkeletonBuilder : ISkeletonBuilder
    {
        private ICreature _creature;

        public ICreature GetCreature()
        {
            return _creature;
        }
    }
}
