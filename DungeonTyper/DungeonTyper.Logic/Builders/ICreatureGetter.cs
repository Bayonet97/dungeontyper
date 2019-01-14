using System;
using System.Collections.Generic;
using System.Text;
using DungeonTyper.Common.Models;

namespace DungeonTyper.Logic.Builders
{
    interface ICreatureGetter
    {
        ICreatureCommon GetCreature();
    }
}
