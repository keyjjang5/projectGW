using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GWEffectVer_0_1
{
    public class SelfAttackincrease : StatusEffect
    {
        public SelfAttackincrease(string name = "default", int power = 0, int maxCooltime = 0) : base(name, power, maxCooltime)
        {
            StatusEffectType = StatusEffectType.Power;
            Duration = 2;
        }

        public override StatusEffect DeepCopy_Status()
        {
            StatusEffect statusEffect = new SelfAttackincrease(BattleEffectName, BasePower, MaxCooltime);
            statusEffect.SetTarget(Target);
            statusEffect.SetHitbox(Hitbox);

            return statusEffect;
        }

        public override BattleEffect DeepCopy()
        {
            BattleEffect battleEffect = new SelfAttackincrease(BattleEffectName, BasePower, MaxCooltime);
            battleEffect.SetTarget(Target);
            battleEffect.Hitbox = Hitbox;
            battleEffect.user = user;

            return battleEffect;
        }

        override public void Active()
        {
            base.Active();
            Debug.Log("target pos : " + user.GetCharacter().Pos);
            Hitbox.BroadcastMessage("AddStatusEffect2", new StatusStruct(this, user.GetCharacter().Pos, AttackType.Self));
            // Debug.Log("Duration = " + Duration);
        }

        override public float Active(float value)
        {
            float returnValue = 0;

            returnValue = returnValue * BasePower;

            return returnValue;
        }

        public override void AddEffect()
        {
            base.AddEffect();
            float value = (float)BasePower / 100;
            Target.attackValue += value;

            var temp = Target as Monster;
            temp.CalcPower();
        }

        public override void RemoveEffect()
        {
            base.RemoveEffect();
            float value = (float)BasePower / 100;
            Target.attackValue -= value;
        }
    }
}