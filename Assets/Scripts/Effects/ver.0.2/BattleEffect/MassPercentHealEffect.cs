using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace GWEffectVer_0_2
{
    // 양산형 전투효과
    [Serializable]
    public class MassPercentHealEffect : BattleEffect
    {
        public MassPercentHealEffect(string name = "default", int power = 0, int maxCooltime = 0) : base(name, power, maxCooltime)
        {

        }

        public override void Active()
        {
            base.Active();
            Debug.Log("hitbox is " + Hitbox.name);
            int pos = -1;
            if (Target != null)
                pos = Target.Pos;

            foreach (var targetCharacter in PlayerData.Instance.characters)
            {
                targetCharacter.Heal(Mathf.Ceil((float)NowPower / (float)100 * targetCharacter.MaxHp));
            }
        }

        public override BattleEffect DeepCopy()
        {
            BattleEffect battleEffect = new MassPercentHealEffect(BattleEffectName, BasePower, MaxCooltime);
            battleEffect.SetTarget(Target);
            battleEffect.SetHitbox(Hitbox);
            battleEffect.SetUser(user);
            battleEffect.NowPower = NowPower;

            return battleEffect;
        }
    }
}