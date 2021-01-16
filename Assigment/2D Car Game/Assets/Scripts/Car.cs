using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 5f;
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] AudioClip healthDecreaseaudio;
    [SerializeField] [Range(0, 1)] float healtDecAudioVol = 0.55f;


    [SerializeField] int health = 50;



    public string Horizontal { get; private set; }
    public string Vertical { get; private set; }

    public int GettingHealth()
    {
        return health;
    }

   public void HealthReduce()
    {
         void OnTriggerEnter2D(Collider2D other) 
        {
            DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
            health -= damageDealer.GetDamageForWaves();
            if (health < 50)
            {
                AudioSource.PlayClipAtPoint(healthDecreaseaudio, Camera.main.transform.position, healtDecAudioVol);

            }

        }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Movement()
    {
        var deltaX = Input.GetAxis(Horizontal) * Time.deltaTime * MoveSpeed;
        var newXPos = transform.position.x + deltaX;
        var deltaY = Input.GetAxis(Vertical) * Time.deltaTime * MoveSpeed;
        var newYPos = transform.position.y + deltaY;


        transform.position = new Vector2(newXPos, newYPos);

    }
}
}
