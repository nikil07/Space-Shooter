using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] bool looping = false;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
           yield return StartCoroutine(spawnAllWaves());
        } while (looping);
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
