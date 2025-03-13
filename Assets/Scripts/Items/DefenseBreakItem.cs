using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

using GWEffectVer_0_2;

namespace GWItemVer_0_1
{
    [Serializable]
    public class DefenseBreakItem : Item
    {
        public DefenseBreakItem(string name = "default") : base(name)
        {
            fileName = "ItemTest";
            AddEffect(new SingleDefenseBreakEffect("BDItem", 50));

            SetSprite();

            id = "I_001";
        }

        // 차례를 시작할 때 실행
        override public void TurnStart()
        {

        }

        // 차례를 종료 할 때 실행
        override public void TurnEnd()
        {

        }

        // 사용시 실행
        override public void Use()
        {

        }

        // 사용시 실행
        override public bool Use(GameObject target)
        {
            Debug.Log("Item Use : " + name + " target > " + target.name);

            foreach (var effect in battleEffects)
            {
                effect.SetHitbox(target);
                //임시 setuser에 대한 대책 필요
                effect.SetUser(new PartyMember());
            }

            BattleEffectSystem.Instance.RequestBattleEffect(battleEffects);

            return true;
        }
    }
}