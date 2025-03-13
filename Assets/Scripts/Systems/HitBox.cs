using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    PartySystem PartySystem;

    public int xDivisionNum;
    public int yDivisionNum;

    public List<Transform> vertexs;


    // Start is called before the first frame update
    void Start()
    {
        PartySystem = GameObject.Find("MySystem").GetComponent<PartySystem>();

        vertexs = new List<Transform>();

        Transform tempField = transform.GetChild(0);
        for (int i = 0; i < tempField.childCount; i++)
            vertexs.Add(tempField.GetChild(i));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Hited(float value)
    {
        var pos = SearchPos();
        Debug.Log("point : " + pos);

        switch (gameObject.name)
        {
            case ("BattleFieldHitBox"):
                BattleField.Instance.Hited(pos, value);
                break;
            case ("PartyHitBox"):
                // �ӽ÷� ��� �������� �����
                int randomPos = Random.Range(0, PartySystem.characters.Count);
                PartySystem.Hited(randomPos, value);
                break;
            default:
                Debug.Log("HitBox : Hited error");
                break;
        }
    }

    public void MultipleHited(AttackStruct attack)
    {
        switch (gameObject.name)
        {
            case ("BattleFieldHitBox"):
                //BattleField.Instance.Hited(pos, value);
                BattleFieldHit(attack);
                break;
            case ("PartyHitBox"):
                //PartySystem.Hited(pos, value);
                PartyHited(attack);
                break;
            default:
                Debug.Log("HitBox : Hited error");
                break;
        }
    }

    void BattleFieldHit(AttackStruct attack)
    {
        int pos = -1;
        if (attack.TargetPos < 0)
            pos = SearchPos();
        else
            pos = attack.TargetPos;

        Debug.Log("point : " + pos);

        switch (attack.AttackType)
        {
            case (AttackType.RowR2):
                BattleField.Instance.Hited(pos, attack.Power);
                if (!(pos % 3 == 2))
                    BattleField.Instance.Hited(pos + 1, attack.Power);
                break;
            case (AttackType.ColB2):
                BattleField.Instance.Hited(pos, attack.Power);
                if (!(pos / 6 >= 1))
                    BattleField.Instance.Hited(pos + 3, attack.Power);
                break;
            case (AttackType.FullCross):
                BattleField.Instance.Hited(pos, attack.Power);
                if (!(pos / 6 >= 1))
                    BattleField.Instance.Hited(pos + 3, attack.Power);
                if (!(pos % 3 == 2))
                    BattleField.Instance.Hited(pos + 1, attack.Power);
                if (!(pos % 3 == 0))
                    BattleField.Instance.Hited(pos - 1, attack.Power);
                if (!(pos / 3 < 1))
                    BattleField.Instance.Hited(pos - 3, attack.Power);
                break;
            case (AttackType.Random):
                int randomPos = Random.Range(0, 9);
                BattleField.Instance.Hited(randomPos, attack.Power);
                break;
            case (AttackType.Single):
                BattleField.Instance.Hited(pos, attack.Power);
                break;
            default:
                break;
        }
    }

    void PartyHited(AttackStruct attack)
    {
        int pos = -1;
        if (attack.TargetPos < 0)
            pos = SearchPos();
        else
            pos = attack.TargetPos;

        //Debug.Log("point : " + pos);
 
        switch (attack.AttackType)
        {
            case (AttackType.All):
                for (int i = 0; i < PartySystem.characters.Count; i++)
                    PartySystem.Hited(i, attack.Power);
                break;
            //case (AttackType.Random):
            //    PartySystem.Hited(PartySystem.GetCRandomTarget().Pos, attack.Power);
            //    break;
            //case (AttackType.Weakest):
            //    float tempHp = 999;
            //    int WeakestPos = -1;
            //    foreach (var character in PartySystem.characters)
            //    {
            //        if (character.NowHp <= 0)
            //            continue;

            //        if (tempHp >= character.NowHp)
            //        {
            //            tempHp = character.NowHp;
            //            WeakestPos = character.Pos;
            //        }

            //    }
            //    PartySystem.Hited(WeakestPos, attack.Power);
            //    break;
            default:
                PartySystem.Hited(pos, attack.Power);
                break;
        }
    }

    public void Heal(HealStruct healStruct)
    {
        switch (gameObject.name)
        {
            case ("BattleFieldHitBox"):
                //BattleField.Instance.Heal(pos, value);
                BattleFieldHeal(healStruct);
                break;
            case ("PartyHitBox"):
                //PartySystem.Heal(pos, value);
                PartyHeal(healStruct);
                break;
            default:
                Debug.Log("HitBox : Hited error");
                break;
        }
    }

    public void BattleFieldHeal(HealStruct healStruct)
    {
        int pos = -1;
        if (healStruct.TargetPos < 0)
            pos = SearchPos();
        else
            pos = healStruct.TargetPos;

        switch (healStruct.HealType)
        {
            case (HealType.Single):
                BattleField.Instance.Heal(pos, healStruct.Power);
                break;
            case (HealType.Mass):
                for (int i = 0; i < BattleField.Instance.spawns.Count; i++)
                    BattleField.Instance.Heal(i, healStruct.Power);
                break;
            default:
                break;
        }
    }

    public void PartyHeal(HealStruct healStruct)
    {
        int pos = -1;
        if (healStruct.TargetPos < 0)
            pos = SearchPos();
        else
            pos = healStruct.TargetPos;

        switch (healStruct.HealType)
        {
            case (HealType.Single):
                PartySystem.Heal(pos, healStruct.Power);
                break;
            case (HealType.Mass):
                for (int i = 0; i < PartySystem.characters.Count; i++)
                    PartySystem.Heal(i, healStruct.Power);
                break;
            case (HealType.SinglePercent):
                PartySystem.Heal(pos, healStruct.Power/100*PartySystem.characters[pos].MaxHp);
                break;
            case (HealType.MassPercent):
                for (int i = 0; i < PartySystem.characters.Count; i++)
                {
                    PartySystem.Heal(i, healStruct.Power / 100 * PartySystem.characters[i].MaxHp);
                }
                break;
            default:
                break;
            }
    }

    public void AddShield(ShieldStruct shieldStruct)
    {
        switch (gameObject.name)
        {
            case ("BattleFieldHitBox"):
                //BattleField.Instance.AddShield(pos, value);
                BattleFieldShield(shieldStruct);
                break;
            case ("PartyHitBox"):
                //PartySystem.AddShield(pos, value);
                PartyShield(shieldStruct);
                break;
            default:
                Debug.Log("HitBox : Hited error");
                break;
        }
    }

    public void BattleFieldShield(ShieldStruct shieldStruct)
    {
        int pos = -1;
        if (shieldStruct.TargetPos < 0)
            pos = SearchPos();
        else
            pos = shieldStruct.TargetPos;

        switch (shieldStruct.ShieldType)
        {
            case (ShieldType.Single):
                BattleField.Instance.AddShield(pos, shieldStruct.Power);
                break;
            case (ShieldType.Mass):
                for (int i = 0; i < PartySystem.characters.Count; i++)
                    BattleField.Instance.Heal(i, shieldStruct.Power);
                break;
            default:
                break;
        }
    }

    public void PartyShield(ShieldStruct shieldStruct)
    {
        int pos = -1;
        if (shieldStruct.TargetPos < 0)
            pos = SearchPos();
        else
            pos = shieldStruct.TargetPos;

        switch (shieldStruct.ShieldType)
        {
            case (ShieldType.Single):
                PartySystem.AddShield(pos, shieldStruct.Power);
                break;
            case (ShieldType.Mass):
                for (int i = 0; i < PartySystem.characters.Count; i++)
                    PartySystem.Heal(i, shieldStruct.Power);
                break;
            default:
                break;
        }
    }

    public void AddStatusEffect(StatusEffect statusEffect)
    {
        var pos = SearchPos();
        // Debug.Log("point : " + pos);

        switch (gameObject.name)
        {
            case ("BattleFieldHitBox"):
                BattleField.Instance.AddStatusEffect(pos, statusEffect);
                break;
            case ("PartyHitBox"):
                // �ӽ÷� ��� �������� �����
                int randomPos = Random.Range(0, PartySystem.characters.Count);
                PartySystem.AddStatusEffect(randomPos, statusEffect);
                break;
            default:
                Debug.Log("HitBox : Hited error");
                break;
        }
    }

    public void AddStatusEffect2(StatusStruct statusStruct)
    {
        int pos = -1;
        if (statusStruct.TargetPos < 0)
            pos = SearchPos();
        else
            pos = statusStruct.TargetPos;

        if (statusStruct.type == AttackType.Self)
        {
            if (statusStruct.StatusEffect.user.GetCharacter() is Monster)
                BattleField.Instance.AddStatusEffect(pos, statusStruct.StatusEffect);
            else if (statusStruct.StatusEffect.user.GetCharacter() is PartyMember)
                PartySystem.Instance.AddStatusEffect(pos, statusStruct.StatusEffect);
            else
                Debug.Log("HitBox : Hited error");
        }
        else
        {
            if (statusStruct.StatusEffect.user.GetCharacter() is Monster)
                PartySystem.Instance.AddStatusEffect(pos, statusStruct.StatusEffect);
            else if (statusStruct.StatusEffect.user.GetCharacter() is PartyMember)
                BattleField.Instance.AddStatusEffect(pos, statusStruct.StatusEffect);
            else
                Debug.Log("HitBox : Hited error");
        }
    }

    public void Knockback(KnockbackStruct kbStruct)
    {
        int pos = -1;
        if (kbStruct.TargetPos < 0)
            pos = SearchPos();
        else
            pos = kbStruct.TargetPos;

        BattleField.Instance.Knockback(pos, kbStruct.Power);
    }

    // ���콺�� ��� ������ �ִ����� ã�´�
    public int SearchPos()
    {
        List<Vector3> horizontalPoints = new List<Vector3>();
        List<Vector3> verticalPoints = new List<Vector3>();
        List<Vector3> fieldPoints = new List<Vector3>();

        for (int i = 0; i < xDivisionNum; i++)
        {
            float weight = (float)i / xDivisionNum;
            horizontalPoints.Add(Vector3.Lerp(vertexs[2].position, vertexs[3].position, weight));
        }
        for (int i = 0; i < yDivisionNum; i++) 
        {
            float weight = (float)i / yDivisionNum;
            verticalPoints.Add(Vector3.Lerp(vertexs[2].position, vertexs[0].position, weight));
        }

        for (int i = 0; i < yDivisionNum; i++)
            for (int j = 0; j < xDivisionNum; j++)
            {
                fieldPoints.Add(new Vector3(horizontalPoints[j].x, verticalPoints[i].y, verticalPoints[i].z));
            }

        Vector3 hInterval;
        Vector3 vInterval;
        if (horizontalPoints.Count > 1)
            hInterval = horizontalPoints[1] - horizontalPoints[0];
        else
            hInterval = vertexs[3].position - vertexs[2].position;
        if (verticalPoints.Count > 1)
            vInterval = verticalPoints[1] - verticalPoints[0];
        else
            vInterval = vertexs[0].position - vertexs[2].position;

        int pos = -1;

        for (int i = 0; i < fieldPoints.Count; i++)
        {
            Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                        Input.mousePosition.y, -Camera.main.transform.position.z));

            if (fieldPoints[i].x <= point.x && fieldPoints[i].x + hInterval.x > point.x
                && fieldPoints[i].y <= point.y && fieldPoints[i].y + vInterval.y > point.y)
            {
                pos = i;
                break;
            }
        }

        return pos;
    }
}
