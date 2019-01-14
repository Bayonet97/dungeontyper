using System.Collections.Generic;

namespace DungeonTyper.Common.Models
{
    public interface ICharacterClassCommon
    {
        List<IAbilityCommon> CharacterClassAbilities { get; set; }
        string ClassName { get; set; }
    }
}