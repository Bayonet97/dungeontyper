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
        // TO DO: SESSION 
        private readonly IFactory<IOutputHandler> _outputHandlerFactory;
        private readonly IFactory<IInputHandler, IOutputHandler> _inputHandlerFactory;
        private readonly IFactory<IProgressLoader> _progressLoaderFactory;
        private readonly IFactory<IStateHandler> _gameStateHandlerFactory;
        public GameController(IFactory<IOutputHandler> outputHandlerFactory, IFactory<IInputHandler, IOutputHandler> inputHandlerFactory, IFactory<IProgressLoader> progressLoaderFactory, IFactory<IStateHandler> gameStateHandlerFactory)
        {
            _outputHandlerFactory = outputHandlerFactory;
            _inputHandlerFactory = inputHandlerFactory;
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
                // Factory is the top layer. It gives the controller the dependencies it needs. Here the dependencies are turned into object instances in the controller.
                IOutputHandler outputHandler = _outputHandlerFactory.Create();
                // I then proceed to give one instance to the other as a Dependency Inverted reference.
                IInputHandler inputHandler = _inputHandlerFactory.Create(outputHandler);
                
                string input = Request.Form["inputText"];

                inputHandler.HandleInput(input);

                return outputHandler.GetOutput();
                
            }
            return "";
        }

    }
}
