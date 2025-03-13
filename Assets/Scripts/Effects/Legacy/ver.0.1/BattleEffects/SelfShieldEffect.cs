using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace GWEffectVer_0_1
{
    [Serializable]
    public class SelfShieldEffect : BattleEffect
    {
        public int power;

        public SelfShieldEffect(int power) : base()
        {
            this.power = power;
        }
        public SelfShieldEffect(string name, int power) : base(name)
        {
            this.power = power;
        }

        override public void Active()
        {
            user.GetCharacter().AddShield(power);
        }
    }
}