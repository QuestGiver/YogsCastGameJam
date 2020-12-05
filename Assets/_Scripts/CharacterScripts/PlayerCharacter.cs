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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }

    public void Special()
    {
        throw new System.NotImplementedException();
    }

    public void OnRecieveDamage()
    {
        throw new System.NotImplementedException();
    }

    public void Onkill()
    {
        throw new System.NotImplementedException();
    }

    public void OnSendDamage()
    {
        throw new System.NotImplementedException();
    }

    public void CanTraverse()
    {
        RaycastHit characterRayHit;
        RaycastHit mouseRayHit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out mouseRayHit))
        {

        }
        //if(Physics2D.Raycast(gameObject.transform.position, ))

        throw new System.NotImplementedException();
    }
}
