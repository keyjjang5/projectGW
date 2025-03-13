using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace GWEffectVer_0_1
{
    [Serializable]
    public class RandomAttackEffect : BattleEffect
    {
        public int power;

        public RandomAttackEffect(int power) : base()
        {
            this.power = power;
        }
        public RandomAttackEffect(string name, int power) : base(name)
        {
            this.power = power;
        }

        override public void Active()
        {
            Hitbox.BroadcastMessage("MultipleHited", new AttackStruct(AttackType.Random, power));
        }
    }
}