using System;
using DungeonTyper.Interfaces;

namespace DungeonTyper.Logic
{
    public class InputHandler : IReceiver
    {
        public void HandleInput(string input)
        {
            string output;

            if(input == "attack")
            {
                output = "You atack!";   
            }
            else
            {
               output  = "You didn't attack.";
            }
           // Need a way to access GameHub without circular dependency? Lower layer cant talk with higher layer???
        }
    }
}
