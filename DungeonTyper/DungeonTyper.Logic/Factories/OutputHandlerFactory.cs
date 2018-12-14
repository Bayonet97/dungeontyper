using DungeonTyper.DAL.Utils;
using DungeonTyper.Logic;
using DungeonTyper.Logic.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Logic.Factories
{

    public class OutputHandlerFactory : IFactory<IOutputHandler>
    {
        public IOutputHandler Create()
        {
            return new OutputHandler();
        }
    }
}
