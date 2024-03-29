using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GUIGame : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public Sprite heartFull;
    public Sprite heartHalf;
    public Sprite heartEmpty;

    //public GameObject redKey;
    //public GameObject greenKey;
    //public GameObject blueKey;
    //public GameObject yellowKey;

    //public Sprite redKeyFull;
    //public Sprite greenKeyFull;
    //public Sprite blueKeyFull;
    //public Sprite yellowKeyFull;


    public void UpdateHealth(int health)
    {
        switch (health)
        {
            case 0:
                heart1.GetComponent<SpriteRenderer>().sprite = this.heartEmpty;
                heart2.GetComponent<SpriteRenderer>().sprite = this.heartEmpty;
                heart3.GetComponent<SpriteRenderer>().sprite = this.heartEmpty;
                break;
            case 1:
                heart1.GetComponent<SpriteRenderer>().sprite = this.heartHalf;
                heart2.GetComponent<SpriteRenderer>().sprite = this.heartEmpty;
                heart3.GetComponent<SpriteRenderer>().sprite = this.heartEmpty;
                break;
            case 2:
                heart1.GetComponent<SpriteRenderer>().sprite = this.heartFull;
                heart2.GetComponent<SpriteRenderer>().sprite = this.heartEmpty;
                heart3.GetComponent<SpriteRenderer>().sprite = this.heartEmpty;
                break;
            case 3:
                heart1.GetComponent<SpriteRenderer>().sprite = this.heartFull;
                heart2.GetComponent<SpriteRenderer>().sprite = this.heartHalf;
                heart3.GetComponent<SpriteRenderer>().sprite = this.heartEmpty;
                break;
            case 4:
                heart1.GetComponent<SpriteRenderer>().sprite = this.heartFull;
                heart2.GetComponent<SpriteRenderer>().sprite = this.heartFull;
                heart3.GetComponent<SpriteRenderer>().sprite = this.heartEmpty;
                break;
            case 5:
                heart1.GetComponent<SpriteRenderer>().sprite = this.heartFull;
                heart2.GetComponent<SpriteRenderer>().sprite = this.heartFull;
                heart3.GetComponent<SpriteRenderer>().sprite = this.heartHalf;
                break;
            case 6:
                heart1.GetComponent<SpriteRenderer>().sprite = this.heartFull;
                heart2.GetComponent<SpriteRenderer>().sprite = this.heartFull;
                heart3.GetComponent<SpriteRenderer>().sprite = this.heartFull;
                break;
        }
    }
}
