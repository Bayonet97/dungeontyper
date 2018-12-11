using System;
using DungeonTyper.DAL;
using DungeonTyper.DAL.Utils;
using DungeonTyper.Logic;
using DungeonTyper.Logic.Creatures;

namespace DungeonTyper.Factory
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
