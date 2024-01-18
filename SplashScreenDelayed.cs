using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenDelayed : MonoBehaviour
{
    public float delayTime;
    
    void Start()
    {
        StartCoroutine("Delay");
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(Constants.SCENE_TITLE_SCREEN);
        //Debug.Log("Time's Up!");
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(Constants.SCENE_TITLE_SCREEN);
            //Debug.Log("A key or mouse click has been detected");
        }
    }
}