using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyCharacter : MonoBehaviour, ICharacter, IDamage, IMovement, IEnemyAI
{
    private CharacterStats stats;
    private EnemyAiMemory aiMemory;
    public ICharacter player;

    public CharacterStats Stats
    {
        get
        {
            return stats;
        }
        set
        {
            stats = value;
        }
    }

    public EnemyAiMemory AiMemory
    { 
        get => aiMemory; 
        set => aiMemory = value;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }


    public virtual void Attack()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Move()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Special()
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnRecieveDamage()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Onkill()
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnSendDamage()
    {
        throw new System.NotImplementedException();
    }

    public virtual void SumbitInitiative()
    {
        CombatTracker.AllEnemyCharacters.Add(this);
    }

    public virtual void DetermineBestTarget()
    {
        throw new System.NotImplementedException();
    }

    public virtual void EvaluateAIMode()
    {
        throw new System.NotImplementedException();
    }
}
