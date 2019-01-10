using DungeonTyper.DAL;
using DungeonTyper.Logic.Handlers;
using DungeonTyper.Common.Models;
using DungeonTyper.Logic.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Logic
{
    public class ProgressLoader : IProgressLoader
    {
        private List<string> _loadedOutput = new List<string>();
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOutputHandler _outputHandler;
        private readonly ICharacterClassDataAccess _characterClassDataAccess;
        private readonly IAbilityDataAccess _abilityDataAccess;
        private readonly IStateHandler _gameStateHandler;

        public ProgressLoader(IHttpContextAccessor httpContextAccessor, IOutputHandler outputhandler, ICharacterClassDataAccess characterClassDataAccess, IAbilityDataAccess abilityDataAccess, IStateHandler gameStateHandler)
        {
            _httpContextAccessor = httpContextAccessor;
            _outputHandler = outputhandler;
            _characterClassDataAccess = characterClassDataAccess;
            _abilityDataAccess = abilityDataAccess;
            _gameStateHandler = gameStateHandler;
        }

        public void Load()
        {   
            if(GameFound())
            {
                LoadCharacter();
                LoadGameState();
                LoadOutput();
            }
            else
            {
                CreateNewCharacter();
            }
        }
        private void UpdateGameState(int state)
        {
            _gameStateHandler.ChangeState((GameState)state);
            _httpContextAccessor.HttpContext.Session.SetInt32("GameState", state);
        }

        private void CreateNewCharacter()
        {
            UpdateGameState(1);
            _outputHandler.HandleOutput("Create a new character! Which class would you like to play? \rType down one of the following classes: ");

            foreach (Common.Models.ICharacterClass characterClass in _characterClassDataAccess.GetAllCharacterClasses())
            {
                _outputHandler.HandleOutput("\r" + characterClass.ClassName);

                foreach (Common.Models.IAbility ability in _abilityDataAccess.GetCharacterClass_Abilities(characterClass.ClassName))
                {
                    _outputHandler.HandleOutput("Starts with: " + ability.AbilityName);
                }

            }
        }
        private bool GameFound()
        {
            // NOT IMPLEMENTED
            return false;
        }

        private void LoadCharacter()
        {
            throw new NotImplementedException();
        }

        private void LoadGameState()
        {
            throw new NotImplementedException();
        }

        private void LoadOutput()
        {
            throw new NotImplementedException();
        }

        public GameState GetLoadedGameState()
        {
            throw new NotImplementedException();
        }
        public Logic.Models.ICharacter GetLoadedCharacter()
        {
            throw new NotImplementedException();
        }

        public List<string> GetLoadedOutput()
        {
            return _loadedOutput;
        }

  
    }
}
