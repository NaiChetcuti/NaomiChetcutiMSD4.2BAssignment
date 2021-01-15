﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Levels : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);

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
