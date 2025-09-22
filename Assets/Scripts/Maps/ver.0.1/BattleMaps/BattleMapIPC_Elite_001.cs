
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using GWMonsterVer_0_1;

namespace GWMapVer_0_1
{
    public class BattleMapIPC_Elite_001 : BattleMap
    {
        public BattleMapIPC_Elite_001() : base() { }

        override public void SetMonster()
        {
            monsters = new List<Monster>()
                {
                    new MonsterIPC_EliteA("MonsterIPC_EliteA", 70, 4),
                    new MonsterIPC_B("Mushroom", 21, 0)
                };
        }

        override public Map Deepcopy()
        {
            Map copiedMap = new BattleMapIPC_Elite_001();

            return copiedMap;
        }
    }
}