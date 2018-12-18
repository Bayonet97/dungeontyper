﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DungeonTyper.Common.Models
{
    public class Ability : IAbility
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
