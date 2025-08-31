using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.Events;

[Serializable]
public class Monster : Character
{
    //public string Name; //{ get; private set; }
    //public float NowHp; // { get; private set; }
    //public float MaxHp; // { get; private set; }
    //public float Shield;

    //public bool IsDead { get; private set; }
    //public int Pos { get; set; }
    //public UnityEvent Die;

    public List<BattleEffect> BattleEffects;
    public List<Attack> Attacks;
    public Attack NowAttack;
    PlayerData PlayerData;
    
    //public List<StatusEffect> StatusEffects;

    GameObject partyHitbox;

    public Character target;

    public Material image;

    //public Monster()
    //{
    //    Name = "default";
    //    MaxHp = 10;
    //    NowHp = MaxHp;
    //    Shield = 0;

    //    IsDead = false;
    //    Pos = 0;

    //    if (Die == null)
    //        Die = new UnityEvent();

    //    BattleEffects = new List<BattleEffect>();
    //    StatusEffects = new List<StatusEffect>();

    //    SetAttacks();
    //    SetUser();

    //    partyHitbox = GameObject.Find("PartyHitBox");
    //}

    public Monster(string name = "default", float maxhp = 100, int pos = 0) : base(name, maxhp, pos)
    {
        //Name = name;
        //MaxHp = 10;
        //NowHp = MaxHp;
        //Shield = 0;

        //IsDead = false;
        //Pos = pos;

        //if (Die == null)
        //    Die = new UnityEvent();
        time = 1;

        BattleEffects = new List<BattleEffect>();
        Attacks = new List<Attack>();

        id = "M_000";
        //StatusEffects = new List<StatusEffect>();

        SetAttacks();
        SetUser();

        //FindAttack();


        partyHitbox = GameObject.Find("PartyHitBox");
    }

    public override void Hited(float value)
    {
        base.Hited(value);

        if (!IsDead)
            FindAttack();
    }

    public void SetImage()
    {
        image = Resources.Load<Material>("Image/Monsters/Materials/" + id);
    }

    

    //public void Hited(float damage)
    //{
    //    float endDamage = damage;

    //    foreach(var effect in StatusEffects)
    //    {
    //        if (effect.StatusEffectType == StatusEffectType.Power)
    //            endDamage = effect.Active(endDamage);
    //    }

    //    NowHp -= endDamage;

    //    if (NowHp <= 0)
    //        die();

    //    Debug.Log("hp : " + NowHp);
    //}

    //public void AddShield(float value)
    //{
    //    Shield += value;
    //}

    //public void Heal(float value)
    //{
    //    NowHp += value;

    //    if (NowHp > MaxHp)
    //        NowHp = MaxHp;

    //    Debug.Log("hp : " + NowHp);
    //}

    //public void die()
    //{
    //    IsDead = true;
    //    Pos = -1;
    //    Die.Invoke();
    //}

    public void Action()
    {
        Debug.Log(Name + Pos + "'s action");
        Debug.Log("hp : " + NowHp);

        foreach(var effect in StatusEffects)
        {
            if(effect.StatusEffectType == StatusEffectType.Stun)
            {
                Debug.Log("this Character is Stun");
                return;
            }
        }

        Attack();
    }

    //  ������ �������� � ������ ���� �����ϴ� �Լ�
    //  �ʿ伺 : UI�� ������ ǥ���ϱ� ���� �̸� ������ �˰� ���� �ʿ䰡 ����
    //  �̷��� ������ �� ���������� Attack�Լ����� ���ุ �ϸ� ��

    /*
      ����Ǵ� ������ : settarget�� ���� Ž�� �� ���� �ϱ� ������ ����� ��� �ٲ� ��
      �ذ�� : State��� �ൿ���� �ٲٰ� State�� ���� ���� ������ ��ġ�Ѵ�.
      �ذ��2 : �ٸ� �������� ��ȯ ���� ���� Ÿ���� ��ġ�Ѵ�.
          ���� : ��ȯ �� ���� Ȯ���ϱ� ���� State�� �ٸ� ��������.
          ���� : State���� �ξ� ���ϰ� ��밡��, ������ ������ �ִ� �Ͱ��� ���ϸ� ��
      ������2 : ���� ����Ž���� �ؾ��ϴ��� �ҹ�����
    */
    virtual public void FindAttack()
    {
        NowAttack = Attacks[0];
        //return Attacks[0];
    }

