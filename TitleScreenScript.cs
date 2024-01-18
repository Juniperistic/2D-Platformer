using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TitleScreenScript : MonoBehaviour
{
    public GUISkin Skin;

    void Update()
    {
        if(Input.anyKeyDown)
        {
            Application.LoadLevel(Constants.SCENE_LEVEL_1);
        }
    }

    void OnGUI ()
    {
        //set the skin to use
        GUI.skin = Skin;

        GUILayout.BeginArea(new Rect(300, 480, Screen.width,
        Screen.height));
        GUILayout.BeginVertical();
        GUILayout.Label("Press Any Key To Begin",
        GUILayout.ExpandWidth(true));
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}
