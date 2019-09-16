using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Logic.Models
{
    abstract class BaseMonster : ICreature
    {
        public string Name { get; private set; } = "Monster";

        public int HitPoints { get; private set; } = 10;

        public abstract string CharacterLosesBattle();
        public abstract string CharacterWinsBattle();
        public abstract string StartBattle();
        public void TakeDamage(int damage)
        {
            HitPoints -= damage;
        }
    }
}
