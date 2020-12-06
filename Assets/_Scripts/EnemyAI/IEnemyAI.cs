using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyAI
{
    void DetermineBestTarget();
    void EvaluateAIMode();
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
