using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public interface IEnemyAI
{
    void DetermineBestTarget();
    void EvaluateAIMode();
    void OnPathComplete(Path p);
}

public enum Factions
{
    RED, BLUE, GREEN
}

public enum AIMode
{
    ATTACK, RETREAT
}

public struct EnemyAiMemory
{
    public Factions membership;
    public AIMode behaviorMode;
    public PlayerCharacter targetedPC;
    public EnemyCharacter targetedEC;
}
