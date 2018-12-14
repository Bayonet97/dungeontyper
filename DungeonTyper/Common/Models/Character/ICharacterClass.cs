using System.Collections.Generic;

namespace DungeonTyper.Common.Models
{
    public interface ICharacterClass
    {
        List<Ability> ClassAbilities { get; set; }
        string ClassName { get; set; }
    }
}