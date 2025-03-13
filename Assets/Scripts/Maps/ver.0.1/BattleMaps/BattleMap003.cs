using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using GWMonsterVer_0_1;

namespace GWMapVer_0_1
{
    public class BattleMap003 : BattleMap
    {
        public BattleMap003() : base() { }

        override public void SetMonster()
        {
            monsters = new List<Monster>()
                {
                    new MonsterC("MonsterC", 23, 3),
                    new MonsterC("MonsterC", 23, 4),
                    new MonsterD("MonsterD", 15, 0),
                    new MonsterD("MonsterD", 15, 2)
                };
        }

        override public Map Deepcopy()
        {
            Map copiedMap = new BattleMap003();

            return copiedMap;
        }
    }
}