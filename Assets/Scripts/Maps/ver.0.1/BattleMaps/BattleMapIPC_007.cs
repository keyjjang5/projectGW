
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using GWMonsterVer_0_1;

namespace GWMapVer_0_1
{
    public class BattleMapIPC_007 : BattleMap
    {
        public BattleMapIPC_007() : base() { }

        override public void SetMonster()
        {
            monsters = new List<Monster>()
                {
                    new MonsterIPC_C("Small Mushroom", 14, 1),
                    new MonsterIPC_C("Small Mushroom", 14, 4),
                    new MonsterIPC_C("Small Mushroom", 14, 6)

                };
        }

        override public Map Deepcopy()
        {
            Map copiedMap = new BattleMapIPC_007();

            return copiedMap;
        }
    }
}