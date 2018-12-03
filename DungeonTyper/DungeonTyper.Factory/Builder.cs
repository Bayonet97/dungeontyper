using System;
using DungeonTyper.Logic;

namespace DungeonTyper.Factory
{
    public static class Builder
    {
        public static IInputHandler CreateInputHandler(IOutputHandler outputHandler)
        {
            return new InputHandler(outputHandler);
        }

        public static IOutputHandler CreateOutputHandler()
        {
            return new OutputHandler();
        }
    }
}
