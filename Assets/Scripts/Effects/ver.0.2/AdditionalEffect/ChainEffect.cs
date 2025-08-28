using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace GWEffectVer_0_2
{
    // 양산형 전투효과
    [Serializable]
    public class ChainEffect : AdditionalEffect, IValueChanger
    {
        public ChainEffect(List<BattleEffect> effects, string name = "default", int power = 0, int maxCooltime = 0) : base(effects, name, power, maxCooltime)
        {
            additionalStruct.type = AdditionalType.Chain;
        }

        public override void Active()
        {
            base.Active();
            //Debug.Log("hitbox is " + Hitbox.name);
            //int pos = -1;
            //if (Target != null)
            //    pos = Target.Pos;

            ////  설정값
            //additionalStruct.type = AdditionalType.Chain;
            //additionalStruct.TargetPos = pos;

            foreach (var effect in additionalStruct.effects)
            {
                effect.SetHitbox(Hitbox);
                effect.SetTarget(Target);
                effect.SetUser(user);
            }

            //  여기서 chainStruct.effects.Add()로 만들어야함
            //  초기화할 때 받는 것으로 변경함

            Hitbox.BroadcastMessage("CheckAdditionalEffect", additionalStruct
            );
        }

        public override BattleEffect DeepCopy()
        {
            List<BattleEffect> listDC = new List<BattleEffect>();
            foreach (var effect in additionalStruct.effects)
                listDC.Add(effect.DeepCopy());

            BattleEffect battleEffect = new ChainEffect(listDC, BattleEffectName, BasePower, MaxCooltime);
            battleEffect.SetTarget(Target);
            battleEffect.SetHitbox(Hitbox);
            battleEffect.SetUser(user);
            battleEffect.NowPower = NowPower;

            return battleEffect;
        }
    }
}