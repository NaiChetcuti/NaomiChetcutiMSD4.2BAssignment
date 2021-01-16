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

    [SerializeField] GameObject BulletPrefab;
    [SerializeField] float BulletSpeed = 0.2f;

    [SerializeField] WaveConfig waveConfig;
    [SerializeField] DamageDealer dmg;

    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;

    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration;

    [SerializeField] AudioClip ObstacleDeathSound;
    [SerializeField] [Range(0, 1)] float ObstacleDeathSoundVolume = 0.75f;


    [SerializeField] float CarScore = 0;









    // Start is called before the first frame update
    void Start()
    {
        Waypoints = waveConfig.GetWaypointsList();
        transform.position = Waypoints[waypointIndex].transform.position;

        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);

    }

    // Update is called once per frame
    void Update()
    {
        CountingDownAndShoot();
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


    public void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        health -= damageDealer.GetDamageForWaves();

        ProcessHit(dmg);



        if (health <= 0)
        {
            

            GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
            //destroy after 1 sec
            Destroy(explosion, 1f);

            AudioSource.PlayClipAtPoint(ObstacleDeathSound, Camera.main.transform.position, ObstacleDeathSoundVolume);



        }

    }



    private void ProcessHit(DamageDealer dmg)
    {
        health -= dmg.GetDamageForWaves();
       

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    

    private void CountingDownAndShoot()
    {
        //reduce time every frame
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0f)
        {
           
            EnemyFire();
            
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);


        }

    }
    private void EnemyFire()
    {
        GameObject BulletSpeed = Instantiate(BulletPrefab, transform.position, Quaternion.identity) as GameObject;

        BulletSpeed.GetComponent<Rigidbody2D>().velocity = new Vector2(0,2);


    }

}





