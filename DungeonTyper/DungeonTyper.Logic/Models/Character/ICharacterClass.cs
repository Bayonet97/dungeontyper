using System.Collections.Generic;

namespace DungeonTyper.Logic.Models
{
    public interface ICharacterClass
    {
        List<Ability> ClassAbilities { get; set; }
        string ClassName { get; set; }
    }
}