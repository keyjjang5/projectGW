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
                    new MonsterIPC_A("MonsterIPC_A", 25, 1),
                    new MonsterIPC_B("MonsterIPC_B", 21, 5),
                    new MonsterIPC_B("MonsterIPC_B", 21, 7)
                };
        }

        override public Map Deepcopy()
        {
            Map copiedMap = new BattleMapIPC_001();

            return copiedMap;
        }
    }
}