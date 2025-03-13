using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace GWEffectVer_0_1
{
    [Serializable]
    public class AttackEffect : BattleEffect
    {
        public AttackEffect(int power) : base()
        {
            this.BasePower = power;
        }
        public AttackEffect(string name, int power) : base(name)
        {
            this.BasePower = power;
        }

        public AttackEffect(string name = "default", int power = 0, int maxCooltime = 0) : base(name, power, maxCooltime)
        {
            this.BasePower = power;
        }

        override public void Active()
        {
            base.Active();
            Debug.Log("target : " + Target.GetCharacter().Pos);
            Hitbox.BroadcastMessage("MultipleHited", new AttackStruct(AttackType.Single, BasePower, Target.GetCharacter().Pos));
        }

        public override BattleEffect DeepCopy()
        {
            BattleEffect battleEffect = new AttackEffect(BattleEffectName, BasePower, MaxCooltime);
            battleEffect.Target = Target;
            battleEffect.Hitbox = Hitbox;

            return battleEffect;
        }
    }
}