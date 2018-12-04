using System;
using System.Collections.Generic;
using System.Text;
using DungeonTyper.DAL;

namespace DungeonTyper.DataAccessFactory
{
    public static class DataAccessBuilder
    {
        public static IAbilityDataAccess CreateAbilityDataAccess()
        {
            return new AbilityDataAccess();
        }
    }
}
