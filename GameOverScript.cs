using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public GUISkin Skin;
    public float gapSize = 20f;
    void OnGUI()
    {
        //Set the skin to use
        GUI.skin = Skin;

        //Create a GUI Area to draw the Controls
        GUILayout.BeginArea(new Rect((Screen.height / 2)
        - Screen.height / 4, (Screen.width / 2) - Screen.width / 4,
        Screen.height, Screen.width));
        GUILayout.BeginVertical();
        GUILayout.Label("Game Over");
        GUILayout.Space(gapSize);
        // Make the first button. If it is pressed, reload current level
        if (GUILayout.Button("Retry!"))
        {
            Application.LoadLevel(PlayerPrefs.GetInt(Constants.PREF_CURRENT_LEVEL));
        }

        GUILayout.Space(gapSize);
        // Make the second button. If it is pressed, restart the game
        if (GUILayout.Button("Restart!"))
        {
            Application.LoadLevel(Constants.SCENE_LEVEL_1);
        }
        GUILayout.Space(gapSize);
        // Make the third button. If pressed, game will exit
        if (GUILayout.Button("Quit!"))
        {
            Application.Quit();
        }

        GUILayout.EndVertical();
        GUILayout.EndArea();

    }
}
