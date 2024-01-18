using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Constants : MonoBehaviour
{
    public const string PREF_COINS = "Coins";
    public const string PREF_CURRENT_LEVEL = "CurrentLevel";

    public const int SCENE_SPLASH_SCREEN = 0;
    public const int SCENE_TITLE_SCREEN = 1;
    public const int SCENE_LEVEL_1 = 2;
    public const int SCENE_GAME_WIN = 3;
    public const int SCENE_GAME_OVER = 4;

    public const float playerMaxSpeed = 7;
    public const float playerJumpForce = 400;
    public const float playerGroundCheckRadius = 0.2f;

    public const string animSpeed = "Speed";
    public const string animJump = "Jump";
    public const string animDie = "Die";
    public const string animDamage = "Damage";

    public const string inputMove = "Horizontal";
    public const string inputJump = "Jump";
    //public const string inputClimb = "Vertical";

}
