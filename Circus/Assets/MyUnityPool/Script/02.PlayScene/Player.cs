using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D player_BoxCollider2D;
    private Rigidbody2D player_Rigid2D;
    private Animator player_ani;
    private int POWER = 12;

    public float NowPos = 0.0f;
    void Start()
    {
        player_BoxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        player_Rigid2D = gameObject.GetComponent<Rigidbody2D>();
        player_ani = gameObject.GetComponent<Animator>();

        player_Rigid2D.velocity = Vector3.zero;
        player_BoxCollider2D.offset = new Vector2(0, -25);
        player_BoxCollider2D.size = new Vector2(40, 120);

        NowPos = 0;
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
            float movePoint = InputManager.LR_KeyInput() * (InputManager.SPEED * Time.deltaTime);
            NowPos += movePoint;    //나의 현재 좌표

            if(NowPos < 0) NowPos = 0;
            else if (8000 < NowPos) NowPos = 8000;

            if (135 < NowPos && NowPos < 7000)
            {
                MoveConnectManager.isMapMove = true;
            }
            else
            {
                MoveConnectManager.isMapMove = false;
            }

            if(MoveConnectManager.isMapMove == false)
            {
                if (0 <= NowPos && NowPos <= 8000)
                {
                    gameObject.RectTranPosMove(movePoint, 0f, 0f);
                }

                if(NowPos < 136)
                {
                    //끝지점 예외처리
                    if (gameObject.RectTrans().localPosition.x > -445.0f)
                    {
                        gameObject.RectTranRePos(-445.5f, gameObject.RectTrans().localPosition.y, 0.0f);
                    }
                    else if (gameObject.RectTrans().localPosition.x < -580.0f)
                    {
                        gameObject.RectTranRePos(-580.5f, gameObject.RectTrans().localPosition.y, 0.0f);
                    }
                }
                else if(7200 < NowPos)
                {
                    //끝지점 예외처리
                    if (gameObject.RectTrans().localPosition.x < -443.0f)
                    {
                        gameObject.RectTranRePos(-443.5f, gameObject.RectTrans().localPosition.y, 0.0f);
                    }
                    else if (gameObject.RectTrans().localPosition.x > 578)
                    {
                        gameObject.RectTranRePos(577.5f, gameObject.RectTrans().localPosition.y, 0.0f);
                    }
                }
            }

            if(0 <= NowPos && NowPos <= 1100) {/* PASS */}   // 왼쪽 맨 끝 부분
            else if(6900 <= NowPos && NowPos <= 8000) {/* PASS */} // 오른쪽 맨 끝 부분

            if ((int)NowPos % 800 == 0)  // 800(한장 크기) 와 나눠어 나눠졌을 때
            {
                MoveConnectManager.NowPlayerPos = (int)NowPos;
            }

            // if(0 <= NowPos && NowPos <= 1100) {/* PASS */}   // 왼쪽 맨 끝 부분
            // else if(6900 <= NowPos && NowPos <= 8000) {/* PASS */} // 오른쪽 맨 끝 부분
            // else if((int)NowPos != BeforePos)   //이전 값과 같지 않고
            // {
            //     if((int)NowPos % 1100 == 0)  // 800(한장 크기) 와 나눠어 나눠졌을 때
            //     {
            //         MoveConnectManager.isRolling = true;
            //         MoveConnectManager.NowPlayerPos = (int)NowPos;
            //         if(BeforePos < (int)NowPos)
            //         {
            //             //플레이어 전진 중
            //             MoveConnectManager.RollingPoint = -1;
            //         }
            //         else
            //         {
            //             //플레이어 후진 중
            //             MoveConnectManager.RollingPoint = 1;
            //         }

            //         BeforePos = (int)NowPos;
            //     }
            // }

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

//백업 함수 나중에 지워도 됨
    //     public void Player_Move2()
    // {
    //     if (InputManager.isJump == false)
    //     {
    //         // if ((MoveConnectManager.GetMapcount() == 0 && gameObject.RectTrans().localPosition.x < -445.0f)
    //         //     || (MoveConnectManager.GetMapcount() == 5 && gameObject.RectTrans().localPosition.x > -460.0f)
    //         // )
    //         // {
    //         //     float movePoint = InputManager.LR_KeyInput() * (InputManager.SPEED * Time.deltaTime);
    //         //     gameObject.RectTranPosMove(movePoint, 0f, 0f);
    //         //     MoveConnectManager.isMapMove = true;
    //         // }
    //         float movePoint = InputManager.LR_KeyInput() * (InputManager.SPEED * Time.deltaTime);
    //         gameObject.RectTranPosMove(movePoint, 0f, 0f);
    //         NowPos += movePoint;    //나의 현재 좌표
    //         if(0 <= NowPos && NowPos <= 800) {/* PASS */}   // 왼쪽 맨 끝 부분
    //         else if(7200 <= NowPos && NowPos <= 8000) {/* PASS */} // 오른쪽 맨 끝 부분
    //         else if((int)NowPos != BeforePos)   //이전 값과 같지 않고
    //         {
    //             if((int)NowPos % 800 == 0)  // 800(한장 크기) 와 나눠어 나눠졌을 때
    //             {
    //                 MoveConnectManager.isRolling = true;
    //                 MoveConnectManager.NowPlayerPos = (int)NowPos;
    //                 if(BeforePos < (int)NowPos)
    //                 {
    //                     //플레이어 전진 중
    //                     MoveConnectManager.RollingPoint = -1;
    //                 }
    //                 else
    //                 {
    //                     //플레이어 후진 중
    //                     MoveConnectManager.RollingPoint = 1;
    //                 }
    //                 BeforePos = (int)NowPos;
    //             }
    //         }
    //         // // 0 번째 맵에서의 움직임제한
    //         // if (MoveConnectManager.GetMapcount() == 0 && gameObject.RectTrans().localPosition.x > -445.0f)
    //         // {
    //         //     gameObject.RectTranRePos(-445.5f, gameObject.RectTrans().localPosition.y, 0.0f);
    //         //     MoveConnectManager.isMapMove = true;
    //         // }
    //         // else if (MoveConnectManager.GetMapcount() == 0 && gameObject.RectTrans().localPosition.x < -580.0f)
    //         // {
    //         //     if (MoveConnectManager.isMapMove == false)
    //         //     {
    //         //         gameObject.RectTranRePos(-580.5f, gameObject.RectTrans().localPosition.y, 0.0f);
    //         //     }
    //         // }
    //         // else if (MoveConnectManager.GetMapcount() == 0 && gameObject.RectTrans().localPosition.x > -446.0f)
    //         // {
    //         //     MoveConnectManager.isMapMove = false;
    //         // }
    //         // // 마지막 맵에서의 움직임제한
    //         // if (MoveConnectManager.GetMapcount() == 5 && gameObject.RectTrans().localPosition.x < -460.0f)
    //         // {
    //         //     gameObject.RectTranRePos(-455.0f, gameObject.RectTrans().localPosition.y, 0.0f);
    //         // }
    //     }
    // }
}
