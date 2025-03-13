using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace GWEffectVer_0_1
{
    [Serializable]
    public class CrossAttackEffect : BattleEffect
    {
        public int power;

        public CrossAttackEffect(int power) : base()
        {
            this.BasePower = power;
        }
        public CrossAttackEffect(string name, int power) : base(name)
        {
            this.BasePower = power;
        }

        public CrossAttackEffect(string name = "default", int power = 0, int maxCooltime = 0) : base(name, power, maxCooltime)
        {
            this.BasePower = power;
        }

        override public void Active()
        {
            Hitbox.BroadcastMessage("MultipleHited", new AttackStruct(AttackType.FullCross, BasePower));
        }

        public override BattleEffect DeepCopy()
        {
            BattleEffect battleEffect = new CrossAttackEffect(BasePower);
            battleEffect.Target = Target;
            battleEffect.Hitbox = Hitbox;
            battleEffect.user = user;
            Debug.Log("power : " + battleEffect.BasePower);
            return battleEffect;
        }
    }
}