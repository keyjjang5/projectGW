using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GWEffectVer_0_1
{
    public class DefenseBreak : StatusEffect
    {
        public DefenseBreak(int power) : base(power)
        {
            StatusEffectType = StatusEffectType.Power;
        }

        public DefenseBreak(string name, int power) : base(name, power)
        {
            StatusEffectType = StatusEffectType.Power;
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