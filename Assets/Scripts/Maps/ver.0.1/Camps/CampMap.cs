using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using GWMonsterVer_0_1;
using GWEffectVer_0_2;

namespace GWMapVer_0_1
{
    public class CampMap : Map
    {
        public string text;
        public Sprite sprite;
        public List<m_Delegate> button1;
        public List<m_Delegate> button2;
        public List<m_Delegate> button3;

        public CampMap() : base()
        {
            mapType = MapType.Camp;
            button1 = new List<m_Delegate>();
            button2 = new List<m_Delegate>();
            button3 = new List<m_Delegate>();

            SetData();
        }

        // ¿¢¼¿ÀÌµç ¹¹µç °¡Á®¿À´Â ÇÔ¼ö
        virtual public void SetData()
        {
            text = "Camp Map Test";
            sprite = null;
            button1.Add(() => Debug.Log("Gacha Button"));
            button2.Add(() => Debug.Log("Rest Button"));
            button2.Add(() => Rest());
            button3.Add(() => Debug.Log("Talk Button"));
        }

        public void Rest()
        {
            List<BattleEffect> restEffect = new List<BattleEffect>();
            restEffect.Add(new MassPercentHealEffect("CampRest", 30));
            foreach(var effect in restEffect)
                effect.SetHitbox(GameObject.Find("PartyHitBox"));

            BattleEffectSystem.Instance.RequestBattleEffect(restEffect);
        }

        override public Map Deepcopy()
        {
            Map copiedMap = new CampMap();

            return copiedMap;
        }
    }
}
