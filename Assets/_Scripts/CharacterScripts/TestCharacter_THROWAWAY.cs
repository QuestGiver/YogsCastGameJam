using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCharacter_THROWAWAY : MonoBehaviour
{
    public float speed;
    public float moveLimit;
    public Vector2 input;
    public Vector2 startingPoint;
    private Vector2 destination;
    private Animator anim;
    private static readonly int IsMoving = Animator.StringToHash("isMoving");

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (input != Vector2.zero)
        {
            anim.SetBool(IsMoving,true);
            Vector3 pos = transform.position;
            pos.x += input.x * speed * Time.deltaTime;
            pos.y += input.y * speed * Time.deltaTime;

            // Used for a circular limitation of movement
            if (Vector2.Distance(startingPoint, pos) < moveLimit)
            {
                pos.x = Mathf.Clamp(pos.x,startingPoint.x - moveLimit, startingPoint.x + moveLimit);
                pos.y = Mathf.Clamp(pos.y,startingPoint.y - moveLimit, startingPoint.y + moveLimit);
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
            transform.position = pos;
        }
        else anim.SetBool(IsMoving,false);
        
    }
    
}
