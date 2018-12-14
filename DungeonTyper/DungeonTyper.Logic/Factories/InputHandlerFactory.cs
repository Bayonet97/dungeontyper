using System;
using DungeonTyper.DAL;
using DungeonTyper.Common.Utils;
using DungeonTyper.Logic;
using DungeonTyper.Logic.Handlers;

namespace DungeonTyper.Logic.Factories
{
    public class InputHandlerFactory : IFactory<IInputHandler, IOutputHandler>
    {
        private readonly IFactory<IDataAccess> _builder;

        public InputHandlerFactory(IFactory<IDataAccess> builder)
        {
            _builder = builder;
        }

        public IInputHandler Create(IOutputHandler outputHandler)
        {
            return new InputHandler(outputHandler, _builder);
        }
    }
}
