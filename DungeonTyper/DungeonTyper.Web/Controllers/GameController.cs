using DungeonTyper.Models;
using Microsoft.AspNetCore.Mvc;
using DungeonTyper.Logic;
using DungeonTyper.Common.Utils;
using System.Collections.Generic;
using DungeonTyper.Logic.Handlers;
using Microsoft.AspNetCore.Http;
using DungeonTyper.DAL;
using DungeonTyper.Common.Models;

namespace DungeonTyper.Web.Controllers
{
    public class GameController : Controller
    {
        // TO DO: SESSION MANAGEMENT
        private readonly IOutputHandler _outputHandler;
        private readonly IInputHandler _inputHandler;
        private readonly IStateHandler _gameStateHandler;
        private readonly ICharacterClassDataAccess _characterClassDataAccess;
        private readonly IAbilityDataAccess _abilityDataAccess;

        public GameController(IInputHandler inputHandler, IOutputHandler outputHandler, IStateHandler gameStateHandler, ICharacterClassDataAccess characterClassDataAccess, IAbilityDataAccess abilityDataAccess)
        {
            _outputHandler = outputHandler;
            _inputHandler = inputHandler;
            _gameStateHandler = gameStateHandler;
            _characterClassDataAccess = characterClassDataAccess;
            _abilityDataAccess = abilityDataAccess;
        }

        public ActionResult Index()
        {
            return View();
        }

        public string LoadData()
        {
            if (false) // Load data here.
            {
                //      IProgressLoader loader = _progressLoaderFactory.Create();
                //      loader.Load();
                //     List<string> output = loader.GetLoadedOutput();
            }
            else // Character creation
            {
                HttpContext.Session.SetInt32("GameState", 1);

                _outputHandler.HandleOutput("Create a new character! Which class would you like to play? \rType down one of the following classes: ");

                foreach (ICharacterClass characterClass in _characterClassDataAccess.GetAllCharacterClasses())
                {
                    _outputHandler.HandleOutput("\r" + characterClass.ClassName);

                    foreach (IAbility ability in _abilityDataAccess.GetCharacterClass_Abilities(characterClass.ClassName))
                    {
                        _outputHandler.HandleOutput("Starts with: " + ability.AbilityName);
                    }
       
                }

                return _outputHandler.GetOutput();
            }
        }

        [HttpPost]
        public string Handle()
        {
            if (Request.Form.Count > 0)
            {
                var gameState = HttpContext.Session.GetInt32("GameState");
                _gameStateHandler.ChangeState((GameState)gameState); 

                string input = Request.Form["inputText"];

                _inputHandler.HandleInput(input);

                return _outputHandler.GetOutput();

            }
            return "";
        }

    }
}
