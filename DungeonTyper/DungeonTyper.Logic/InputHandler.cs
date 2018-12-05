using System;
using System.Collections.Generic;
using System.Text;
using DungeonTyper.Logic.Models;
using System.Data.SqlClient;
using static DungeonTyper.DataAccessFactory.DataAccessBuilder;
using DungeonTyper.DAL;

namespace DungeonTyper.Logic
{
    public class InputHandler : IInputHandler
    {
        private bool _inClassSelection;

        private IOutputHandler _outputHandler;

        // Here i construct the inputhandler and give it the outputhandler so that outputhandler does not rely on the inputhandler, but the inputhandler does need the outputhandler interface. This is because the outputhandler is at a higher level.
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
                    ChooseCharacterClass(input);
                }
                else
                {
                    _outputHandler.HandleOutput("You do something along the lines of " + input + "ing.");
                }
            }

        }

        public void ChooseCharacterClass(string input)
        {
            if (input == "warrior" || input == "Warrior")
            {
                GetWarrior();
            }
        }
        private CharacterClassModel GetWarrior()
        {
            IDataAccess abilityDataAccess = /*CreateAbilityDataAccess()*/;
            // Here I want to instantiate the DAL layer and give it the InputHandler as dependency in its constructor.
            string sql = @"select Name
                         from dbo.CharacterClass
                         where Name = Warrior;";
            return abilityDataAccess.LoadData(sql) as CharacterClassModel;
        }
    }
}
