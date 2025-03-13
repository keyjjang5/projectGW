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

        // ���ʸ� ������ �� ����
        override public void TurnStart()
        {

        }

        // ���ʸ� ���� �� �� ����
        override public void TurnEnd()
        {

        }

        // ���� ����
        override public void Use()
        {

        }

        // ���� ����
        override public bool Use(GameObject target)
        {
            Debug.Log("Item Use : " + name + " target > " + target.name);

            foreach (var effect in battleEffects)
            {
                effect.SetHitbox(target);
                //�ӽ� setuser�� ���� ��å �ʿ�
                effect.SetUser(new PartyMember());
            }

            BattleEffectSystem.Instance.RequestBattleEffect(battleEffects);

            return true;
        }
    }
}