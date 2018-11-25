using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DungeonTyper.Models
{
    public class GameModel
    {
        public string Input { get; set; }

        public List<string> Output { get; set; } = new List<string>();

        public string NewOutput { get; set; }

    }
}