    virtual public void Attack()
    {
        SetHitbox();

        if(NowAttack.Active())
            BattleEffectSystem.Instance.RequestBattleEffect(NowAttack.BattleEffects);
    }

    public void SetHitbox()
    {
        foreach (var effect in BattleEffects)
            effect.SetHitbox(partyHitbox);

        foreach (var attack in Attacks)
            foreach (var effect in attack.BattleEffects)
                effect.SetHitbox(partyHitbox);
    }

    public void SetTarget(AttackType attackType)
    {
        if (PartySystem.Instance.characters.Count <= 0)
            return;
        switch(attackType)
        {
            case (AttackType.Random):
                target = PartySystem.Instance.GetCRandomTarget();
                break;
            case (AttackType.Self):
                target = this;
                break;
            case (AttackType.Weakest):
                target = PartySystem.Instance.GetWeakestTarget();
                break;
        }
    }

    public void SetHitbox(AttackType type)
    {
        switch(type)
        {
            case (AttackType.Random):
                foreach (var effect in BattleEffects)
                {
                    effect.SetHitbox(partyHitbox);
                    //effect.SetTarget(PartySystem.Instance.GetRandomTarget());
                }
                break;
            case (AttackType.All):
                // attack.all ���� ����� ��η� �Ѵ�.
                // Hitbox���� ��� ����� �����ϵ��� ����
                foreach (var effect in BattleEffects)
                {
                    effect.SetHitbox(partyHitbox);
                }
                break;
            case (AttackType.Self):

                break;
            case (AttackType.Weakest):
                // ���� ����� ���� ü���� ���� ������ �Ѵ�.
                // Hitbox���� ����� �����ϵ��� ����
                foreach (var effect in BattleEffects)
                {
                    effect.SetHitbox(partyHitbox);
                }
                
                break;
            default:
                break;
        }
        
    }

    //public void AddStatusEffect(StatusEffect effect)
    //{
    //    effect = effect.DeepCopy();
    //    StatusEffects.Add(effect);
    //    Debug.Log("add status effect");
    //    BattleField.Instance.EndTurn.AddListener(effect.TurnEnd);

    //    //������ ����� �߰��Ѵ�. �ִ��� ������ Ȯ���� ������ �����Ƿ� �ϴ� ����
    //    BattleField.Instance.EndTurn.RemoveListener(Duration0StatusEffect);
    //    BattleField.Instance.EndTurn.AddListener(Duration0StatusEffect);
    //}

    //public void Duration0StatusEffect()
    //{
    //    for (int i = 0; i < StatusEffects.Count; i++)
    //    {
    //        if (StatusEffects[i].Duration <= 0)
    //        {
    //            BattleField.Instance.EndTurn.RemoveListener(StatusEffects[i].TurnEnd);
    //            StatusEffects.RemoveAt(i);
    //            i--;
    //        }
    //    }
    //}


    //public PartyMember GetThisCharacter()
    //{
    //    return null;
    //}

    //public Monster GetThisMonster()
    //{
    //    return this;
    //}

    //public Character GetCharacter()
    //{
    //    return this;
    //}

    virtual public void SetAttacks()
    {
        //BattleEffects.Add(new AttackEffect("monsterAttack1", 5));
    }

    public void CalcPower()
    {
        foreach (var effect in NowAttack.BattleEffects)
        {
            effect.SetTarget(target);

            if (effect is IValueChanger)
            {
                IValueChanger value = effect as IValueChanger;
                effect.NowPower = value.ChangeValue(DamageCalculator);
                NowAttack.NowPower = effect.NowPower;
            }
        }

        GameObject.Find("BattleCanvas/Attack").GetComponent<AttackUI>().UpdateUI(this);
        //GameObject.Find("BattleCanvas/Attack").GetComponent<AttackUI>().improvedUpdateUI();
    }

    void SetUser()
    {
        foreach (var effect in BattleEffects)
        {
            effect.SetUser(this);
        }

        foreach (var attack in Attacks)
            foreach (var effect in attack.BattleEffects)
                effect.SetUser(this);
    }
}
