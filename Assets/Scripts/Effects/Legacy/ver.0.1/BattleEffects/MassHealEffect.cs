using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace GWEffectVer_0_1
{
    [Serializable]
    public class MassHealEffect : BattleEffect
    {
        public int power;

        public MassHealEffect(int power) : base()
        {
            this.power = power;
        }
        public MassHealEffect(string name, int power) : base(name)
        {
            this.power = power;
        }

        override public void Active()
        {
            Hitbox.BroadcastMessage("Heal", new HealStruct(HealType.Mass, power));
        }
    }
}