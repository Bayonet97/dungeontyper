﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Common
{
    interface IStateHandler
    {
        void ChangeState(GameState state);
        void SetState(); //Likely to be deleted.
        GameState GetState();
    }
}
