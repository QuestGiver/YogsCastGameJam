using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class PlayerCharacter : MonoBehaviour, ICharacter, IDamage, IMovement
{

    private CharacterStats stats;

    public CharacterStats Stats
    {
        get {return stats;    
        }
        set { stats = value;
        }
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
        CombatTracker.AllPlayerCharacters.Add(this);
    }
}
