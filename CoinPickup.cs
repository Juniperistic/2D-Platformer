using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            PlayerStats stats =
                collider.gameObject.GetComponent<PlayerStats>();
            stats.CollectCoin(coinValue);

            AudioSource.PlayClipAtPoint
            (GetComponent<AudioSource>().clip, transform.position);

            Destroy(gameObject);
        }
    }
}
