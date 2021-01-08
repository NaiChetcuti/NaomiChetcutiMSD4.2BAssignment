using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    //the enemy sprite]
    [SerializeField] GameObject ObstaclePrefab;
    //the path to follow
    [SerializeField] GameObject pathPrefab;
    //time between ennemy spawn
    [SerializeField] float timeBetweenSpawns = 0.5f;
    //random time difference between spawns
    [SerializeField] float spawnRandfactor = 0.3f;
    //number of enemies in wave
    [SerializeField] int numOfObs = 5;
    //enemy movment speed
    [SerializeField] float ObsmoveSpeed = 3f;
    public GameObject GetObstaclePrefab()
    {
        return ObstaclePrefab;
    }

    public List<Transform> GetWaypointsList()
    {
        //eace wage can have different number of waypoints
        var waveWaypoints = new List<Transform>();

        //access the path prefeb, read each waypoints and add it to  ther List waveWaypoints
        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);

            /* waveWayP{oints:
             * 
             * [0]: waypoints 0
             * [1]: waypoints 1
             * [2]: waypoints 2
             * [3]: waypoints 3
             * [4]: waypoints 4
             * 
             */
        }

        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetspawnRandFactor()
    {
        return spawnRandfactor;
    }

    public int GetNumberOfObstacles()
    {
        return numOfObs;
    }

    public float GetObsMoveSpeed()
    {
        return ObsmoveSpeed;
    }
}