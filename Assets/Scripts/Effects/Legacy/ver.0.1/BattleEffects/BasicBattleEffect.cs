using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace GWEffectVer_0_1
{
    [Serializable]
    public class BasicBattleEffect : BattleEffect
    {
        public BasicBattleEffect() : base()
        {

        }
        public BasicBattleEffect(string name) : base(name)
        {

        }

        override public void Active()
        {
            Hitbox.BroadcastMessage("Hited", 10.0f);
        }
    }
}