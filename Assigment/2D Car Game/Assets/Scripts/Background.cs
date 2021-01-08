using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    float xMin, xMax, yMin, yMax;

    float padding = 0.5f;

    //the speed of the scrolling
    [SerializeField] float BackgroundScrollSpeed = 0.02f;
    //the material from the texture
    Material material;
    Vector2 offSet;


    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
        //get the material of the background from the Renderer component
        material = GetComponent<Renderer>().material;
        //will scroll in the y-axis at the speed
        offSet = new Vector2(0f, BackgroundScrollSpeed);


    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += offSet * Time.deltaTime;

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
