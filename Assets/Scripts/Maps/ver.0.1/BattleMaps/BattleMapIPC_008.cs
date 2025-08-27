
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using GWMonsterVer_0_1;

namespace GWMapVer_0_1
{
    public class BattleMapIPC_008 : BattleMap
    {
        public BattleMapIPC_008() : base() { }

        override public void SetMonster()
        {
            monsters = new List<Monster>()
                {
                    new MonsterIPC_C("MonsterIPC_D", 12, 0),
                    new MonsterIPC_C("MonsterIPC_D", 12, 5)
                };
        }

        override public Map Deepcopy()
        {
            Map copiedMap = new BattleMapIPC_008();

            return copiedMap;
        }
    }
}