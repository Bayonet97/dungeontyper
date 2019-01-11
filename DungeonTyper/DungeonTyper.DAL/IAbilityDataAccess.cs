using System.Collections.Generic;
using DungeonTyper.Common.Models;

namespace DungeonTyper.DAL
{
    public interface IAbilityDataAccess 
    {
        List<string> GetAllAbilities_CharacterClass();
        List<string> GetAllCharacterClass_AbilitiesCount();
        IAbility GetAbilityByName(string name);
        List<IAbility> GetAllCharacter_Abilities(int characterId);
        List<IAbility> GetCharacterClass_Abilities(string characterClass);
    }
}