using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D player_BoxCollider2D;
    private Rigidbody2D player_Rigid2D;
    private Animator player_ani;
    private int POWER = 12;
    void Start()
    {
        player_BoxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        player_Rigid2D = gameObject.GetComponent<Rigidbody2D>();
        player_ani = gameObject.GetComponent<Animator>();

        player_Rigid2D.velocity = Vector3.zero;
        player_BoxCollider2D.offset = new Vector2(0, -25);
        player_BoxCollider2D.size = new Vector2(40, 120);
    }
    void Update()
    {
        if (InputManager.Jump_KeyInput() == true && InputManager.isJump == false)
        {
            Player_Jump();
        }
        else if (InputManager.isJump == false)
        {
            Player_Move();
        }
    }

    public void Player_Move()
    {
        if (InputManager.isJump == false)
        {
            // if ((MoveConnectManager.GetMapcount() == 0 && gameObject.RectTrans().localPosition.x < -445.0f)
            //     || (MoveConnectManager.GetMapcount() == 5 && gameObject.RectTrans().localPosition.x > -460.0f)
            // )
            // {
            //     float movePoint = InputManager.LR_KeyInput() * (InputManager.SPEED * Time.deltaTime);
            //     gameObject.RectTranPosMove(movePoint, 0f, 0f);
            //     MoveConnectManager.isMapMove = true;
            // }

            float movePoint = InputManager.LR_KeyInput() * (InputManager.SPEED * Time.deltaTime);
            gameObject.RectTranPosMove(movePoint, 0f, 0f);
            MoveConnectManager.isMapMove = true;

            // // 0 번째 맵에서의 움직임제한
            // if (MoveConnectManager.GetMapcount() == 0 && gameObject.RectTrans().localPosition.x > -445.0f)
            // {
            //     gameObject.RectTranRePos(-445.5f, gameObject.RectTrans().localPosition.y, 0.0f);
            //     MoveConnectManager.isMapMove = true;
            // }
            // else if (MoveConnectManager.GetMapcount() == 0 && gameObject.RectTrans().localPosition.x < -580.0f)
            // {
            //     if (MoveConnectManager.isMapMove == false)
            //     {
            //         gameObject.RectTranRePos(-580.5f, gameObject.RectTrans().localPosition.y, 0.0f);
            //     }
            // }
            // else if (MoveConnectManager.GetMapcount() == 0 && gameObject.RectTrans().localPosition.x > -446.0f)
            // {
            //     MoveConnectManager.isMapMove = false;
            // }

            // // 마지막 맵에서의 움직임제한
            // if (MoveConnectManager.GetMapcount() == 5 && gameObject.RectTrans().localPosition.x < -460.0f)
            // {
            //     gameObject.RectTranRePos(-455.0f, gameObject.RectTrans().localPosition.y, 0.0f);
            // }
        }
    }
    public void Player_Jump()
    {
        InputManager.isJump = true;
        player_Rigid2D.AddForce(new Vector2(InputManager.LR_KeyInput() * (POWER / 4), POWER), ForceMode2D.Impulse);
        player_ani.SetBool("JumpTime", true);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("BackGround_Sample(Clone)"))
        {
            InputManager.isJump = false;
            player_Rigid2D.velocity = Vector3.zero;
            player_ani.SetBool("JumpTime", false);
        }
    }

    public void Player_Die()
    {

    }
}
