using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using GWMonsterVer_0_1;

namespace GWMapVer_0_1
{
    public class BattleMapIPC_004 : BattleMap
    {
        public BattleMapIPC_004() : base() { }

        override public void SetMonster()
        {
            monsters = new List<Monster>()
                {
                    new MonsterIPC_A("Thief", 25, 1),
                    new MonsterIPC_A("Thief", 25, 4)
                };
        }

        override public Map Deepcopy()
        {
            Map copiedMap = new BattleMapIPC_004();

            return copiedMap;
        }
    }
}