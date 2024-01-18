using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightPoints : MonoBehaviour
{
    public GameObject waypointA;
    public GameObject waypointB;
    public float speed = 1;

    public bool shouldChangeFacing = false;
    public bool isPlatform = false;

    private bool directionAB = false;

    void FixedUpdate()
    {
        if(transform.position == waypointA.transform.position && !directionAB || 
            transform.position == waypointB.transform.position &&
            directionAB)
        {
            directionAB = !directionAB;
            if(shouldChangeFacing)
            {
                gameObject.GetComponent<EnemyController>().Flip();
            }
        }


        if(directionAB)
        {
            transform.position =
                Vector3.MoveTowards(transform.position,
                waypointB.transform.position, speed * Time.fixedDeltaTime);
        }
        else
        {
            transform.position =
                Vector3.MoveTowards(transform.position,
                waypointA.transform.position, speed * Time.fixedDeltaTime);
        }
    }
}
