using System;
using System.Collections.Generic;
using System.Text;
using DungeonTyper.Logic.Models;
using System.Data.SqlClient;

namespace DungeonTyper.Logic
{
    public class InputHandler : IInputHandler
    {
        private bool _inClassSelection;

        private IOutputHandler _outputHandler;
        public InputHandler(IOutputHandler outputhandler)
        {
            _outputHandler = outputhandler;
        }

        public void HandleInput(string input)
        {
            _inClassSelection = true;
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
                if (_inClassSelection)
                {
                    ChooseClass(input);
                }
                else
                {
                    _outputHandler.HandleOutput("You do something along the lines of " + input + "ing.");
                }
            }

        }

        public void ChooseClass(string input)
        {

            if (input == "warrior" || input == "Warrior")
            {
                GetWarrior();
            }
        }
        private CharacterClassModel GetWarrior()
        {
            string sql = @"select Name
                         from dbo.CharacterClass
                         where Name = @Name;";
            return Sqldata.Load
        }
    }
}
