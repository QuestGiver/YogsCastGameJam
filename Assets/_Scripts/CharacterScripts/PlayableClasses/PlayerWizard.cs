using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWizard : PlayerCharacter
{
    public PlayerWizard(CharacterDependencies _dependencies, CharacterStats _stats)
    {
        Stats = _stats;
        Dependencies = _dependencies;
    }

    public override void Attack()
    {
        base.Attack();
    }

    public override void Move()
    {
        base.Move();
    }

    public override void Onkill()
    {
        base.Onkill();
    }

    public override void OnRecieveDamage()
    {
        base.OnRecieveDamage();
    }

    public override void OnSendDamage()
    {
        base.OnSendDamage();
    }

    public override void Special()
    {
        base.Special();
    }

    public override void SumbitInitiative()
    {
        base.SumbitInitiative();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
}
