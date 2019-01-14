using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DungeonTyper.Common.Models
{
    public class AbilityCommon : IAbilityCommon
    {
        public string AbilityName { get; private set; }
        public string AbilityDescription { get; private set; }

        public AbilityCommon(string abilityName, string abilityDescription)
        {
            AbilityName = abilityName;
            AbilityDescription = abilityDescription;
        }
    }
}
