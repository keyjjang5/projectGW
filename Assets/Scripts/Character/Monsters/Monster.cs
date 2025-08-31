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

    //  누구를 공격할지 어떤 공격을 할지 결정하는 함수
    //  필요성 : UI에 공격을 표시하기 위해 미리 공격을 알고 있을 필요가 있음
    //  이렇게 가지게 된 다음공격을 Attack함수에서 실행만 하면 됨

    /*
      예상되는 문제점 : settarget을 공격 탐색 시 마다 하기 떄문에 대상이 계속 바뀔 것
      해결법 : State기반 행동으로 바꾸고 State가 변할 때만 공격을 서치한다.
      해결법2 : 다른 공격으로 전환 됐을 때만 타겟을 서치한다.
          단점 : 전환 된 것을 확인하기 위해 State와 다름 없어진다.
          장점 : State보다 훨씬 편하게 사용가능, 이전에 가지고 있던 것과만 비교하면 됨
      문제점2 : 언제 공격탐색을 해야하는지 불문명함
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
                // attack.all 공격 대상을 모두로 한다.
                // Hitbox에서 모든 대상을 공격하도록 설정
                foreach (var effect in BattleEffects)
                {
                    effect.SetHitbox(partyHitbox);
                }
                break;
            case (AttackType.Self):

                break;
            case (AttackType.Weakest):
                // 공격 대상을 가장 체력이 낮은 적으로 한다.
                // Hitbox에서 대상을 공격하도록 설정
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

    //    //있으면 지우고 추가한다. 있는지 없는지 확인할 수단이 없으므로 일단 지움
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
