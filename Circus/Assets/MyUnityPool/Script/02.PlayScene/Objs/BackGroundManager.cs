using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    public GameObject BackGroundPrefabs;
    private const int BACKGROUND_COUNT = 3;

    private float MAP_WIDTH;
    private List<GameObject> BackGroundObjsPool;

    void Start()
    {
        BackGroundObjsPool = new List<GameObject>();

        float sizeX = BackGroundPrefabs.RectTrans().sizeDelta.x;
        float StartPos = 0.0f - sizeX * 0.25f;
        for (int i = 0; i < BACKGROUND_COUNT; i++)
        {
            GameObject preFabtemp = Instantiate(BackGroundPrefabs);
            preFabtemp.transform.SetParent(gameObject.transform);
            preFabtemp.RectTrans().localPosition = new Vector3(StartPos, 0f, 0f);
            preFabtemp.RectTrans().localScale = new Vector3(1f, 1f, 1f);
            BackGroundObjsPool.Add(preFabtemp);

            StartPos += sizeX;
        }

        //전체 맵 길이
        MAP_WIDTH = sizeX * 10;

        MoveConnectManager.SetMapSize(MAP_WIDTH);
    }

    void Update()
    {
        MapMove();
        Reposition();
    }

    public void MapMove()
    {    
        if (InputManager.isJump == false)
        {
            //플레이어가 일정 범위에 걸쳤을 때
            if (MoveConnectManager.isMapMove == true)
            {
                float movePoint = InputManager.LR_KeyInput() * (-1) * (InputManager.SPEED * Time.deltaTime);
                for (int i = 0; i < BackGroundObjsPool.Count; i++)
                {
                    BackGroundObjsPool[i].RectTranPosMove(movePoint, 0f, 0f);
                }
            }
        }
        else if (InputManager.isJump == true)
        {
            /* 점프 시 플레이어 움직임 따라가기
                만약 맵 끝이 아니라면
                움직임 제한 구역이라면
             */
        }
    }

    public void Reposition()
    {
        if (BackGroundObjsPool[0].RectTrans().localPosition.x < -1100.0f)
        {
            float RePosX = 0.0f;
            GameObject objtemp = BackGroundObjsPool[0];
            RePosX = BackGroundObjsPool[BackGroundObjsPool.Count - 1].RectTrans().localPosition.x
                        + BackGroundPrefabs.RectTrans().sizeDelta.x;
            objtemp.RectTrans().localPosition = new Vector3(RePosX, 0f, 0f);

            BackGroundObjsPool.RemoveAt(0);
            BackGroundObjsPool.Add(objtemp);
        }

        if (BackGroundObjsPool[BackGroundObjsPool.Count - 1].RectTrans().localPosition.x > 1100.0f)
        {
            float RePosX = 0.0f;
            GameObject objtemp = BackGroundObjsPool[BackGroundObjsPool.Count - 1];
            RePosX = BackGroundObjsPool[0].RectTrans().localPosition.x
                        - BackGroundPrefabs.RectTrans().sizeDelta.x;
            objtemp.RectTrans().localPosition = new Vector3(RePosX, 0f, 0f);

            BackGroundObjsPool.RemoveAt(BackGroundObjsPool.Count - 1);
            BackGroundObjsPool.Insert(0, objtemp);
        }
    }


//백업함수 나중에 잘되면 지워도 됨

/*     void Start()
    {
        BackGroundObjsPool = new List<GameObject>();

        //GameObject findtemp = GFunc.FindRootObjs("GameObjs");
        //GameObject preFabTemp = findtemp.FindChildObjs("BackGround_Sample");

        float sizeX = BackGroundPrefabs.RectTrans().sizeDelta.x;
        float StartPos = 0.0f - sizeX / 2;
        for (int i = 0; i < BACKGROUND_COUNT; i++)
        {
            GameObject preFabtemp = Instantiate(BackGroundPrefabs);
            preFabtemp.transform.SetParent(gameObject.transform);
            preFabtemp.RectTrans().localPosition = new Vector3(StartPos, 0f, 0f);
            preFabtemp.RectTrans().localScale = new Vector3(1f, 1f, 1f);
            BackGroundObjsPool.Add(preFabtemp);

            StartPos += sizeX;
        }

        //전체 맵 길이
        MAP_WIDTH = sizeX * 10;

        MoveConnectManager.SetMapSize(MAP_WIDTH);
    } */

