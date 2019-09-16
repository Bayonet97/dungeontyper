using DungeonTyper.Models;
using Microsoft.AspNetCore.Mvc;
using DungeonTyper.Logic;
using DungeonTyper.Common.Utils;
using System.Collections.Generic;
using DungeonTyper.Logic.Handlers;
using Microsoft.AspNetCore.Http;
using DungeonTyper.DAL;
using DungeonTyper.Common.Models;
using DungeonTyper.Common;

namespace DungeonTyper.Web.Controllers
{
    public class GameController : Controller
    {
        // TO DO: SESSION MANAGEMENT
        private readonly IOutputHandler _outputHandler;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly GameSession _gameSession;
        private readonly IProgressLoader _gameLoader;
        private readonly IInputHandler _inputHandler;


        public GameController(
            GameSession gameSession,
            IProgressLoader gameLoader,
            IInputHandler inputHandler,
            IOutputHandler outputHandler,
            IHttpContextAccessor httpContextAccessor)
        {
            _outputHandler = outputHandler;
            _httpContextAccessor = httpContextAccessor;
            _gameSession = gameSession;
            _gameLoader = gameLoader;
            _inputHandler = inputHandler;
        }

        public ActionResult Index()
        {
            return View();
        }

        public string LoadData()
        {
            HttpContext.Session.SetObject("GameSession", _gameSession);
            _gameLoader.Load();

            return _outputHandler.GetOutput();

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
