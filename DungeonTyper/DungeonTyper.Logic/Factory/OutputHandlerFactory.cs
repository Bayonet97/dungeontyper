using DungeonTyper.DAL.Utils;
using DungeonTyper.Logic;
using DungeonTyper.Logic.Creatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.HandlerFactory
{

    public class OutputHandlerFactory : IFactory<IOutputHandler>
    {
        public IOutputHandler Create()
        {
            return new OutputHandler();
        }
    }
}
