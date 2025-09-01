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
        // �⺻������ �ʱ�ȭ��
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

        // ������ �ڵ�
        Dictionary<string, float> itemsWeight;
        Dictionary<string, Item> itemPool;

        // �ڵ��� �����͸� �������� �Լ�
        // �ڵ带 �����ϰ� ��� �Լ�


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

        // �����̵� ���� �������� �Լ�, ���� �������� ���������� ����
        virtual public void SetData()
        {
            


            for(int i = 0; i<3;i++)
            {
                //GetItemRandomId, GetTearRandomId ������ ��ȭ ���Ѿ���
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

        // rewardUI�� �ִ� additem�� ���� addItem�Լ��� delegates�� ���� �߰��Ѵ�
        public void AddItem(string id)
        {
            Debug.Log("�̿ϼ�");
            Debug.Log("button : " + id);
        }

        public string GetRandomId()
        {
            // range�� �ִ밪�� ���� Define�� ���� ������ ���ǵ� �ʿ䰡 ����
            // ������ ������ ����
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
            // �� weight��
            float sum = 0;
            foreach (var weight in itemsWeight)
                sum += weight.Value;

            var randomValue = UnityEngine.Random.Range(0, sum);

            // �� �� �´� �� ��ȯ
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