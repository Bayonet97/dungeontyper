using DungeonTyper.Models;
using Microsoft.AspNetCore.Mvc;
using DungeonTyper.Logic;
using DungeonTyper.Common.Utils;
using System.Collections.Generic;
using DungeonTyper.Logic.Handlers;

namespace DungeonTyper.Web.Controllers
{
    public class GameController : Controller
    {
        // TO DO: SESSION MANAGEMENT
        private readonly IOutputHandler _outputHandler;
        private readonly IInputHandler _inputHandler;
        private readonly IFactory<IProgressLoader> _progressLoaderFactory;
        private readonly IFactory<IStateHandler> _gameStateHandlerFactory;
        public GameController(IInputHandler inputHandler, IOutputHandler outputHandler, IFactory<IProgressLoader> progressLoaderFactory, IFactory<IStateHandler> gameStateHandlerFactory)
        {
            _outputHandler= outputHandler;
            _inputHandler = inputHandler;
            _progressLoaderFactory = progressLoaderFactory;
            _gameStateHandlerFactory = gameStateHandlerFactory;
        }

        public ActionResult Index()
        {
            return View();
        }

        public string LoadGame()
        {
            IProgressLoader loader = _progressLoaderFactory.Create();
            loader.Load();

            List<string> output = loader.GetLoadedOutput();

            return "";
        }

        [HttpPost]
        public string Handle()
        {          
            if (Request.Form.Count > 0)
            {
                string input = Request.Form["inputText"];

                _inputHandler.HandleInput(input);

                return _outputHandler.GetOutput();
                
            }
            return "";
        }

    }
}
