using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using GWMonsterVer_0_1;

namespace GWMapVer_0_1
{
    public class BattleMap004 : BattleMap
    {
        public BattleMap004() : base() { }

        override public void SetMonster()
        {
            monsters = new List<Monster>()
                {
                    new MonsterC("MonsterC", 23, 6),
                    new MonsterC("MonsterC", 23, 7),
                    new MonsterD("MonsterD", 15, 1),
                    new MonsterD("MonsterD", 15, 3)
                };
        }

        override public Map Deepcopy()
        {
            Map copiedMap = new BattleMap004();

            return copiedMap;
        }
    }
}