﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public abstract class EnemyCharacter : MonoBehaviour, ICharacter, IDamage, IMovement, IEnemyAI
{
    private CharacterStats stats;
    private EnemyAiMemory aiMemory;
    public ICharacter player;

    //===============A* Variables=================
    public Transform targetPosition;
    private Seeker seeker;
    private CharacterController controller;
    public Path path;
    public float speed = 2;
    public float nextWaypointDistance = 0.25f;
    private int currentWaypoint = 0;
    public bool reachedEndOfPath;
    //============================================

    public CharacterDependencies dependencies;

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
        seeker = GetComponent<Seeker>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (path == null)
        {
            // We have no path to follow yet, so don't do anything
            return;
        }

        // Check in a loop if we are close enough to the current waypoint to switch to the next one.
        // We do this in a loop because many waypoints might be close to each other and we may reach
        // several of them in the same frame.
        reachedEndOfPath = false;
        // The distance to the next waypoint in the path
        float distanceToWaypoint;
        while (true)
        {
            // If you want maximum performance you can check the squared distance instead to get rid of a
            // square root calculation. But that is outside the scope of this tutorial.
            distanceToWaypoint = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
            if (distanceToWaypoint < nextWaypointDistance)
            {
                // Check if there is another waypoint or if we have reached the end of the path
                if (currentWaypoint + 1 < path.vectorPath.Count)
                {
                    currentWaypoint++;
                }
                else
                {
                    // Set a status variable to indicate that the agent has reached the end of the path.
                    // You can use this to trigger some special code if your game requires that.
                    reachedEndOfPath = true;
                    break;
                }
            }
            else
            {
                break;
            }
        }

        // Slow down smoothly upon approaching the end of the path
        // This value will smoothly go from 1 to 0 as the agent approaches the last waypoint in the path.
        var speedFactor = reachedEndOfPath ? Mathf.Sqrt(distanceToWaypoint / nextWaypointDistance) : 1f;

        // Direction to the next waypoint
        // Normalize it so that it has a length of 1 world unit
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        // Multiply the direction by our desired speed to get a velocity
        Vector3 velocity = dir * speed * speedFactor;

        //====Movement Points Expenditure tracking====Basic Implamentation=============================================\\
        stats.MovementPoints -= Vector2.Distance(transform.position, transform.position += velocity * Time.deltaTime);
        //=============================================================================================================\\

        if (stats.MovementPoints > 0)
        {
            transform.position += velocity * Time.deltaTime;
        }
        else
        {
            return;
        }

    }


    public virtual void Attack()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Move()
    {
        seeker.pathCallback(path);
        seeker.StartPath(transform.position, targetPosition.position, OnPathComplete);
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

    public virtual void OnPathComplete(Path p)
    {
        Debug.Log("A path was calculated. Did it fail with an error? " + p.error);

        if (!p.error)
        {
            path = p;
            // Reset the waypoint counter so that we start to move towards the first point in the path
            currentWaypoint = 0;
        }
    }
}
