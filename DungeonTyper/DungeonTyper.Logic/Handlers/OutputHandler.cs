using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Logic.Handlers
{
    public class OutputHandler : IOutputHandler
    {
        private string _output;

        public string GetOutput()
        {
            if(false) // Something to check if no output was given.
            {
                return "Nothing happened.";
            }
            return _output;
        }

        public void HandleOutput(string outputToHandle)
        {
            _output += string.Join(Environment.NewLine, outputToHandle);
            _output += Environment.NewLine;
        }

        public void HandleOutput(List<string> outputToHandle)
        {
            _output += string.Join(Environment.NewLine, outputToHandle);
            _output += Environment.NewLine;
        }

    }
}
