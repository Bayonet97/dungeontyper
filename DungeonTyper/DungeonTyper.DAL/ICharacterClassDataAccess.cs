using DungeonTyper.Common.Models;
using System;
using System.Collections.Generic;

namespace DungeonTyper.DAL
{
    public interface ICharacterClassDataAccess
    {
        ICharacterClass GetCharacterClass(string characterClass);
        List<ICharacterClass> GetAllCharacterClasses();
    }
}