using DungeonTyper.DAL;
using DungeonTyper.Logic.Handlers;
using DungeonTyper.Common.Models;
using DungeonTyper.Logic.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using DungeonTyper.Common;

namespace DungeonTyper.Logic
{
    public class ProgressLoader : IProgressLoader
    {
        private List<string> _loadedOutput = new List<string>();
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOutputHandler _outputHandler;
        private readonly ICharacterClassDataAccess _characterClassDataAccess;
        private readonly IAbilityDataAccess _abilityDataAccess;

        public ProgressLoader(IHttpContextAccessor httpContextAccessor, IOutputHandler outputhandler, ICharacterClassDataAccess characterClassDataAccess, IAbilityDataAccess abilityDataAccess)
        {
            _httpContextAccessor = httpContextAccessor;
            _outputHandler = outputhandler;
            _characterClassDataAccess = characterClassDataAccess;
            _abilityDataAccess = abilityDataAccess;
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
        private void UpdateGameState(GameState state)
        {
            GameSession gameSession = _httpContextAccessor.HttpContext.Session.GetObject<GameSession>("GameSession");
            gameSession.CurrentGameState = state;
            _httpContextAccessor.HttpContext.Session.SetObject("GameSession", gameSession);
        }

        private void CreateNewCharacter()
        {
            UpdateGameState(GameState.CharCreation);
            _outputHandler.HandleOutput("Create a new character! Which class would you like to play? \rType down one of the following classes: ");

            foreach (Common.Models.ICharacterClassCommon characterClass in _characterClassDataAccess.GetAllCharacterClasses())
            {
                _outputHandler.HandleOutput("\r" + characterClass.ClassName);

                foreach (Common.Models.IAbilityCommon ability in _abilityDataAccess.GetCharacterClass_Abilities(characterClass.ClassName))
                {
                    _outputHandler.HandleOutput("Starts with: " + ability.AbilityName + ", " + ability.AbilityDescription);
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
