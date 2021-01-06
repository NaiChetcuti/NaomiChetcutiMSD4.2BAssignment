using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    float xMin, xMax, yMin, yMax;

    float padding = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();

    }

    // Update is called once per frame
    void Update()
    {

    }

    // setting up the boundaries according to the camera
    private void SetUpMoveBoundaries()
    {
        //get the camera from unity
        Camera gameCamera = Camera.main;

        //xMin = 0 xMax = 1
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        //yMin = 0 yMax = 1
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

    }
}
