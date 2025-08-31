using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleMoveLeftIsolationCard : Card
    {
        public SingleMoveLeftIsolationCard(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleMoveLeftIsolationCard";

            AddEffect(new SingleAttackEffect("Atk 5", 5));
            AddEffect(new SingleMoveLeftEffect("Move left", 1));            
            
            SetImage();
            Description = "5���ظ� ������ �������� �̵���Ų��.";
            cost = 0;
        }
    }
}