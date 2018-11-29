using System;
using DungeonTyper.Interfaces;
using DungeonTyper.Logic;
using SignalRChat.Web.Hubs;

namespace DungeonTyper.Factory
{
    public static class ClassBuilder
    {
       public static IHandler CreateInputHandler()
        {
            return new InputHandler();
        }
    }
}
