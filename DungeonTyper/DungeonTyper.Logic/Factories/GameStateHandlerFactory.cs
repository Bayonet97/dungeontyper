using DungeonTyper.Common.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Logic.Factories
{
    public class GameStateHandlerFactory : IFactory<IStateHandler>
    {
        public IStateHandler Create()
        {
            return new GameStateHandler();
        }
    }
}
