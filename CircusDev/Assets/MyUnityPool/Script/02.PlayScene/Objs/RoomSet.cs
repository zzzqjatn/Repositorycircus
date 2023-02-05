using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.U2D;

public class RoomSet : MonoBehaviour
{
    public SpriteAtlas spriteAtlas_;
    public int RoomNumber = 0;
    private GameObject MitterObj;

    void Start()
    {
        MitterObj = gameObject.FindChildObjs("Mitter");
        Image temp = MitterObj.GetComponent<Image>();

        temp.sprite = ChangeMitterSprite(RoomNumber);
    }

    void Update()
    {

    }

    private Sprite ChangeMitterSprite(int RoomNum)
    {
        Sprite temp = default;

        switch (RoomNum)
        {
            case 0:
                temp = spriteAtlas_.GetSprite("Mitter_0");
                break;
            case 1:
                temp = spriteAtlas_.GetSprite("Mitter_1");
                break;
            case 2:
                temp = spriteAtlas_.GetSprite("Mitter_2");
                break;
            case 3:
                temp = spriteAtlas_.GetSprite("Mitter_3");
                break;
            case 4:
                temp = spriteAtlas_.GetSprite("Mitter_4");
                break;
            case 5:
                temp = spriteAtlas_.GetSprite("Mitter_5");
                break;
            case 6:
                temp = spriteAtlas_.GetSprite("Mitter_6");
                break;
            case 7:
                temp = spriteAtlas_.GetSprite("Mitter_7");
                break;
            case 8:
                temp = spriteAtlas_.GetSprite("Mitter_8");
                break;
            case 9:
                temp = spriteAtlas_.GetSprite("Mitter_9");
                break;
            case 10:
                temp = spriteAtlas_.GetSprite("Mitter_10");
                break;
        }
        return temp;
    }
}
