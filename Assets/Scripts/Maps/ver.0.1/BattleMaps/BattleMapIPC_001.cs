using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using GWMonsterVer_0_1;

namespace GWMapVer_0_1
{
    public class BattleMapIPC_001 : BattleMap
    {
        public BattleMapIPC_001() : base() { }

        override public void SetMonster()
        {
            monsters = new List<Monster>()
                {
                    new MonsterIPC_A("Thief", 25, 2),
                    new MonsterIPC_B("Mushroom", 21, 3),
                    new MonsterIPC_B("Mushroom", 21, 7)
                };
        }

        override public Map Deepcopy()
        {
            Map copiedMap = new BattleMapIPC_001();

            return copiedMap;
        }
    }
}