using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Car : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 5f;
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] AudioClip healthDecreaseaudio;
    [SerializeField] [Range(0, 1)] float healtDecAudioVol = 0.55f;


    [SerializeField] int health = 50;
    [SerializeField] int CarScore = 0;

    [SerializeField] GameObject PlayerPrefs;

    [SerializeField] AudioClip GameOverSound;
    [SerializeField] [Range(0, 1)] float GameOverSoundVol = 0.5f;



    public string Horizontal { get; private set; }
    public string Vertical { get; private set; }

    public int GetScore()
    {
        return CarScore;
    }

    public void AddToScore(int scoreValue)
    {
        CarScore += scoreValue;
    }

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
            ScoreWin();
            ScoreandHelth();
    }

    void Movement()
    {
        var deltaX = Input.GetAxis(Horizontal) * Time.deltaTime * MoveSpeed;
        var newXPos = transform.position.x + deltaX;
        var deltaY = Input.GetAxis(Vertical) * Time.deltaTime * MoveSpeed;
        var newYPos = transform.position.y + deltaY;


        transform.position = new Vector2(newXPos, newYPos);

    }

         void ScoreandHelth()
        {
            if (health <= 0) 
            {
                Destroy(PlayerPrefs);
                AudioSource.PlayClipAtPoint(GameOverSound, Camera.main.transform.position, GameOverSoundVol);
                SceneManager.LoadScene("GameOver");
                print("Total Points :" + CarScore);

            }else if(CarScore >= 100)
            {
                Destroy(PlayerPrefs);
                AudioSource.PlayClipAtPoint(GameOverSound, Camera.main.transform.position, GameOverSoundVol);
                SceneManager.LoadScene("GameOver");
                print("Total Points :" + CarScore);

            }
        }

        void ScoreWin()
        {
            if (CarScore >= 100)
            {
                Application.Quit();
                SceneManager.LoadScene("Winner");
            }
            
        }
}
}
