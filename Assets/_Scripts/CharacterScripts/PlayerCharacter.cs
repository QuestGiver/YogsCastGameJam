using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class PlayerCharacter : MonoBehaviour, ICharacter, IDamage, IMovement
{
    ////----Movement Variables---------------------------------------------------//
    public float speed;
    public float moveLimit;
    public Vector2 input;
    public Vector2 startingPoint;
    private Vector2 destination;
    private Animator anim;
    private static readonly int IsMoving = Animator.StringToHash("isMoving");    
    ////-------------------------------------------------------------------------//

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
        stats.health = stats.maxhealth;
        stats.movementPoints = stats.MaxMovementPoints;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    public virtual void Attack()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Move()
    {
        if (input != Vector2.zero)
        {
            anim.SetBool(IsMoving, true);
            Vector3 pos = transform.position;
            pos.x += input.x * speed * Time.deltaTime;
            pos.y += input.y * speed * Time.deltaTime;

            // Used for a circular limitation of movement
            if (Vector2.Distance(startingPoint, pos) < moveLimit)
            {
                pos.x = Mathf.Clamp(pos.x, startingPoint.x - moveLimit, startingPoint.x + moveLimit);
                pos.y = Mathf.Clamp(pos.y, startingPoint.y - moveLimit, startingPoint.y + moveLimit);
                destination = pos;

            }

            var dir = pos - transform.position;
            float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg + 180f;
            print(angle);
            var rot = transform.rotation.eulerAngles;
            rot.y = angle;
            transform.rotation = Quaternion.Euler(rot);
            //pos.x = Mathf.Clamp(pos.x,startingPoint.x - moveLimit, startingPoint.x + moveLimit);
            //pos.y = Mathf.Clamp(pos.y,startingPoint.y - moveLimit, startingPoint.y + moveLimit);

            //====Movement Points Expenditure tracking====Basic Implamentation==========\\
            stats.movementPoints -= Vector2.Distance(pos, transform.position);
            //==========================================================================\\

            if (stats.movementPoints >= 0)
            {
                transform.position = pos;
            }
            else
            {
                anim.SetBool(IsMoving, false);
                return;
            }

        }
        else anim.SetBool(IsMoving, false);
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
