using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Global character functions native to all character based classes
/// </summary>
public interface ICharacter
{
    void SumbitInitiative();
    void Move();
    void Attack();
    void Special();
}

public struct CharacterStats
{
    public float MaxMovementPoints;
    public float MovementPoints;
    public int PowerPoints;
    public int Maxhealth;
    public int Health;
    public int AtkPower;
    public int SpcPower;
    public int DefPower;

    public CharacterStats(float maxMovementPoints, float movementPoints, int powerPoints, int maxhealth, int health, int atkPower, int spcPower, int defPower)
    {
        MaxMovementPoints = maxMovementPoints;
        MovementPoints = movementPoints;
        PowerPoints = powerPoints;
        Maxhealth = maxhealth;
        Health = health;
        AtkPower = atkPower;
        SpcPower = spcPower;
        DefPower = defPower;
    }
}

public struct CharacterDependencies
{
    public ParticleSystem AttackEffect;

    public CharacterDependencies(ParticleSystem attackEffect)
    {
        AttackEffect = attackEffect;
    }
}

public enum PCArchetype
{
    WIZARD, WARRIOR, RANGER
}