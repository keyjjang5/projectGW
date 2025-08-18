using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using GWMonsterVer_0_1;

namespace GWMapVer_0_1
{
    public class BattleMapIPC_003 : BattleMap
    {
        public BattleMapIPC_003() : base() { }

        override public void SetMonster()
        {
            monsters = new List<Monster>()
                {
                    new MonsterIPC_B("MonsterIPC_B", 18, 1),
                    new MonsterIPC_B("MonsterIPC_B", 18, 3),
                    new MonsterIPC_B("MonsterIPC_B", 18, 5),
                    new MonsterIPC_B("MonsterIPC_B", 18, 7)
                };
        }

        override public Map Deepcopy()
        {
            Map copiedMap = new BattleMapIPC_003();

            return copiedMap;
        }
    }
}