using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DungeonTyper.Common.Models
{
    public class Ability : IAbility
    {
        public string AbilityName { get; private set; }
        public string AbilityDescription { get; private set; }

        public Ability(string abilityName, string abilityDescription)
        {
            AbilityName = abilityName;
            AbilityDescription = abilityDescription;
        }
    }
}
