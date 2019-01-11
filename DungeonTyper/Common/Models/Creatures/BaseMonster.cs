using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Common.Models
{
    abstract class BaseMonster : ICreature
    {
        public abstract string Name { get; }
        public abstract int HitPoints { get; }

        public abstract string CharacterLosesBattle();
        public abstract string CharacterWinsBattle();
        public abstract string StartBattle();
        public abstract void TakeDamage(int damage);
    }
}
