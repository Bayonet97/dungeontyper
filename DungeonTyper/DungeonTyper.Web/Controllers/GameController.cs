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
            
            return View(model);
        }

        [HttpPost]
        public string Handle()
        {          
            if (Request.Form.Count > 0)
            {
                // Factory is the top layer. It gives the controller the dependencies it needs. Here the dependencies are turned into object instances in the controller.
                IOutputHandler outputHandler = HandlerBuilder.CreateOutputHandler();
                // I then proceed to give one instance to the other as a Dependency Inverted reference.
                IInputHandler inputHandler = HandlerBuilder.CreateInputHandler(outputHandler);
                
                string input = Request.Form["inputText"];

                inputHandler.HandleInput(input);

                return outputHandler.GetOutput();
                
            }
            return "";
        }

    }
}
