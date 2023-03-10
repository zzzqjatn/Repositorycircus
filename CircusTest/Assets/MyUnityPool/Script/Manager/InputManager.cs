using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    public const int SPEED = 150;
    public static int POWER = 8;
    public static bool isJump = false;
    public static int NowDir = 0;
    public static float MapMaxPos = 8000.0f;
    public static bool isMapMove = false;
    public static int LR_KeyInput()
    {
        int KeyX = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            KeyX = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            KeyX = 1;
        }

        NowDir = KeyX;
        return KeyX;
    }

    public static bool Jump_KeyInput()
    {
        bool isRight = false;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isRight = true;
        }

        return isRight;
    }

}
