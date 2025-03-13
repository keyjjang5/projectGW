using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using GWMonsterVer_0_1;

namespace GWMapVer_0_1
{
    public class BattleMap001 : BattleMap
    {
        public BattleMap001() : base() { }

        override public void SetMonster()
        {
            monsters = new List<Monster>()
                {
                    new MonsterA("MonsterA", 20, 2),
                    new MonsterA("MonsterA", 20, 4),
                    new MonsterB("MonsterB", 17, 3),
                    new MonsterB("MonsterB", 17, 7)
                };
        }

        override public Map Deepcopy()
        {
            Map copiedMap = new BattleMap001();

            return copiedMap;
        }
    }
}