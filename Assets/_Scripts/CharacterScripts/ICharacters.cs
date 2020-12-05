using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Global character functions native to all character based classes
/// </summary>
public interface ICharacter
{
    void Move();
    void Attack();
    void Special();
}

public struct CharacterStats
{
    public float movementPoints;
    public int powerPoints;
    public int maxhealth;
    public int health;
}