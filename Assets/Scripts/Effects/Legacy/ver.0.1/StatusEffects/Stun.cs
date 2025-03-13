using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GWEffectVer_0_1
{
    public class Stun : StatusEffect
    {
        public Stun(int power) : base(power)
        {
            StatusEffectType = StatusEffectType.Stun;
        }

        public Stun(string name, int power) : base(name, power)
        {
            StatusEffectType = StatusEffectType.Stun;
        }

        override public void Active()
        {
            Hitbox.BroadcastMessage("AddStatusEffect", this);
        }

        override public float Active(float value)
        {
            float returnValue = 0;

            returnValue = value * BasePower;

            return returnValue;
        }
    }
}