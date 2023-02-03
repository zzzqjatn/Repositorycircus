using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    private GameObject BackGroundPrefabs;
    private const int BACKGROUND_COUNT = 3;
    private List<GameObject> BackGroundObjsPool;

    private const int AllMapCount = 10;
    void Start()
    {
        BackGroundObjsPool = new List<GameObject>();

        GameObject root = GFunc.FindRootObjs(GFunc.GAMEOBJ_ROOT_NAME);
        BackGroundPrefabs = root.FindChildObjs("BgObjs").FindChildObjs(GFunc.BACKGROUND_PREFAB_NAME);   //??

        float sizeX = BackGroundPrefabs.RectTrans().sizeDelta.x;
        float StartPos = 0.0f - sizeX * 0.3f;
        for (int i = 0; i < BACKGROUND_COUNT; i++)
        {
            GameObject preFabtemp = Instantiate(BackGroundPrefabs);
            preFabtemp.transform.SetParent(gameObject.transform);
            preFabtemp.name = "BackTemp";
            preFabtemp.RectTrans().localPosition = new Vector3(StartPos, -60f, 0f);
            preFabtemp.RectTrans().localScale = new Vector3(1f, 1f, 1f);
            preFabtemp.FindChildObjs("RoomCheck").GetComponent<RoomSet>().RoomNumber = i;
            BackGroundObjsPool.Add(preFabtemp);

            StartPos += sizeX;
        }
        BackGroundPrefabs.SetActive(false);
    }

    void Update()
    {
        MapMove();
        Reposition();
    }

    public void MapCountCon()
    {

    }

    public void MapMove()
    {
        if (InputManager.isJump == false)
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
            objtemp.RectTrans().localPosition = new Vector3(RePosX, -60f, 0f);
            objtemp.FindChildObjs("RoomCheck").GetComponent<RoomSet>().RoomNumber =
                BackGroundObjsPool[BackGroundObjsPool.Count - 1].FindChildObjs("RoomCheck").GetComponent<RoomSet>().RoomNumber + 1;

            BackGroundObjsPool.RemoveAt(0);
            BackGroundObjsPool.Add(objtemp);
        }
        else if (BackGroundObjsPool[BackGroundObjsPool.Count - 1].RectTrans().localPosition.x > 1100.0f)
        {
            float RePosX = 0.0f;
            GameObject objtemp = BackGroundObjsPool[BackGroundObjsPool.Count - 1];

            RePosX = BackGroundObjsPool[0].RectTrans().localPosition.x
                        - BackGroundPrefabs.RectTrans().sizeDelta.x;
            objtemp.RectTrans().localPosition = new Vector3(RePosX, -60f, 0f);
            objtemp.FindChildObjs("RoomCheck").GetComponent<RoomSet>().RoomNumber =
                BackGroundObjsPool[0].FindChildObjs("RoomCheck").GetComponent<RoomSet>().RoomNumber - 1;

            BackGroundObjsPool.RemoveAt(BackGroundObjsPool.Count - 1);
            BackGroundObjsPool.Insert(0, objtemp);
        }
    }
}
