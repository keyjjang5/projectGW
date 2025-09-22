using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using GWMonsterVer_0_1;

namespace GWMapVer_0_1
{
    public class BattleMapIPC_006 : BattleMap
    {
        public BattleMapIPC_006() : base() { }

        override public void SetMonster()
        {
            monsters = new List<Monster>()
                {
                    new MonsterIPC_C("Small Mushroom", 14, 3),
                    new MonsterIPC_C("Small Mushroom", 14, 5),
                    new MonsterIPC_D("Small Warrior", 13, 1)

                };
        }

        override public Map Deepcopy()
        {
            Map copiedMap = new BattleMapIPC_006();

            return copiedMap;
        }
    }
}