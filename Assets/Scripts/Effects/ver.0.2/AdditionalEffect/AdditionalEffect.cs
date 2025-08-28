using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace GWEffectVer_0_2
{
    // ����� ����ȿ��
    [Serializable]
    public class AdditionalEffect : BattleEffect, IValueChanger
    {
        protected AdditionalEffectStruct additionalStruct;

        public AdditionalEffect(List<BattleEffect> effects, string name = "default", int power = 0, int maxCooltime = 0) : base(name, power, maxCooltime)
        {
            additionalStruct = new AdditionalEffectStruct();
            additionalStruct.effects = effects;

        }

        public override void Active()
        {
            base.Active();
            Debug.Log("hitbox is " + Hitbox.name);
            int pos = -1;
            if (Target != null)
                pos = Target.Pos;

            //  ������
            additionalStruct.TargetPos = pos;

            //foreach(var effect in additionalStruct.effects)
            //{
            //    effect.SetHitbox(Hitbox);
            //    effect.SetTarget(Target);
            //    effect.SetUser(user);
            //}

            ////  ���⼭ chainStruct.effects.Add()�� ��������

            //Hitbox.BroadcastMessage("CheckAdditionalEffect", additionalStruct
            //);
        }

        public override BattleEffect DeepCopy()
        {
            List<BattleEffect> listDC = new List<BattleEffect>();
            foreach (var effect in additionalStruct.effects)
                listDC.Add(effect.DeepCopy());

            BattleEffect battleEffect = new AdditionalEffect(listDC, BattleEffectName, BasePower, MaxCooltime);
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