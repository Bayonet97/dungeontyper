using DungeonTyper.Common.Models;
using System;
using System.Collections.Generic;

namespace DungeonTyper.DAL
{
    public interface ICharacterClassDataAccess
    {
        ICharacterClassCommon GetCharacterClassByName(string characterClass);
        CharacterClassCommon GetCharacterClassById(int characterClassId);
        List<ICharacterClassCommon> GetAllCharacterClasses();
    }
}