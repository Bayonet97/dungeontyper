using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using DungeonTyper.Logic;
using DungeonTyper.Interfaces;

namespace SignalRChat.Web.Hubs
{
    public class GameHub : Hub
    {
        //MAIN @TODO: https://www.youtube.com/watch?v=QtDTfn8YxXg. 
        public async Task ProcessInput(string input)
        {
            IReceiver receiver = new InputHandler();
            receiver.HandleInput(input);

            await Clients.Caller.SendAsync("WriteOutput", receiver);
        }

        public async Task ProcessOutput(string output)
        {
            //TO DO: RECEIVE OUTPUT FROM LOGIC LAYER.
        }
    }
}