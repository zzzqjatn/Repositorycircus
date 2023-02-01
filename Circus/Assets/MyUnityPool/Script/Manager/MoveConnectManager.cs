using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MoveConnectManager
{
    public static bool isMapMove = false;

    public static int MapCount_ = 0;

    public static void SetMapCount(int count)
    {
        MapCount_ = count;
    }

    public static int GetMapcount()
    {
        return MapCount_;
    }
}
