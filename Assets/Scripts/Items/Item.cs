using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace GWItemVer_0_1
{
    [Serializable]
    public class Item
    {
        public string name;
        public Sprite sprite;
        string imageRoot = "Image/Actives/";
        public string fileName;
        public List<BattleEffect> battleEffects;

        public string id;

        public Item(string name = "default")
        {
            this.name = name;
            battleEffects = new List<BattleEffect>();

            fileName = "ItemTest";
            SetSprite();

            id = "I_000";
        }

        // ���ʸ� ������ �� ����
        virtual public void TurnStart()
        {

        }

        // ���ʸ� ���� �� �� ����
        virtual public void TurnEnd()
        {

        }

        // ���� ����
        virtual public void Use()
        {

        }

        // ���� ����
        virtual public bool Use(GameObject target)
        {
            Debug.Log("Item Use : " + name + " target > " + target.name);

            return true;
        }

        public void SetSprite()
        {
            sprite = Resources.Load<Sprite>(imageRoot + fileName);
        }

        public void AddEffect(BattleEffect battleEffect)
        {
            battleEffects.Add(battleEffect);
        }

        public void SetEffects(List<BattleEffect> battleEffects)
        {
            this.battleEffects = battleEffects;
        }
    }
}