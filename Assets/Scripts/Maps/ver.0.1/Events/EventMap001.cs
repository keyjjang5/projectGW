using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using GWMonsterVer_0_1;

using UnityEngine.UI;

namespace GWMapVer_0_1
{
    public class EventMap001 : EventMap
    {
        public EventMap001() : base() { }

        override public void SetData()
        {
            text = "Event Map 001";
            sprite = null;

            button1.Add(() => Debug.Log("Map001_1"));
            button1.Add(() => PlayerData.Instance.AddMoney(5));

            button2.Add(() => Debug.Log("Button Test2"));
            button2.Add(() => PlayerData.Instance.AddMoney(10));
        }

        override public Map Deepcopy()
        {
            Map copiedMap = new EventMap001();

            return copiedMap;
        }
    }
}