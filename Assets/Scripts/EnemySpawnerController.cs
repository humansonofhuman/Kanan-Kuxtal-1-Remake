using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum WaveDirections
{
    North = 8,
    East = 4,
    South = 2,
    West = 1,
}

public static class WaveDirectionsExtensions
{
    public static bool Has(this WaveDirections current, WaveDirections target)
    {
        return (current & target) == target;
    }
}

public class EnemySpawnerController : MonoBehaviour
{
    //////////////
    [SerializeField] List<GameObject> northSpanwers;
    [SerializeField] List<GameObject> eastSpanwers;
    [SerializeField] List<GameObject> southSpanwers;
    [SerializeField] List<GameObject> westSpanwers;
    //////////////
    [SerializeField] List<GameObject> enemiesToSpawn;
    [SerializeField] Transform tree;
    public float timeBetweenWaves;
    int currentWave = 1;
    int lastWave = 15;

    private void Start()
    {
        StartCoroutine(StartWaveRoutine());
    }

    IEnumerator StartWaveRoutine()
    {
        while(currentWave <= lastWave)
        {
            Debug.Log($"Starting wave {currentWave}");
            StartWave();
            yield return new WaitForSeconds(timeBetweenWaves);
            currentWave++;
        }
    }

    public void StartWave()
    {
        WaveDirections waveDirections = GetWaveDirections();
        int amountOfDirections = SparseBitcount((int)waveDirections);
        int enemiesPerSpawner = currentWave;

        if (waveDirections.Has(WaveDirections.North))
        {
            Debug.Log("Spawning enemies in the NORTH");
            StartSpawnEnemies(northSpanwers, enemiesPerSpawner);
        }

        if (waveDirections.Has(WaveDirections.East))
        {
            Debug.Log("Spawning enemies in the EAST");
            StartSpawnEnemies(eastSpanwers, enemiesPerSpawner);
        }

        if (waveDirections.Has(WaveDirections.South))
        {
            Debug.Log("Spawning enemies in the SOUTH");
            StartSpawnEnemies(southSpanwers, enemiesPerSpawner);
        }

        if (waveDirections.Has(WaveDirections.West))
        {
            Debug.Log("Spawning enemies in the WEST");
            StartSpawnEnemies(westSpanwers, enemiesPerSpawner);
        }

    }

    void StartSpawnEnemies(List<GameObject> enemySpawners, int amount)
    {
        StartCoroutine(SpawnEnemies(enemySpawners, amount));
    }

    IEnumerator SpawnEnemies(List<GameObject> enemySpawners, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            enemySpawners.ForEach(es => SpawnEnemies(es));
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemies(GameObject enemySpawner)
    {
        GameObject enemy = Instantiate(enemiesToSpawn[0], enemySpawner.transform);
        ChaseTarget chaseTarget = enemy.GetComponent<ChaseTarget>();
        chaseTarget.Target = tree;
    }

    // To know in how many areas are going to spawn enemies
    private int SparseBitcount(int n)
    {
        int count = 0;
        while (n != 0)
        {
            count++;
            n &= (n - 1);
        }
        return count;
    }

    private WaveDirections GetWaveDirections()
    {
        switch (currentWave)
        {
            case 1:
                return WaveDirections.North;
            case 2:
                return WaveDirections.East;
            case 3:
                return WaveDirections.South;
            case 4:
                return WaveDirections.West;
            // -----------------------------------
            case 5:
                return WaveDirections.North
                | WaveDirections.East;
            case 6:
                return WaveDirections.East
                | WaveDirections.South;
            case 7:
                return WaveDirections.South
                | WaveDirections.West;
            case 8:
                return WaveDirections.West
                | WaveDirections.North;
            case 9:
                return WaveDirections.North
                | WaveDirections.South;
            case 10:
                return WaveDirections.East
                | WaveDirections.West;
            // -----------------------------------
            case 11:
                return WaveDirections.North
                | WaveDirections.East
                | WaveDirections.South;
            case 12:
                return WaveDirections.East
                | WaveDirections.South
                | WaveDirections.West;
            case 13:
                return WaveDirections.South
                | WaveDirections.West
                | WaveDirections.North;
            case 14:
                return WaveDirections.West
                | WaveDirections.North
                | WaveDirections.East;
            // -----------------------------------
            case 15:
                return WaveDirections.North
                | WaveDirections.East
                | WaveDirections.South
                | WaveDirections.West;
            default:
                return default;
        }
    }

}
