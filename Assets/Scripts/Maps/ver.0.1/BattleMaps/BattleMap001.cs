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
                    new MonsterIPC_EliteA("MonsterD", 20, 0),
                    new MonsterIPC_EliteA("MonsterD", 20, 3),
                    new MonsterIPC_EliteA("MonsterD", 20, 6),

                    new MonsterIPC_EliteA("MonsterC", 20, 2),
                    new MonsterIPC_EliteA("MonsterC", 20, 5),
                    new MonsterIPC_EliteA("MonsterC", 20, 8),
                };
        }

        override public Map Deepcopy()
        {
            Map copiedMap = new BattleMap001();

            return copiedMap;
        }
    }
}