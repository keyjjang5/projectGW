using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace GWEffectVer_0_2
{
    // ����� ����ȿ��
    [Serializable]
    public class CooperationEffect : AdditionalEffect, IValueChanger
    {
        public CooperationEffect(List<BattleEffect> effects, string name = "default", int power = 0, int maxCooltime = 0) : base(effects, name, power, maxCooltime)
        {
            additionalStruct.type = AdditionalType.Cooperation;
        }

        public override void Active()
        {
            base.Active();

            foreach (var effect in additionalStruct.effects)
            {
                effect.SetHitbox(Hitbox);
                effect.SetTarget(Target);
                effect.SetUser(user);
            }

            //  ���⼭ chainStruct.effects.Add()�� ��������
            //  �ʱ�ȭ�� �� �޴� ������ ������

            Hitbox.BroadcastMessage("CheckAdditionalEffect", additionalStruct
            );
        }

        public override BattleEffect DeepCopy()
        {
            List<BattleEffect> listDC = new List<BattleEffect>();
            foreach (var effect in additionalStruct.effects)
                listDC.Add(effect.DeepCopy());

            BattleEffect battleEffect = new CooperationEffect(listDC, BattleEffectName, BasePower, MaxCooltime);
            battleEffect.SetTarget(Target);
            battleEffect.SetHitbox(Hitbox);
            battleEffect.SetUser(user);
            battleEffect.NowPower = NowPower;

            return battleEffect;
        }
    }
}