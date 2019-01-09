using System.Collections.Generic;
using DungeonTyper.Common.Models;

namespace DungeonTyper.DAL
{
    public interface IAbilityDataAccess : IDataAccess
    {
        List<string> GetAllAbilities_CharacterClass();
        List<string> GetAllCharacterClass_AbilitiesCount();
        List<IAbility> GetAllCharacter_Abilities(int characterId);
        List<IAbility> GetCharacterClass_Abilities(ICharacterClass characterClass);
    }
}