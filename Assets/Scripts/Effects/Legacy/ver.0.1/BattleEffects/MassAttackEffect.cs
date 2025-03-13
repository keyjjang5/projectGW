using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace GWEffectVer_0_1
{
    [Serializable]
    public class MassAttackEffect : BattleEffect
    {
        public int power;

        public MassAttackEffect(int power) : base()
        {
            this.power = power;
        }
        public MassAttackEffect(string name, int power) : base(name)
        {
            this.power = power;
        }
        public MassAttackEffect(string name = "default", int power = 0, int maxCooltime = 0) : base(name, power, maxCooltime)
        {
            this.power = power;
        }
        override public void Active()
        {
            base.Active();
            Hitbox.BroadcastMessage("MultipleHited", new AttackStruct(AttackType.All, power));
        }
    }
}