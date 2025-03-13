using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace GWEffectVer_0_1
{
    [Serializable]
    public class TargetShieldEffect : BattleEffect
    {
        public int power;

        public TargetShieldEffect(int power) : base()
        {
            this.power = power;
        }
        public TargetShieldEffect(string name, int power) : base(name)
        {
            this.power = power;
        }

        override public void Active()
        {
            Hitbox.BroadcastMessage("AddShield", power);
        }
    }
}