using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using DungeonTyper.Logic;
using DungeonTyper.Interfaces;

namespace SignalRChat.Web.Hubs
{
    public class GameHub : Hub
    {
        public async Task ProcessInput(string message)
        {
            InputHandler inputHandler = new InputHandler();
            string output = inputHandler.Handle(message);

            await Clients.Caller.SendAsync("WriteOutput", output);
        }
    }
}