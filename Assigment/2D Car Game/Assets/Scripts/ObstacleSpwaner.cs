using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpwaner : MonoBehaviour
{
    //a list of Wave
    [SerializeField] List<WaveConfig> waveConfigsList;

    [SerializeField] bool looping = false;


    //start from 0
    int startingWave = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        //when corutine SpawnAllWaves finisghes, check ig looping == true
        while (looping); //while (looping == true)

        StartCoroutine(SpawnAllWaves());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveToSpawn)
    {
        for (int enemyCount = 1; enemyCount <= waveToSpawn.GetNumberOfObstacles(); enemyCount++)
        {
            var newEnemy = Instantiate(
                            waveToSpawn.GetObstaclePrefab(),
                            waveToSpawn.GetWaypointsList()[0].transform.position,
                            Quaternion.identity) as GameObject;

            newEnemy.GetComponent<ObstacleWave>().SetWaveConfig(waveToSpawn);

            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());

        }
    }

    private IEnumerator SpawnAllWaves()
    {
     
        foreach (WaveConfig currentWave in waveConfigsList)
        {
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }
}
