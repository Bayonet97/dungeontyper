using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DungeonTyper.DAL;
using DungeonTyper.Common.Utils;
using DungeonTyper.Common.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using DungeonTyper.Common;
using DungeonTyper.Logic.GameStates;
using DungeonTyper.Logic.Models;

namespace DungeonTyper.Logic.Handlers
{
    public class InputHandler : IInputHandler
    {
        private string _input;

        private readonly IOutputHandler _outputHandler;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAbilityDataAccess _abilityDataAccess;
        private readonly ICharacterClassDataAccess _characterClassDataAccess;
        private readonly ICharacterDataAccess _characterDataAccess;
        private readonly ICombatState _combatState;

        // Here i construct the inputhandler and give it the outputhandler so that outputhandler does not rely on the inputhandler, but the inputhandler does need the outputhandler interface. This is because the outputhandler is at a higher level.
        public InputHandler(
            IOutputHandler outputhandler,
            IHttpContextAccessor httpContextAccessor,
            IAbilityDataAccess abilityDataAccess,
            ICharacterClassDataAccess characterClassDataAccess,
            ICharacterDataAccess characterDataAccess,
            ICombatState combatState)
        {
            _httpContextAccessor = httpContextAccessor;
            _outputHandler = outputhandler;
            _abilityDataAccess = abilityDataAccess;
            _characterClassDataAccess = characterClassDataAccess;
            _characterDataAccess = characterDataAccess;
            _combatState = combatState;
        }

        public void HandleInput(string input)
        {
            _input = input;

            if (string.IsNullOrWhiteSpace(_input))
            {
                return;
            }

            _outputHandler.HandleOutput(_input);

            // CHECKS BELOW THIS COMMENT
            GameState currentState = _httpContextAccessor.HttpContext.Session.GetObject<GameSession>("GameSession").CurrentGameState;

            if (currentState == GameState.CharCreation)
            {
                // pirvate void HandleCharacterCreationInput
                if (CheckInputCaseInsensitive(_characterClassDataAccess.GetAllCharacterClasses().Select(c => c.ClassName).ToList()))
                {
                    CreateNewCharacter();
                }
                else
                {
                    _outputHandler.HandleOutput("Please insert a valid class!");
                }
            }
            else if (currentState == GameState.Exploration)
            {
                if (CheckInputCaseInsensitive("All Abilities"))
                {
                    DisplayAllAbilities();
                }
                else if (CheckInputCaseInsensitive("My Abilities"))
                {
                    DisplayAllCharacter_Abilities();
                }
                else if (CheckInputCaseInsensitive("Sit"))
                {
                    // Stuff like this goes into states where you can freely act.
                    _outputHandler.HandleOutput("You sit down.");
                }
                else if (CheckInputCaseInsensitive("Training Dummy"))
                {
                    // Stuff like this goes in other states from where combat can start.
                    SpawnDummy();
                }
            } // combat state stuff
            else if (currentState == GameState.Combat)
            {
                ReInstantiateCombat();
                if (CheckInputCaseInsensitive(_abilityDataAccess.GetAllCharacter_Abilities(_httpContextAccessor.HttpContext.Session.GetObject<GameSession>("GameSession").Character.CharacterId).Select(a => a.AbilityName).ToList()))
                {
                    IAbilityCommon dataAbility = _abilityDataAccess.GetAbilityByName(_input);
                    IAbility ability = new Ability();
                    ICharacter character = _httpContextAccessor.HttpContext.Session.GetObject<GameSession>("GameSession").Character;

                    string attackOutput = character.Attack(ability);
                    _outputHandler.HandleOutput(attackOutput);
                }
                else if (CheckInputCaseInsensitive("Forfeit") || CheckInputCaseInsensitive("Run"))
                {
                    _combatState.EndBattleDefeat();
                    UpdateGameState(GameState.Exploration);
                }

            }
            if(_outputHandler.GetOutput() == "" || _outputHandler.GetOutput() == null)
            {
                _outputHandler.HandleOutput("Nothing happened.");
            }
        }

        private void DisplayAllAbilities()
        {
            List<string> allAbilities = _abilityDataAccess.GetAllAbilities_CharacterClass();
            _outputHandler.HandleOutput(allAbilities);
        }
        private void DisplayAllCharacter_Abilities()
        {
            int id = _httpContextAccessor.HttpContext.Session.GetObject<GameSession>("GameSession").Character.CharacterId;
            List<IAbility> abilities = _abilityDataAccess.GetAllCharacter_Abilities(id).ToList();

            foreach (IAbility ability in abilities)
            {
                _outputHandler.HandleOutput(ability.AbilityName);
            }

        }
        private void CreateNewCharacter()
        {
            List<ICharacterClass> _allCharacterClasses = _characterClassDataAccess.GetAllCharacterClasses();
            // Check for valid input here
            if (InputIsValidCharacterClass(_allCharacterClasses))
            {
                // newCharacter.SetCharacterClass(characterClassDataAccess.GetCharacterClass(_input));
                int characterId = _characterDataAccess.CreateCharacter(_input);
                ICharacter character = _characterDataAccess.GetCharacterById(characterId);
                GameSession gameSession = _httpContextAccessor.HttpContext.Session.GetObject<GameSession>("GameSession");
                gameSession.Character = character as Character;
                _httpContextAccessor.HttpContext.Session.SetObject("GameSession", gameSession);
                _outputHandler.HandleOutput("You chose: " + character.CharacterClass.ClassName);
                UpdateGameState(GameState.Exploration);
            }
            else
            {
                _outputHandler.HandleOutput("That's not a valid class.");
            }
        }

        private void SpawnDummy()
        {
            UpdateGameState(GameState.Combat);
            ICharacter character = _httpContextAccessor.HttpContext.Session.GetObject<GameSession>("GameSession").Character;
            _combatState.StartBattle(character, new TrainingDummy());
        }
        private void ReInstantiateCombat()
        {
            ICharacter character = _httpContextAccessor.HttpContext.Session.GetObject<GameSession>("GameSession").Character;
            _combatState.Reinstantiate(character, new TrainingDummy());
        }
        private bool InputIsValidCharacterClass(List<ICharacterClass> _allCharacterClasses)
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
        private bool CheckInputCaseInsensitive(List<string> expectations)
        {
            foreach (string expectation in expectations)
            {
                if (String.Equals(_input, expectation, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
        private void UpdateGameState(GameState state)
        {
            GameSession gameSession = _httpContextAccessor.HttpContext.Session.GetObject<GameSession>("GameSession");
            gameSession.CurrentGameState = state;
            _httpContextAccessor.HttpContext.Session.SetObject("GameSession", gameSession);
        }

    }
}
