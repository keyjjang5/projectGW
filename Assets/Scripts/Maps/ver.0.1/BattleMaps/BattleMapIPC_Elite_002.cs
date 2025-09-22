
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using GWMonsterVer_0_1;

namespace GWMapVer_0_1
{
    public class BattleMapIPC_Elite_002 : BattleMap
    {
        public BattleMapIPC_Elite_002() : base() { }

        override public void SetMonster()
        {
            monsters = new List<Monster>()
                {
                    new MonsterIPC_F("Enhanced Mushroom", 23, 3),
                    new MonsterIPC_E("Enhanced Thief", 26, 1),
                    new MonsterIPC_B("Mushroom", 21, 5),
                    new MonsterIPC_B("Mushroom", 21, 7)
                };
        }

        override public Map Deepcopy()
        {
            Map copiedMap = new BattleMapIPC_Elite_002();

            return copiedMap;
        }
    }
}