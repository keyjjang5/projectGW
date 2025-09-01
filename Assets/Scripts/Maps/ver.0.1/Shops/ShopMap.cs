using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using GWMonsterVer_0_1;
using GWItemVer_0_1;
using UnityEngine.UI;

namespace GWMapVer_0_1
{

    public struct shopItem
    {
        public string text;
        public Sprite sprite;
        public List<m_Delegate> button;

        public shopItem(string name, Sprite sprite, List<m_Delegate> delegates)
        {
            text = name;
            this.sprite = sprite;
            button = delegates;
        }
        // 기본적으로 초기화함
        public shopItem(string name, Sprite sprite)
        {
            text = name;
            this.sprite = sprite;
            button = new List<m_Delegate>();
        }
        public void SetButton(List<m_Delegate> delegates)
        {
            button = delegates;
        }
    }
    public class ShopMap : Map
    {
        public List<shopItem> shopItems;
        public List<shopItem> shopTears;

        // 아이템 코드
        Dictionary<string, float> itemsWeight;
        Dictionary<string, Item> itemPool;

        // 코드의 데이터를 가져오는 함수
        // 코드를 랜덤하게 얻는 함수


        public ShopMap() : base()
        {
            shopItems = new List<shopItem>();
            shopTears = new List<shopItem>();
            mapType = MapType.Shop;

            itemsWeight = new Dictionary<string, float>();
            itemPool = new Dictionary<string, Item>();

            Item temp = new Item("TI1");
            itemPool.Add(temp.id, new Item("TI1"));
            temp = new GWItemVer_0_1.DefenseBreakItem("TI2");
            itemPool.Add(temp.id, new GWItemVer_0_1.DefenseBreakItem("TI2"));

            foreach(var item in itemPool)
                itemsWeight.Add(item.Key, 1 / itemPool.Count);

            SetData();
        }

        // 엑셀이든 뭐든 가져오는 함수, 현재 랜덤으로 가져오도록 설정
        virtual public void SetData()
        {
            


            for(int i = 0; i<3;i++)
            {
                //GetItemRandomId, GetTearRandomId 등으로 분화 시켜야함
                string temp_id;
                List<m_Delegate> delegates = new List<m_Delegate>();

                temp_id = GetRandomId();
                delegates.Add(() => AddItem(temp_id));
                shopItems.Add(new shopItem("item"+i, null, delegates));
                //delegates.Clear();
            }

            for(int i =0;i<1;i++)
            {
                string temp_id;
                List<m_Delegate> delegates = new List<m_Delegate>();

                temp_id = GetRandomId();
                delegates.Add(() => AddItem(temp_id));
                shopTears.Add(new shopItem("Tear" + i, null, delegates));
                //delegates.Clear();
            }
            
        }

        // rewardUI에 있는 additem과 같은 addItem함수를 delegates를 통해 추가한다
        public void AddItem(string id)
        {
            Debug.Log("미완성");
            Debug.Log("button : " + id);
        }

        public string GetRandomId()
        {
            // range의 최대값은 추후 Define과 같은 정수로 정의될 필요가 있음
            // 오류의 여지가 많다
            int ranNum = UnityEngine.Random.Range(0, 2);
            //Debug.Log("ranNum = " + ranNum);
            int i = 0;
            foreach(var pair in itemPool)
            {
                if (ranNum == i)
                    return pair.Key;

                i++;
            }
            string id = null;

            return id;
        }


        public string IdRandomSelect()
        {
            // 총 weight합
            float sum = 0;
            foreach (var weight in itemsWeight)
                sum += weight.Value;

            var randomValue = UnityEngine.Random.Range(0, sum);

            // 그 중 맞는 값 반환
            float current = 0.0f;
            foreach (var pair in itemsWeight)
            {
                current += pair.Value;

                if (randomValue < current)
                {
                    return pair.Key;
                }
            }

            return "err_000";
        }

        override public Map Deepcopy()
        {
            Map copiedMap = new ShopMap();

            return copiedMap;
        }
    }
}