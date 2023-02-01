using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MoveConnectManager
{
    public static bool isMapMove = false;
    public static float MapSize = 0.0f;

    //롤링에 대한
    public static int NowPlayerPos = 0;
    
    public static void SetMapSize(float mapSize_)
    {
        MapSize = mapSize_;
    }

    public static float GetMapSize()
    {
        return MapSize;
    }
}
