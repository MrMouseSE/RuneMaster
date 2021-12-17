using System;
using System.Collections.Generic;
using BattleScripts;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BattleScripts
{
    [CreateAssetMenu(menuName = "Create DemonsSpawnerLevels", fileName = "DemonsSpawnerLevels", order = 20)]
    public class DemonsSpawnerLevels : ScriptableObject
    {
        public List<DemonsLevel> Levels;
    }
}

[Serializable]
public class DemonsLevel
{
    public int Level;
    public float SpawnTime;
    public float CommonDemonsSpawnRate;
    public List<DemonStats> ComonDemons;
    public float UncommonDemonsSpawnRate;
    public List<DemonStats> UncommonDemons;
    public DemonStats BossDemon;

    public DemonStats GetRandomDemon(List<DemonStats> demons)
    {
        return demons[Random.Range(0, demons.Count)];
    }
}