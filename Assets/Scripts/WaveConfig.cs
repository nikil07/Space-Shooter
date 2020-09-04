using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Enemy Wave config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefad;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandom = 0.3f;
    [SerializeField] int numberOfEnemies = 8;
    [SerializeField] float moveSpeed = 2f;

    public GameObject getEnemyPrefab() {
        return enemyPrefab;
    }

    public List<Transform> getWaypoints() {

        var waveWayPoints = new List<Transform>();
        foreach (Transform waypoint in pathPrefad.transform) {
            waveWayPoints.Add(waypoint);
        }
        return waveWayPoints;
    }

    public float getTimeBetweenSpawns() {
        return timeBetweenSpawns;
    }

    public float getSpawnRandom()
    {
        return spawnRandom;
    }

    public float getNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    public float getMoveSpeed()
    {
        return moveSpeed;
    }
}
