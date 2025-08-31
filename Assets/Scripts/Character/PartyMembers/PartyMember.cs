using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.Events;

[Serializable]
public class PartyMember : Character
{
    //public string Name; //{ get; private set; }
    //public float NowHp;
    //public float MaxHp { get; private set; }
    //public float Shield;
    //public bool IsDead { get; private set; }
    //public int Pos;
    //// 죽었을 때
    //public UnityEvent Die;
    // 무언가의 변동사항이 일어났을 때, UI업데이트 용
    public UnityEvent Change;

    public List<Card> cards { get; set; }

    public int draw;
    public int mana;

    public Sprite image;
    public Sprite ldImage;

    //public List<StatusEffect> StatusEffects;


    public PartyMember(string name = "default",float maxhp = 100, int pos = 0) : base(name, maxhp, pos)
    {
        //Name = name;
        //MaxHp = 100;
        //NowHp = MaxHp;
        //Shield = 0;
        //IsDead = false;
        //Pos = pos;

        draw = 0;
        mana = 0;
        id = "P_000";

        //if (Die == null)
        //    Die = new UnityEvent();
        if (Change == null)
            Change = new UnityEvent();


        if (cards == null)
            cards = new List<Card>();


        SetImage();
        //StatusEffects = new List<StatusEffect>();

        //cards.Add(new Test1Card("1"));
        //cards.Add(new Test1Card("2"));
        //cards.Add(new KnockBackCard("3"));
        //cards.Add(new Test2Card("4"));
    }

    //public void Hited(float damage)
    //{
    //    NowHp -= damage;

    //    Change.Invoke();

    //    if (NowHp <= 0)
    //        die();

    //    //Debug.Log("hp : " + NowHp);
    //}

    //void die()
    //{
    //    IsDead = true;
    //    Change.Invoke();
    //    Die.Invoke();
    //}

    public void SetImage()
    {
        image = Resources.Load<Sprite>("Image/Characters/Tears/" + id);
        ldImage = Resources.Load<Sprite>("Image/Characters/" + id);
    }

    public void AddCard(Card card)
    {
        cards.Add(card);

        Change.Invoke();
    }

    public void SetPos(int pos)
    {
        Pos = pos;

        //  카드들의 값도 갱신해줘야함
        foreach (var card in cards)
            foreach (var effect in card.CardEffects)
                effect.SetUser(this);


        Change.Invoke();
    }

    public void ResetCards()
    {
        for (int i = 0; i < cards.Count; i++)
            cards.RemoveAt(0);
    }

    //public void AddShield(float num)
    //{
    //    Shield += num;
    //}

    //public void AddStatusEffect(StatusEffect effect)
    //{
    //    effect = effect.DeepCopy();
    //    Debug.Log("effect : " + effect.BattleEffectName + effect.power);
    //    StatusEffects.Add(effect);
    //    foreach(var statusEffect in StatusEffects)
    //    {
    //        Debug.Log("statusEffect : " + statusEffect.StatusEffectType);
    //    }
    //    GameLoopSystem.Instance.EndUserTurn.AddListener(effect.TurnEnd);

    //    //있으면 지우고 추가한다. 있는지 없는지 확인할 수단이 없으므로 일단 지움
    //    GameLoopSystem.Instance.EndUserTurn.RemoveListener(Duration0StatusEffect);
    //    GameLoopSystem.Instance.EndUserTurn.AddListener(Duration0StatusEffect);

    //    Debug.Log("add status effect");
    //}

    //public void Duration0StatusEffect()
    //{
    //    for (int i = 0; i < StatusEffects.Count; i++)
    //    {
    //        if (StatusEffects[i].Duration <= 0)
    //        {
    //            GameLoopSystem.Instance.EndUserTurn.RemoveListener(StatusEffects[i].TurnEnd);
    //            StatusEffects.RemoveAt(i);
    //            i--;
    //        }
    //    }
    //}

    //public void Heal(float value)
    //{
    //    NowHp += value;

    //    if (NowHp > MaxHp)
    //        NowHp = MaxHp;

    //    Debug.Log("hp : " + NowHp);
    //}

    //public PartyMember GetThisCharacter()
    //{
    //    return this;
    //}

    //public Monster GetThisMonster()
    //{
    //    return null;
    //}

    public void SetMaxHp(float value)
    {
        MaxHp = value;
        if (NowHp > MaxHp)
            NowHp = MaxHp;
    }

    public override void Died()
    {
        base.Died();
        BattleField.Instance.FindAttack();
        //PartySystem.Instance.RemoveMember(this);
    }

    public override Character DeepCopy()
    {
        PartyMember copy = new PartyMember();

        copy.NowHp = this.NowHp;
        copy.Name = Name + "_copy";
        copy.id = "P_000";
        copy.Pos = Pos;
        copy.time = time;
        copy.MaxHp = MaxHp;
        copy.NowHp = NowHp;
        copy.IsDead = IsDead;

        copy.Die = Die;
        copy.StatusEffects = StatusEffects;
        copy.DamageCalculator = DamageCalculator;
        copy.attackValue = attackValue;
        copy.defenseValue = defenseValue;

        copy.scale = scale;
        

        copy.draw = draw;
        copy.mana = mana;
        copy.image = image;

        copy.Change = Change;
        copy.cards = cards;

        return copy;
    }
}
