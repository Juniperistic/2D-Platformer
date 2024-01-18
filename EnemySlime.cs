using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemySlime : EnemyController
{
    void FixedUpdate()
    {
        if(isFacingRight)
        {
            //rigidbody2D.velocity = new Vector2(maxSpeed, rigidbody2D.velocity.y);
            GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed * -1, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Wall")
        {
            Flip();
        }
    }
}
