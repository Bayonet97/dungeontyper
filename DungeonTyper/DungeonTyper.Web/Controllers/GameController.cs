using DungeonTyper.Models;
using Microsoft.AspNetCore.Mvc;
using DungeonTyper.Factory;
using DungeonTyper.Logic;

namespace DungeonTyper.Web.Controllers
{
    public class GameController : Controller
    {
        GameModel model = new GameModel();

        public ActionResult Index()
        {
            model.Output.Add("Old output loaded.");
            return View(model);
        }

        [HttpPost]
        public string Handle()
        {          
            if (Request.Form.Count > 0)
            {
                IOutputHandler outputHandler = Builder.CreateOutputHandler();
                IInputHandler inputHandler = Builder.CreateInputHandler(outputHandler);
                
                string input = Request.Form["inputText"];

                inputHandler.HandleInput(input);

                return outputHandler.GetOutput();
                
            }
            return "";
        }

    }
}
