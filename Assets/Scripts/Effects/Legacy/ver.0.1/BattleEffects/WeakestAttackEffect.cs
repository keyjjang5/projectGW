using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace GWEffectVer_0_1
{
    [Serializable]
    public class WeakestAttackEffect : BattleEffect, IValueChanger
    {
        public WeakestAttackEffect(int power) : base()
        {

        }
        public WeakestAttackEffect(string name, int power) : base(name)
        {

        }
        public WeakestAttackEffect(string name = "default", int power = 0, int maxCooltime = 0) : base(name, power, maxCooltime)
        {

        }

        override public void Active()
        {
            Hitbox.BroadcastMessage("MultipleHited", new AttackStruct(AttackType.Weakest, NowPower, Target.GetCharacter().Pos));
        }

        public int ChangeValue(DamageCalculator calculator)
        {
            NowPower = (int)calculator.CalcAtkDamage(BasePower);

            return NowPower;
        }

        public override BattleEffect DeepCopy()
        {
            BattleEffect battleEffect = new WeakestAttackEffect(BattleEffectName, BasePower, MaxCooltime);
            battleEffect.Target = Target;
            battleEffect.Hitbox = Hitbox;
            battleEffect.NowPower = NowPower;

            return battleEffect;
        }
    }
}