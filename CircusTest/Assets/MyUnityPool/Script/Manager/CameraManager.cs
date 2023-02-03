using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private GameObject Player_;
    private float cameraHalfWidth, cameraHalfHeight;
    private float minX, maxX;
    public float offsetX;
    void Start()
    {
        Player_ = GFunc.FindRootObjs(GFunc.GAMEOBJ_ROOT_NAME).FindChildObjs(GFunc.PLAYER_OBJ_NAME);

        cameraHalfWidth = gameObject.GetComponent<Camera>().aspect * gameObject.GetComponent<Camera>().orthographicSize;
        cameraHalfHeight = gameObject.GetComponent<Camera>().orthographicSize;

        offsetX = 5.0f;
        minX = -4.5f;
        maxX = 8000f;
    }

    // void Update()
    // {
    // Vector3 desiredPosition = new Vector3(
    //     Mathf.Clamp(playerGameobj.RectTrans().localPosition.x, minX + cameraHalfWidth, maxX - cameraHalfWidth),   // X
    //     Mathf.Clamp(playerGameobj.RectTrans().localPosition.y, minY + cameraHalfHeight, maxY - cameraHalfHeight), // Y
    //     -10);                                                                                                  // Z

    //     Vector3 desiredPosition = new Vector3(
    // Mathf.Clamp(playerGameobj.RectTrans().localPosition.x, minX + cameraHalfWidth, maxX - cameraHalfWidth),   // X
    // Mathf.Clamp(playerGameobj.RectTrans().localPosition.y, minY + cameraHalfHeight, maxY - cameraHalfHeight), // Y
    // -10);                                                                                                  // Z
    //     transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 3);
    //transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 3);
    //}

    void FixedUpdate()
    {
        if (Player_ != null || Player_ != default)
        {
            // Vector3 desiredPosition = new Vector3(
            //     Mathf.Clamp(Player_.RectTrans().localPosition.x + offsetX, minX + cameraHalfWidth, maxX - cameraHalfWidth),   // X
            //     0.0f, // Y
            //     -10.0f); // Z

            // Vector3 desiredPosition = new Vector3(
            //     Player_.RectTrans().localPosition.x + offsetX,   // X
            //     0.0f, // Y
            //     -10.0f); // Z

            float PosX = (Player_.RectTrans().localPosition.x * 0.01f);

            Vector3 desiredPosition = new Vector3(
                PosX,   // X
                0.0f, // Y
                -10.0f); // Z
            transform.position = desiredPosition;
        }
    }
}
