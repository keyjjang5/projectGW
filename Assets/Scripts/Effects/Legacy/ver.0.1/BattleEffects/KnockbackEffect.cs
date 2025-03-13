using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace GWEffectVer_0_1
{
    [Serializable]
    public class KnockbackEffect : BattleEffect
    {
        public KnockbackEffect() : base()
        {

        }
        public KnockbackEffect(string name) : base(name)
        {

        }

        override public void Active()
        {
            Hitbox.BroadcastMessage("Knockback", new KnockbackStruct());
        }
    }
}