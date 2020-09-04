using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    int startingWaveIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnAllWaves());
    }

    private IEnumerator spawnAllWaves() {
        print(waveConfigs.Count);
        for (int i = 0; i < waveConfigs.Count; i++) {
            var currentWave = waveConfigs[i];
            yield return StartCoroutine(spawnAllEnemiesInWave(currentWave));
        }
    }

    private IEnumerator spawnAllEnemiesInWave(WaveConfig currentWave)
    {

        for (int i = 0; i < currentWave.getNumberOfEnemies(); i++) { 
        var newEnemy = Instantiate(currentWave.getEnemyPrefab(), currentWave.getWaypoints()[0].transform.position, Quaternion.identity);
        newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(currentWave);
        yield return new WaitForSeconds(currentWave.getTimeBetweenSpawns());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
