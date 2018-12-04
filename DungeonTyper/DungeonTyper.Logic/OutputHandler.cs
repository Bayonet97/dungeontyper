using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Logic
{
    public class OutputHandler : IOutputHandler
    {
        private string _output;

        public string GetOutput()
        {
            return _output;
        }

        public void HandleOutput(string outputToHandle)
        {
            _output = outputToHandle;
        }
    }
}
