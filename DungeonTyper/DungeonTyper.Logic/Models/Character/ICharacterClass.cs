using System.Collections.Generic;

namespace DungeonTyper.Logic.Models
{
    public interface ICharacterClass
    {
        List<IAbility> ClassAbilities { get; set; }
        string ClassName { get; set; }
    }
}