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
                    new MonsterIPC_EliteA("MonsterD", 30, 0),
                    new MonsterIPC_EliteA("MonsterD", 30, 3),
                    new MonsterIPC_EliteA("MonsterD", 30, 6),

                    new MonsterIPC_EliteA("MonsterC", 30, 1),
                    new MonsterIPC_EliteA("MonsterC", 30, 4),
                    new MonsterIPC_EliteA("MonsterC", 30, 7),

                    new MonsterIPC_EliteA("MonsterC", 30, 2),
                    new MonsterIPC_EliteA("MonsterC", 30, 5),
                    new MonsterIPC_EliteA("MonsterC", 30, 8)
                };
        }

        override public Map Deepcopy()
        {
            Map copiedMap = new BattleMap001();

            return copiedMap;
        }
    }
}