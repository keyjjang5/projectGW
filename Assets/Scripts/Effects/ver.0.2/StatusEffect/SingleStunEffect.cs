using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace GWEffectVer_0_2
{
    public class SingleStunEffect : StatusEffect
    {
        // StatusEffectType�� Duration�� �߰��ۼ��Ѵ�.
        public SingleStunEffect(string name = "default", int power = 0, int maxCooltime = 0) : base(name, power, maxCooltime)
        {
            StatusEffectType = StatusEffectType.Stun;
            Duration = 1;
        }

        public override BattleEffect DeepCopy()
        {
            BattleEffect battleEffect = new SingleStunEffect(BattleEffectName, BasePower, MaxCooltime);
            battleEffect.SetTarget(Target);
            battleEffect.SetHitbox(Hitbox);
            battleEffect.SetUser(user);
            battleEffect.NowPower = NowPower;

            return battleEffect;
        }

        // �ʼ��� �߰� �ۼ��Ѵ�.
        public override StatusEffect DeepCopy_Status()
        {
            StatusEffect statusEffect = new SingleStunEffect(BattleEffectName, BasePower, MaxCooltime);
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

            Hitbox.BroadcastMessage("AddStatusEffect2", new StatusStruct(this, pos, AttackType.Single));
        }
    }
}