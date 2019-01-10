using DungeonTyper.Models;
using Microsoft.AspNetCore.Mvc;

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
        public void HandleInput()
        {
            if(Request.Form.Count > 0)
            {
                string input = Request.Form["inputText"];
                // Enter logic layer
                if (input == "sit")
                {
                    HandleOutput("You sit down.");

                }
                else
                {
                    HandleOutput("You did something!");
                }
            }          
        }

        public ActionResult HandleOutput(string output)
        {
            // Output from logic layer
            model.NewOutput = output;       
            //TO DO: return partial view (Ajax in View) https://stackoverflow.com/questions/26023489/how-do-i-use-a-controller-action-to-refresh-the-model-without-navigation          
            return PartialView("_TextArea", model);
        }

    }
}
