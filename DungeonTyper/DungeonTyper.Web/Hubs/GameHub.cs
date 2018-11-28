using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
namespace SignalRChat.Web.Hubs
{
    public class GameHub : Hub
    {
        //MAIN @TODO: https://www.youtube.com/watch?v=QtDTfn8YxXg. 
        public async Task ProcessInput(string input)
        {
            string output;

            if (input == "attack")
            {
                output = "You atack!";
            }
            else
            {
                output = "You didn't attack.";
            }

            await Clients.Caller.SendAsync("WriteOutput", output);
        }

        //public async Task ProcessOutput(string output)
        //{
        //    //TO DO: RECEIVE OUTPUT FROM LOGIC LAYER.
        //}
    }
}