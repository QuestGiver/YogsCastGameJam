using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeleton : EnemyCharacter
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Move()
    {
        base.Move();
    }

    public override void OnPathComplete(Path p)
    {
        base.OnPathComplete(p);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override bool Equals(object other)
    {
        return base.Equals(other);
    }

    public override string ToString()
    {
        return base.ToString();
    }

    public override void Attack()
    {
        base.Attack();
    }

    public override void Special()
    {
        base.Special();
    }

    public override void OnRecieveDamage()
    {
        base.OnRecieveDamage();
    }

    public override void Onkill()
    {
        base.Onkill();
    }

    public override void OnSendDamage()
    {
        base.OnSendDamage();
    }

    public override void SumbitInitiative()
    {
        base.SumbitInitiative();
    }

    public override void DetermineBestTarget()
    {
        base.DetermineBestTarget();
    }

    public override void EvaluateAIMode()
    {
        base.EvaluateAIMode();
    }
}
