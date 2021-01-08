using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleWave : MonoBehaviour
{
    [SerializeField] List<Transform> Waypoints;
    [SerializeField] float ObsmoveSpeed = 3f;
    int waypointIndex = 0;
    [SerializeField] GameObject pathPrefab;
    
    [SerializeField] int numOfObs = 5;

    [SerializeField] float timeBetweenSpawns = 1.3f;
    [SerializeField] float spawnRandFactor = 0.4f;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float health = 50;

    [SerializeField] WaveConfig waveConfig;






    // Start is called before the first frame update
    void Start()
    {
        Waypoints = waveConfig.GetWaypointsList();
        transform.position = Waypoints[waypointIndex].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ObstacleMove()
    {
        if (waypointIndex <= Waypoints.Count - 1)
        {
            var targetPosition = Waypoints[waypointIndex].transform.position;

            targetPosition.z = 0f;

            var ObsmoveSpeed = waveConfig.GetObsMoveSpeed() * Time.deltaTime;

            var movementThisFrame = ObsmoveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public GameObject getobstaclePrefab()
    {
        return obstaclePrefab;
    }


    public void SetWaveConfig(WaveConfig waveConfigToSet)
    {
        waveConfig = waveConfigToSet;
    }


    public void OnTriggerEnter2D(Collider2D other) { 
    DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
    health -= damageDealer.GetDamageForWaves();
    }
}


