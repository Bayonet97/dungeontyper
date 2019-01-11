using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Logic.Models
{
    class TrainingDummy : BaseMonster
    {
        public new string Name = "Training Dummy";
        public new int HitPoints = 99999;

        public override string StartBattle()
        {
            return "The dummy has accepted your challenge. Let the duel begin.";
        }

        public override string CharacterWinsBattle()
        {
            return "The dummy has been smashed to pieces, it couldn't even defend itself.";
        }
        public override string CharacterLosesBattle()
        {
            return "You fled from your duel against a training dummy. The dummy is victorious.";
        }
    }
}
