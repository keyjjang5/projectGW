using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using GWMonsterVer_0_1;

namespace GWMapVer_0_1
{
    public class BattleMap : Map
    {
        public BattleMap() : base()
        {
            mapType = MapType.Battle;

            SetMonster();
        }

        override public void SetMonster()
        {
            monsters = new List<Monster>()
                {
                    new MonsterC("MonsterC", 23, 1),
                    new MonsterD("MonsterD", 15, 5)
                };
        }

        override public Map Deepcopy()
        {
            Map copiedMap = new BattleMap();

            return copiedMap;
        }
    }
}