using System.Collections.Generic;

namespace DungeonTyper.Common.Models
{
    public interface ICharacterClass
    {
        List<IAbility> CharacterClassAbilities { get; set; }
        string ClassName { get; set; }
    }
}