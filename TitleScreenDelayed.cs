using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenDelayed : MonoBehaviour
{
    public float delayTime;

    private void start()
    {
        StartCoroutine("Delay");
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(Constants.SCENE_LEVEL_1);
        //Debug.log("Time's Up");
    }

    private void update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(Constants.SCENE_LEVEL_1);
            //Debug.log("A key or mouse click has been detected");
        }
    }
}
