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
        private List<ICharacterClass> _allCharacterClasses = new List<ICharacterClass>();
        private string _input;

        private readonly IOutputHandler _outputHandler;
        private readonly IAbilityDataAccess _abilityDataAccess;
        private readonly ICharacterClassDataAccess _characterClassDataAccess;

        // Here i construct the inputhandler and give it the outputhandler so that outputhandler does not rely on the inputhandler, but the inputhandler does need the outputhandler interface. This is because the outputhandler is at a higher level.
        public InputHandler(
            IOutputHandler outputhandler, 
            IAbilityDataAccess abilityDataAccess, 
            ICharacterClassDataAccess characterClassDataAccess)
        {
            _outputHandler = outputhandler;
            _abilityDataAccess = abilityDataAccess;
            _characterClassDataAccess = characterClassDataAccess;
        }

        public void HandleInput(string input)
        {
            _input = input;
            if (string.IsNullOrWhiteSpace(_input))
            {
                return;
            }

            if (CheckInputCaseInsensitive("Sit"))
            {
                _outputHandler.HandleOutput("You sit down.");
            }
            else if (CheckInputCaseInsensitive("All Abilities"))
            {
                DisplayAllAbilities();
            }


        }
        private void DisplayAllAbilities()
        {
            List<string> allAbilities = _abilityDataAccess.GetAllAbilities_CharacterClass();

            _outputHandler.HandleOutput(allAbilities);
        }
        public void ChooseCharacterClass()
        {
            _allCharacterClasses = _characterClassDataAccess.GetAllCharacterClasses();
            // Check for valid input here
            if (InputIsValidCharacterClass())
            {
               // newCharacter.SetCharacterClass(characterClassDataAccess.GetCharacterClass(_input));

                _outputHandler.HandleOutput("You chose: " + newCharacter.CharacterClass.ClassName);
            }
            else
            {
                _outputHandler.HandleOutput("That's not a valid class.");
            }
        }

        private bool InputIsValidCharacterClass()
        {
            foreach (var c in _allCharacterClasses)
            {
                if (_input == c.ClassName) return true;
            }
            return false;
        }

        private bool CheckInputCaseInsensitive(string expectation)
        {
            return String.Equals(_input, expectation, StringComparison.OrdinalIgnoreCase);
        }
    }
}
