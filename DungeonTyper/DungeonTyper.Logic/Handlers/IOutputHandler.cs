using System.Collections.Generic;

namespace DungeonTyper.Logic.Handlers
{
    public interface IOutputHandler
    {
        void HandleOutput(string outputToHandle);
        void HandleOutput(List<string> outputToHandle);
        string GetOutput();
    }
}