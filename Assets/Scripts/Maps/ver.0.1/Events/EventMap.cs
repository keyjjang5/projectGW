using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using GWMonsterVer_0_1;

using UnityEngine.UI;

namespace GWMapVer_0_1
{
    public class EventMap : Map
    {
        public string text;
        public Sprite sprite;
        public List<m_Delegate> button1;
        public List<m_Delegate> button2;

        public EventMap() : base()
        {
            mapType = MapType.Event;
            button1 = new List<m_Delegate>();
            button2 = new List<m_Delegate>();

            SetData();
        }

        // ¿¢¼¿ÀÌµç ¹¹µç °¡Á®¿À´Â ÇÔ¼ö
        virtual public void SetData()
        {
            text = "Event Map Test";
            sprite = null;
            button1.Add(() => Debug.Log("Button Test1"));
            button2.Add(() => Debug.Log("Button Test2"));
        }

        override public Map Deepcopy()
        {
            Map copiedMap = new EventMap();

            return copiedMap;
        }
    }
}