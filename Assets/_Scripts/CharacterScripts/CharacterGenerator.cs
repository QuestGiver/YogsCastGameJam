using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    /// <summary>
    /// Generates a new player character object with empty movement variables
    /// </summary>
    /// <returns></returns>
    public PlayerWizard GenerateWizard()
    {
        return new PlayerWizard(GenerateDependancies(PCArchetype.WIZARD), StatsGenerator(PCArchetype.WIZARD));
    }

    /// <summary>
    /// Unfinished function that should return the stats needed for a specific character class
    /// </summary>
    /// <returns></returns>
    public CharacterStats StatsGenerator(PCArchetype _characterClass)
    {
        return new CharacterStats(10, 10, 10, 10, 11, 10, 10, 10);
    }

    /// <summary>
    /// Unfinished function that should return the dependancies needed for a specific character class
    /// </summary>
    /// <returns></returns>
    public CharacterDependencies GenerateDependancies(PCArchetype _characterClass)
    {
        return new CharacterDependencies(new ParticleSystem());
    }
}
