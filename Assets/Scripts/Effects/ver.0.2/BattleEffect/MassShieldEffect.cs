using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace GWEffectVer_0_2
{
    // ����� ����ȿ��
    [Serializable]
    public class MassShieldEffect : BattleEffect
    {
        public MassShieldEffect(string name = "default", int power = 0, int maxCooltime = 0) : base(name, power, maxCooltime)
        {

        }

        public override void Active()
        {
            base.Active();
            Debug.Log("hitbox is " + Hitbox.name);
            int pos = -1;
            if (Target != null)
                pos = Target.Pos;

            Hitbox.BroadcastMessage("AddShield", new ShieldStruct(ShieldType.Mass, NowPower, pos));
        }

        public override BattleEffect DeepCopy()
        {
            BattleEffect battleEffect = new MassShieldEffect(BattleEffectName, BasePower, MaxCooltime);
            battleEffect.SetTarget(Target);
            battleEffect.SetHitbox(Hitbox);
            battleEffect.SetUser(user);
            battleEffect.NowPower = NowPower;

            return battleEffect;
        }
    }
}