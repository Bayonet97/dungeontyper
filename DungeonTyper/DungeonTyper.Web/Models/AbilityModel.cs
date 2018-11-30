using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DungeonTyper.Models
{
    class AbilityModel
    {
        public int AbilityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
