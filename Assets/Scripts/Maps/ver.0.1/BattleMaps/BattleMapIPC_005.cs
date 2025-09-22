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
                    new MonsterIPC_C("Small Mushroom", 14, 1),
                    new MonsterIPC_C("Small Mushroom", 14, 2),
                    new MonsterIPC_D("Small Warrior", 12, 5)

                };
        }

        override public Map Deepcopy()
        {
            Map copiedMap = new BattleMapIPC_005();

            return copiedMap;
        }
    }
}