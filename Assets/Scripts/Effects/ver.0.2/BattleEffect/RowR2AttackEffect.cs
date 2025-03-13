using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace GWEffectVer_0_2
{
    // 양산형 전투효과
    [Serializable]
    public class RowR2AttackEffect : BattleEffect, IValueChanger
    {
        public RowR2AttackEffect(string name = "default", int power = 0, int maxCooltime = 0) : base(name, power, maxCooltime)
        {

        }

        public override void Active()
        {
            base.Active();
            Debug.Log("hitbox is " + Hitbox.name);
            int pos = -1;
            if (Target != null)
                pos = Target.Pos;

            Hitbox.BroadcastMessage("MultipleHited",
            new AttackStruct(AttackType.RowR2, NowPower, pos));
        }

        public override BattleEffect DeepCopy()
        {
            BattleEffect battleEffect = new RowR2AttackEffect(BattleEffectName, BasePower, MaxCooltime);
            battleEffect.SetTarget(Target);
            battleEffect.SetHitbox(Hitbox);
            battleEffect.SetUser(user);
            battleEffect.NowPower = NowPower;

            return battleEffect;
        }

        public int ChangeValue(DamageCalculator calculator)
        {
            NowPower = (int)calculator.CalcAtkDamage(BasePower);

            return NowPower;
        }
    }
}