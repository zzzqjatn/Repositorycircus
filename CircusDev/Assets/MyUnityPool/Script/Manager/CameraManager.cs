using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private GameObject Player_;
    private void Start()
    {
        Player_ = GFunc.FindRootObjs(GFunc.GAMEOBJ_ROOT_NAME).FindChildObjs(GFunc.PLAYER_OBJ_NAME);
    }

    private void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (Player_ != null || Player_ != default)
        {
            Vector3 desiredPosition = new Vector3(
                Player_.RectTrans().localPosition.x + InputManager.CameraOffset,
                0.0f,
                gameObject.RectTrans().localPosition.z);

            gameObject.RectTranRePos(desiredPosition.x, desiredPosition.y, desiredPosition.z);
        }
    }
}
