using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{
    public int sceneToLoad;
    public float delay = 1;

    private float timeElapsed;
    private bool isTriggered;

    void Update()
    {
        if (isTriggered == true)
        {
            timeElapsed = timeElapsed + Time.deltaTime;
        }   

        if (timeElapsed >= delay)
        {
            Application.LoadLevel(sceneToLoad);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            timeElapsed = 0;
            isTriggered = true;

            collider.GetComponent<PlayerController>().enabled = false;
            collider.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            collider.GetComponent<Animator>().SetFloat(Constants.animSpeed, 0);

            PlayerPrefs.SetInt(Constants.PREF_COINS, collider.GetComponent<PlayerStats>().coinsCollected);
        }
    }
}
