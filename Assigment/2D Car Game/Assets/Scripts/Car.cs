using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 5f;

    public string Horizontal { get; private set; }
    public string Vertical { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Movement()
    {
        var deltaX = Input.GetAxis(Horizontal) * Time.deltaTime * MoveSpeed;
        var newXPos = transform.position.x + deltaX;
        var deltaY = Input.GetAxis(Vertical) * Time.deltaTime * MoveSpeed;
        var newYPos = transform.position.y + deltaY;


        transform.position = new Vector2(newXPos, newYPos);

    }
}
