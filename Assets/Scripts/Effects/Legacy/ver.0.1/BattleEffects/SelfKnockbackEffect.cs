using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace GWEffectVer_0_1
{
    [Serializable]
    public class SelfKnockbackEffect : BattleEffect
    {
        public SelfKnockbackEffect(int power) : base()
        {

        }
        public SelfKnockbackEffect(string name, int power) : base(name)
        {

        }

        public SelfKnockbackEffect(string name = "default", int power = 0, int maxCooltime = 0) : base(name, power, maxCooltime)
        {

        }

        override public void Active()
        {
            Hitbox.BroadcastMessage("Knockback", new KnockbackStruct(user.GetCharacter().Pos, BasePower));
        }
    }
}