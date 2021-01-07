using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleWave : MonoBehaviour
{
    [SerializeField] List<Transform> Waypoints;
    [SerializeField] float moveSpeed = 3f;
    int waypointIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;

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

            var movementThisFrame = moveSpeed * Time.deltaTime;
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

}
