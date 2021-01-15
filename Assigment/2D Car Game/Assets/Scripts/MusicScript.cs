using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public int length { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        SetUpSingleton();

    }

    private void SetUpSingleton()
        {
            if (FindObjectOfType<MusicScript>().length > 1)
            {
                Destroy(gameObject);
            }

            else
            {
                DontDestroyOnLoad(gameObject);
            }



        }
    
}
