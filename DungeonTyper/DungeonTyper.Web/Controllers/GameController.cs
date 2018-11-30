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
        public string HandleInput()
        {
            string output = "";

            if (Request.Form.Count > 0)
            {
                
                if(Request.Form["inputText"] == "")
                {
                    return null;
                }
                string input = Request.Form["inputText"];
                // Enter logic layer
                if (input == "sit")
                {
               
                    output = "You sit down.";

                }
                else
                {
                    output = "You do something along the lines of " + input + "ing.";
                }
                
            }
            return output;
        }

    }
}
