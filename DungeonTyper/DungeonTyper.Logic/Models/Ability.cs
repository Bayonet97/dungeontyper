using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DungeonTyper.Logic.Models
{
    public class Ability : IAbility
    {
        public string AbilityName { get; set; }
        public string Description { get; set; }
    }
}
