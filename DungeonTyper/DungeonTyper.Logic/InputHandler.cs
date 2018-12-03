using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Logic
{
    public class InputHandler : IInputHandler
    {
        private IOutputHandler _outputHandler;
        public InputHandler(IOutputHandler outputhandler)
        {
            _outputHandler = outputhandler;
        }

        public void HandleInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                // Do absolutely nothing.
            }
            else
            {
               
                if (input == "sit")
                {

                    _outputHandler.HandleOutput("You sit down.");

                }
                else
                {
                    _outputHandler.HandleOutput("You do something along the lines of " + input + "ing.");
                }
            }

        }
    }
}
