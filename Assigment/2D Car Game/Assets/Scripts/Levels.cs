using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Levels : MonoBehaviour
{
    [SerializeField] float delayinSec = 3f;
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayinSec);
        SceneManager.LoadScene("GameOver");

    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);

    }

    public void LoadWinner()
    {
        SceneManager.LoadScene("Winner");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }


    public void QuitingGame()
    {
        print("Quitting the Game");
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
