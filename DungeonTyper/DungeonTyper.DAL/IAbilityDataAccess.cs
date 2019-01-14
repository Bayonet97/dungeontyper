using System.Collections.Generic;
using DungeonTyper.Common.Models;

namespace DungeonTyper.DAL
{
    public interface IAbilityDataAccess 
    {
        List<string> GetAllAbilities_CharacterClass();
        List<string> GetAllCharacterClass_AbilitiesCount();
        IAbilityCommon GetAbilityByName(string name);
        List<IAbilityCommon> GetAllCharacter_Abilities(int characterId);
        List<IAbilityCommon> GetCharacterClass_Abilities(string characterClass);
    }
}