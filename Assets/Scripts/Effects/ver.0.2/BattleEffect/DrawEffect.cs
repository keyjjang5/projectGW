using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace GWEffectVer_0_2
{
    // 양산형 전투효과
    [Serializable]
    public class DrawEffect : BattleEffect
    {
        public DrawEffect(string name = "default", int power = 0, int maxCooltime = 0) : base(name, power, maxCooltime)
        {

        }

        public override void Active()
        {
            base.Active();
            Debug.Log("hitbox is " + Hitbox.name);
            int pos = -1;
            if (Target != null)
                pos = Target.Pos;

            for (int i = 0; i < NowPower; i++)
                DeckSystem.Instance.Draw();
        }

        public override BattleEffect DeepCopy()
        {
            BattleEffect battleEffect = new DrawEffect(BattleEffectName, BasePower, MaxCooltime);
            battleEffect.SetTarget(Target);
            battleEffect.SetHitbox(Hitbox);
            battleEffect.SetUser(user);
            battleEffect.NowPower = NowPower;

            return battleEffect;
        }
    }
}