/*     public void Reposition3()
    {
        if(MoveConnectManager.isRolling == true)
        {
            
        }

        if (BackGroundObjsPool[0].RectTrans().localPosition.x < -1100.0f)
        {
            float RePosX = 0.0f;
            GameObject objtemp = BackGroundObjsPool[0];
            RePosX = BackGroundObjsPool[BackGroundObjsPool.Count - 1].RectTrans().localPosition.x
                        + BackGroundPrefabs.RectTrans().sizeDelta.x;
            objtemp.RectTrans().localPosition = new Vector3(RePosX, 0f, 0f);

            BackGroundObjsPool.RemoveAt(0);
            BackGroundObjsPool.Add(objtemp);
        }

        if (BackGroundObjsPool[BackGroundObjsPool.Count - 1].RectTrans().localPosition.x > 1100.0f)
        {
            float RePosX = 0.0f;
            GameObject objtemp = BackGroundObjsPool[BackGroundObjsPool.Count - 1];
            RePosX = BackGroundObjsPool[0].RectTrans().localPosition.x
                        - BackGroundPrefabs.RectTrans().sizeDelta.x;
            objtemp.RectTrans().localPosition = new Vector3(RePosX, 0f, 0f);

            BackGroundObjsPool.RemoveAt(BackGroundObjsPool.Count - 1);
            BackGroundObjsPool.Insert(0, objtemp);
        }
    } */

/*  public void Reposition2()
    {
        for (int i = 0; i < BackGroundObjsPool.Count; i++)
        {
            if (BackGroundObjsPool[i].RectTrans().localPosition.x < -1100.0f && MapCount != MAP_END_SIZE)
            {
                MapCount += 1;
                MoveConnectManager.SetMapCount(MapCount);
                NowEndMapNum = i;

                float tempSetX = 0.0f;
                switch (i)
                {
                    case 0:
                        tempSetX = BackGroundObjsPool[2].RectTrans().localPosition.x + BackGroundPrefabs.RectTrans().sizeDelta.x;
                        break;
                    case 1:
                        tempSetX = BackGroundObjsPool[0].RectTrans().localPosition.x + BackGroundPrefabs.RectTrans().sizeDelta.x;
                        break;
                    case 2:
                        tempSetX = BackGroundObjsPool[1].RectTrans().localPosition.x + BackGroundPrefabs.RectTrans().sizeDelta.x;
                        break;
                }
                BackGroundObjsPool[i].RectTrans().localPosition =
                    new Vector3(tempSetX, 0f, 0f);
            }

            if (BackGroundObjsPool[i].RectTrans().localPosition.x > 1100.0f && MapCount != 0)
            {
                MapCount -= 1;
                MoveConnectManager.SetMapCount(MapCount);
                float tempSetX = 0.0f;
                switch (i)
                {
                    case 0:
                        tempSetX = BackGroundObjsPool[1].RectTrans().localPosition.x - BackGroundPrefabs.RectTrans().sizeDelta.x;
                        NowEndMapNum = 2;
                        break;
                    case 1:
                        tempSetX = BackGroundObjsPool[2].RectTrans().localPosition.x - BackGroundPrefabs.RectTrans().sizeDelta.x;
                        NowEndMapNum = 0;
                        break;
                    case 2:
                        tempSetX = BackGroundObjsPool[0].RectTrans().localPosition.x - BackGroundPrefabs.RectTrans().sizeDelta.x;
                        NowEndMapNum = 1;
                        break;
                }
                BackGroundObjsPool[i].RectTrans().localPosition =
                    new Vector3(tempSetX, 0f, 0f);
            }
            else { continue; }
        }
    } */
}
