using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using GWMonsterVer_0_1;

namespace GWMapVer_0_1
{
    public class BattleMapIPC_005 : BattleMap
    {
        public BattleMapIPC_005() : base() { }

        override public void SetMonster()
        {
            monsters = new List<Monster>()
                {
                    new MonsterIPC_C("MonsterIPC_C", 14, 6),
                    new MonsterIPC_C("MonsterIPC_C", 14, 5),
                    new MonsterIPC_D("MonsterIPC_D", 12, 2)

                };
        }

        override public Map Deepcopy()
        {
            Map copiedMap = new BattleMapIPC_005();

            return copiedMap;
        }
    }
}