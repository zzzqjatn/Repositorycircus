using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    public GameObject BackGroundPrefabs;
    private const int BACKGROUND_COUNT = 3;
    private List<GameObject> BackGroundObjsPool;

    //전체 Map 세팅
    private const int AllMapCount = 10;
    private int NowMap;
    void Start()
    {
        BackGroundObjsPool = new List<GameObject>();

        float sizeX = BackGroundPrefabs.RectTrans().sizeDelta.x;
        float StartPos = 0.0f - sizeX * 1.3f;
        for (int i = 0; i < BACKGROUND_COUNT; i++)
        {
            GameObject preFabtemp = Instantiate(BackGroundPrefabs);
            preFabtemp.transform.SetParent(gameObject.transform);
            preFabtemp.RectTrans().localPosition = new Vector3(StartPos, 0f, 0f);
            preFabtemp.RectTrans().localScale = new Vector3(1f, 1f, 1f);
            BackGroundObjsPool.Add(preFabtemp);

            StartPos += sizeX;
        }

        NowMap = 0;
        Debug.Log("현재 맵 : " + NowMap);
    }

    void Update()
    {
        MapMove();
        Reposition();
    }

    public void MapCountCon()
    {
        if (NowMap != AllMapCount)
        {
            NowMap += 1;
            Debug.Log("현재 맵 : " + NowMap);
        }
        else if (NowMap != 0)
        {
            NowMap -= 1;
            Debug.Log("현재 맵 : " + NowMap);
        }
    }

    public void MapMove()
    {
        if (InputManager.isJump == false && InputManager.isMapMove == true)
        {
            float movePoint = InputManager.LR_KeyInput() * (-1) * (InputManager.SPEED * Time.deltaTime);
            for (int i = 0; i < BackGroundObjsPool.Count; i++)
            {
                BackGroundObjsPool[i].RectTranPosMove(movePoint, 0f, 0f);
            }
        }
        else if (InputManager.isJump == true)
        {
            float movePoint = InputManager.NowDir * (-1) * (InputManager.SPEED * Time.deltaTime);
            for (int i = 0; i < BackGroundObjsPool.Count; i++)
            {
                BackGroundObjsPool[i].RectTranPosMove(movePoint, 0f, 0f);
            }
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
}
