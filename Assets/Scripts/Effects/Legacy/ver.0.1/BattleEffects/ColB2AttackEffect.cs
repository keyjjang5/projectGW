using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace GWEffectVer_0_1
{
    [Serializable]
    public class ColB2AttackEffect : BattleEffect
    {
        public int power;

        public ColB2AttackEffect(int power) : base()
        {
            this.power = power;
        }
        public ColB2AttackEffect(string name, int power) : base(name)
        {
            this.power = power;
        }

        override public void Active()
        {
            Hitbox.BroadcastMessage("MultipleHited", new AttackStruct(AttackType.ColB2, power));
        }
    }
}