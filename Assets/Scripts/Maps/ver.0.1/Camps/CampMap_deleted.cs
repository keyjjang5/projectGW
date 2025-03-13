using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using GWMonsterVer_0_1;

namespace GWMapVer_0_1
{
    public class CampMap_deleted : Map
    {
        public CampMap_deleted() : base()
        {
            mapType = MapType.Camp;
        }

        override public Map Deepcopy()
        {
            Map copiedMap = new CampMap_deleted();

            return copiedMap;
        }
    }
}