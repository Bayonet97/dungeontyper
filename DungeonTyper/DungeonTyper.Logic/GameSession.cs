using DungeonTyper.Logic.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace DungeonTyper.Logic
{
    public enum GameState
    {
        [EnumMember]
        Stateless = 0,
        [EnumMember]
        CharCreation = 1,
        [EnumMember]
        Exploration = 2,
        [EnumMember]
        Combat = 3,
        [EnumMember]
        Dialogue = 4,
        [EnumMember]
        Inventory = 5,
        [EnumMember]
        Menu = 6,
        [EnumMember]
        Paused = 7
    }

    public class GameSession : IGameSession
    {
        public Character Character { get; set; }
        public GameState CurrentGameState { get; set; }

    }
}
