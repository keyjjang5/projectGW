using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace GWEffectVer_0_2
{
    public class SelfAttackIncreaseEffect : StatusEffect
    {
        // StatusEffectType과 Duration을 추가작성한다.
        public SelfAttackIncreaseEffect(string name = "default", int power = 0, int maxCooltime = 0) : base(name, power, maxCooltime)
        {
            StatusEffectType = StatusEffectType.Power;
            Duration = 2;
        }

        public override BattleEffect DeepCopy()
        {
            BattleEffect battleEffect = new SelfAttackIncreaseEffect(BattleEffectName, BasePower, MaxCooltime);
            battleEffect.SetTarget(Target);
            battleEffect.SetHitbox(Hitbox);
            battleEffect.SetUser(user);
            battleEffect.NowPower = NowPower;

            return battleEffect;
        }

        // 필수로 추가 작성한다.
        public override StatusEffect DeepCopy_Status()
        {
            StatusEffect statusEffect = new SelfAttackIncreaseEffect(BattleEffectName, BasePower, MaxCooltime);
            statusEffect.SetTarget(Target);
            statusEffect.SetHitbox(Hitbox);
            statusEffect.SetUser(user);
            statusEffect.NowPower = NowPower;
            return statusEffect;
        }

        public override void Active()
        {
            base.Active();

            int pos = -1;
            if (Target != null)
                pos = Target.Pos;

            Hitbox.BroadcastMessage("AddStatusEffect2", new StatusStruct(this, pos, AttackType.Self));
        }

        // 필요하다면 AddEffect와 RemoveEffect를 작성한다.
        public override void AddEffect()
        {
            base.AddEffect();
            float value = (float)BasePower / 100;
            Target.DamageCalculator.ChangeAtk(value);

            var temp = Target as Monster;
            temp.CalcPower();
        }

        public override void RemoveEffect()
        {
            base.RemoveEffect();
            float value = (float)BasePower / 100;
            Target.DamageCalculator.ChangeAtk(-value);
        }
    }
}