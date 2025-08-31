using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// юс╫ц
public enum HandSpread
{
    Straight,
    Round
}

public enum SkillType
{
    Active,
    Passive
}

public enum ActiveSlotType
{
    WitchSkill,
    Item
}

public enum AttackType
{
    Single,
    RowR2,
    RowL2,
    RowLine,
    ColB2,
    ColB3,
    ColF2,
    ColF3,
    ColLine,
    FullCross,
    X,
    Random,
    All,
    Self,
    Weakest
}


public enum HealType
{
    Single,
    Mass,
    SinglePercent,
    MassPercent
}

public enum ShieldType
{
    Single,
    Mass
}

public enum KnockbackType
{
    MoveBackward,
    MoveLeft,
    MoveRight,
    MoveForward
}

public enum StatusEffectType
{
    Power,
    Stun,
    Poison
}

public enum AdditionalType
{
    Chain,
    Isolation,
    Cooperation
}

public enum IconType
{
    NormalAttack,
    UnknownAttack,
    PlusAttack,
    MassAttack,
    Buff,
    Debuff,
    Shield,
    Recovery
}

public enum MapType
{
    Battle,
    Camp,
    Event,
    Shop
}

public enum RewardType
{
    Money,
    Item,
}

public enum MapState
{
    Map,
    Battle,
    Event,
    Camp,
    Shop,
    Boss
}
