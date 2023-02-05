using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public static partial class GFunc
{
    //! ===== RectTransform =====
    //! Rect 트렌스폼 가져오기
    public static RectTransform RectTrans(this GameObject obj)
    {
        RectTransform Result = default;
        Result = obj.GetComponent<RectTransform>();
        return Result;
    }

    //! Rect 트렌스 계산
    public static void RectTranPosMove(this GameObject obj, float x, float y, float z)
    {
        RectTransform Result = default;
        Result = obj.GetComponent<RectTransform>();
        Result.localPosition = new Vector3(
            Result.localPosition.x + x,
            Result.localPosition.y + y,
            Result.localPosition.z + z);
    }

    //! Rect 트렌스 재설정
    public static void RectTranRePos(this GameObject obj, float x, float y, float z)
    {
        RectTransform Result = default;
        Result = obj.GetComponent<RectTransform>();
        Result.localPosition = new Vector3(x, y, z);
    }

    //! ===== Objs =====
    //! 루프 오브젝트의 자식 오브젝트를 이름으로 찾아오기
    public static GameObject FindChildObjs(this GameObject rootObj, string objName)
    {
        GameObject result = default;
        GameObject target = default;

        for (int i = 0; i < rootObj.transform.childCount; i++)
        {
            target = rootObj.transform.GetChild(i).gameObject;
            if (target.name.Equals(objName))
            {
                result = target;
                return result;
            }
            else 
            {
                target = FindChildObjs(target, objName);
                if (target == null || target == default) { /* Pass */ }
                else if (target.name.Equals(objName))
                {
                    result = target;
                    return result;
                }
            }
        }
        return result;
    }

    //! 씬에 있는 루프 오브젝트를 이름으로 찾아오기
    public static GameObject FindRootObjs(string objName)
    {
        Scene selfScene = ActiveScene();
        GameObject[] roots = selfScene.GetRootGameObjects();

        GameObject target = default;

        foreach (GameObject obj in roots)
        {
            if (obj.name.Equals(objName))
            {
                target = obj;
                return target;
            }
            else { continue; }
        }
        return target;
    }


    //! ===== Application =====
    public static void AppQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static Scene ActiveScene()
    {
        Scene Result = SceneManager.GetActiveScene();
        return Result;
    }
}
