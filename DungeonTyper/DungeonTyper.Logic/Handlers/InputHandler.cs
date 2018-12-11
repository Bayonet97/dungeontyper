﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DungeonTyper.DAL;
using DungeonTyper.Logic.Character;
using DungeonTyper.DAL.Utils;

namespace DungeonTyper.Logic
{
    public class InputHandler : IInputHandler
    {
        private bool _inClassSelection;

        private readonly IOutputHandler _outputHandler;
        private readonly IFactory<IDataAccess> _dataAccessBuilder;

        // Here i construct the inputhandler and give it the outputhandler so that outputhandler does not rely on the inputhandler, but the inputhandler does need the outputhandler interface. This is because the outputhandler is at a higher level.
        public InputHandler(IOutputHandler outputhandler, IFactory<IDataAccess> dataAccessBuilder)
        {
            _outputHandler = outputhandler;
            _dataAccessBuilder = dataAccessBuilder;
        }

        public void HandleInput(string input)
        {
            _inClassSelection = true;
            if (!string.IsNullOrWhiteSpace(input))
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
            else
            {
                _outputHandler.HandleOutput("That's not a valid class.");
            }
        }
        private CharacterClass GetWarrior()
        {
            IDataAccess abilityDataAccess = _dataAccessBuilder.Create();
            // Here I want to instantiate the DAL layer and give it the InputHandler as dependency in its constructor.

            return abilityDataAccess.LoadData("Warrior") as CharacterClass;
        }
    }
}
