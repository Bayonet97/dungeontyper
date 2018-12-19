using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DungeonTyper.DAL;
using DungeonTyper.Common.Utils;
using DungeonTyper.Common.Models;

namespace DungeonTyper.Logic.Handlers
{
    public class InputHandler : IInputHandler
    {
        Character newCharacter = new Character();
        private List<ICharacterClass> _allCharacterClasses= new List<ICharacterClass>();


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
            if (!string.IsNullOrWhiteSpace(input))
            {
                if (input == "sit")
                {

                    _outputHandler.HandleOutput("You sit down.");

                }
                else
                {
                    ChooseCharacterClass(input);
                //   _outputHandler.HandleOutput("You do something along the lines of " + input + "ing.");
                }
            }

        }

        public void ChooseCharacterClass(string input)
        {
            ICharacterClassDataAccess characterClassDataAccess = _dataAccessBuilder.Create() as ICharacterClassDataAccess;

            _allCharacterClasses = characterClassDataAccess.GetAllCharacterClasses();
            // Check for valid input here
            if (InputIsValidCharacterClass(input))
            {

                newCharacter.SetCharacterClass(characterClassDataAccess.GetCharacterClass(input));

                _outputHandler.HandleOutput("You chose: " + newCharacter.CharacterClass.ClassName);
            }
            else
            {
                _outputHandler.HandleOutput("That's not a valid class.");
            }
        }

        private bool InputIsValidCharacterClass(string input)
        {
            foreach (var c in _allCharacterClasses)
            {
                if (input == c.ClassName) return true;
            }
            return false;
        }
    }
}
