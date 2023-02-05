using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    private GameObject BackGroundPrefabs;
    private const int BACKGROUND_COUNT = 5;
    private List<GameObject> BackGroundObjsPool;

    private GameObject mainCamera;

    private const int AllMapCount = 10;
    void Start()
    {
        BackGroundObjsPool = new List<GameObject>();
        BackGroundPrefabs = GFunc.FindRootObjs(GFunc.GAMEOBJ_ROOT_NAME).FindChildObjs(GFunc.BACKGROUND_PREFAB_NAME);

        float sizeX = BackGroundPrefabs.RectTrans().sizeDelta.x;
        InputManager.SetMapSizeX(sizeX);
        InputManager.SetMapMaxPos(sizeX * AllMapCount);

        float StartPos = -200.0f + sizeX / 2;
        for (int i = 0; i < BACKGROUND_COUNT; i++)
        {
            GameObject preFabtemp = Instantiate(BackGroundPrefabs);
            preFabtemp.transform.SetParent(gameObject.transform);
            preFabtemp.name = "BackTemp";
            preFabtemp.RectTrans().localPosition = new Vector3(StartPos, -60f, 0f);
            preFabtemp.RectTrans().localScale = new Vector3(1f, 1f, 1f);
            preFabtemp.FindChildObjs(GFunc.SUBBG_OBJ_NAME).GetComponent<RoomSet>().RoomNumber = AllMapCount - i;
            BackGroundObjsPool.Add(preFabtemp);

            StartPos += sizeX;
        }
        BackGroundPrefabs.SetActive(false);

        mainCamera = GFunc.FindRootObjs(GFunc.GAMEOBJ_ROOT_NAME).FindChildObjs(GFunc.CAMERA_OBJ_NAME);
    }

    void Update()
    {
        //Reposition2();
    }

    public void MapCountCon()
    {

    }

    public void Reposition2()
    {
        //앞
        if (mainCamera.RectTrans().localPosition.x - InputManager.CameraOffset >
                (BackGroundObjsPool[0].RectTrans().localPosition.x + InputManager.MapSizeX * 2) - 200.0f)
        {
            if(BackGroundObjsPool[0].FindChildObjs(GFunc.SUBBG_OBJ_NAME).GetComponent<RoomSet>().RoomNumber != 0)
            { 
                float RePosX = 0.0f;
                GameObject objtemp = BackGroundObjsPool[0];
                RePosX = BackGroundObjsPool[BackGroundObjsPool.Count - 1].RectTrans().localPosition.x
                            + BackGroundPrefabs.RectTrans().sizeDelta.x;
                objtemp.RectTrans().localPosition = new Vector3(RePosX, -60f, 0f);
                objtemp.FindChildObjs(GFunc.SUBBG_OBJ_NAME).GetComponent<RoomSet>().RoomNumber =
                    BackGroundObjsPool[BackGroundObjsPool.Count - 1].FindChildObjs(GFunc.SUBBG_OBJ_NAME).GetComponent<RoomSet>().RoomNumber + 1;

                BackGroundObjsPool.RemoveAt(0);
                BackGroundObjsPool.Add(objtemp);
            }
        }
        //뒤
        else if ((mainCamera.RectTrans().localPosition.x + mainCamera.RectTrans().sizeDelta.x + 200.0f) <
                (BackGroundObjsPool[0].RectTrans().localPosition.x + InputManager.MapSizeX * 2))
        {
            if(BackGroundObjsPool[2].FindChildObjs(GFunc.SUBBG_OBJ_NAME).GetComponent<RoomSet>().RoomNumber != AllMapCount)
            {
                float RePosX = 0.0f;
                GameObject objtemp = BackGroundObjsPool[BackGroundObjsPool.Count - 1];

                RePosX = BackGroundObjsPool[0].RectTrans().localPosition.x
                            - BackGroundPrefabs.RectTrans().sizeDelta.x;
                objtemp.RectTrans().localPosition = new Vector3(RePosX, -60f, 0f);
                objtemp.FindChildObjs(GFunc.SUBBG_OBJ_NAME).GetComponent<RoomSet>().RoomNumber =
                    BackGroundObjsPool[0].FindChildObjs(GFunc.SUBBG_OBJ_NAME).GetComponent<RoomSet>().RoomNumber - 1;

                BackGroundObjsPool.RemoveAt(BackGroundObjsPool.Count - 1);
                BackGroundObjsPool.Insert(0, objtemp);
            }
        }
    }

    public void Reposition()
    {
        //앞
        if (mainCamera.RectTrans().localPosition.x + InputManager.CameraOffset <
                BackGroundObjsPool[0].RectTrans().position.x + InputManager.MapSizeX + 10.0f)
        {
            float RePosX = 0.0f;
            GameObject objtemp = BackGroundObjsPool[0];
            RePosX = BackGroundObjsPool[BackGroundObjsPool.Count - 1].RectTrans().localPosition.x
                        + BackGroundPrefabs.RectTrans().sizeDelta.x;
            objtemp.RectTrans().localPosition = new Vector3(RePosX, -60f, 0f);
            objtemp.FindChildObjs(GFunc.SUBBG_OBJ_NAME).GetComponent<RoomSet>().RoomNumber =
                BackGroundObjsPool[BackGroundObjsPool.Count - 1].FindChildObjs(GFunc.SUBBG_OBJ_NAME).GetComponent<RoomSet>().RoomNumber + 1;

            BackGroundObjsPool.RemoveAt(0);
            BackGroundObjsPool.Add(objtemp);
        }
        //뒤
        else if (mainCamera.RectTrans().localPosition.x + InputManager.MapSizeX <
                BackGroundObjsPool[2].RectTrans().position.x + 10.0f)
        {
            float RePosX = 0.0f;
            GameObject objtemp = BackGroundObjsPool[BackGroundObjsPool.Count - 1];

            RePosX = BackGroundObjsPool[0].RectTrans().localPosition.x
                        - BackGroundPrefabs.RectTrans().sizeDelta.x;
            objtemp.RectTrans().localPosition = new Vector3(RePosX, -60f, 0f);
            objtemp.FindChildObjs(GFunc.SUBBG_OBJ_NAME).GetComponent<RoomSet>().RoomNumber =
                BackGroundObjsPool[0].FindChildObjs(GFunc.SUBBG_OBJ_NAME).GetComponent<RoomSet>().RoomNumber - 1;

            BackGroundObjsPool.RemoveAt(BackGroundObjsPool.Count - 1);
            BackGroundObjsPool.Insert(0, objtemp);
        }
    }
}
