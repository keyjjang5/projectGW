using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using GWMonsterVer_0_1;

namespace GWMapVer_0_1
{
    public class BattleMap002 : BattleMap
    {
        public BattleMap002() : base() { }

        override public void SetMonster()
        {
            monsters = new List<Monster>()
                {
                    new MonsterA("MonsterA", 20, 1),
                    new MonsterA("MonsterA", 20, 3),
                    new MonsterB("MonsterB", 17, 5),
                    new MonsterB("MonsterB", 17, 7)
                };
        }

        override public Map Deepcopy()
        {
            Map copiedMap = new BattleMap002();

            return copiedMap;
        }
    }
}