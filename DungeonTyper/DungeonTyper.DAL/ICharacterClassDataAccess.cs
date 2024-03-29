﻿using DungeonTyper.Common.Models;
using System;
using System.Collections.Generic;

namespace DungeonTyper.DAL
{
    public interface ICharacterClassDataAccess
    {
        ICharacterClass GetCharacterClassByName(string characterClass);
        CharacterClass GetCharacterClassById(int characterClassId);
        List<ICharacterClass> GetAllCharacterClasses();
    }
}