using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWMonsterVer_0_1;

namespace GWMapVer_0_1
{
    public class Map
    {
        public MapType mapType { protected set; get; }
        public List<Monster> monsters { protected set; get; }

        public Map()
        {
            
        }

        virtual public void SetMonster()
        {
            monsters = new List<Monster>()
                {
                    new MonsterA("Test", 1, 4)
                };
        }

        virtual public Map Deepcopy()
        {
            Map copiedMap = new Map();

            return copiedMap;
        }
    }
}