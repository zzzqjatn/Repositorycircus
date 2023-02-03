using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D player_BoxCollider2D;
    private Rigidbody2D player_Rigid2D;
    private Animator player_ani;

    public int NowRoom;

    void Start()
    {
        player_BoxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        player_Rigid2D = gameObject.GetComponent<Rigidbody2D>();
        player_ani = gameObject.GetComponent<Animator>();

        player_Rigid2D.velocity = Vector3.zero;
        player_BoxCollider2D.offset = new Vector2(0, -25);
        player_BoxCollider2D.size = new Vector2(40, 120);

        gameObject.RectTranRePos(-450.0f, 0, 0f);   //시작지점
    }
    void Update()
    {
        if (InputManager.Jump_KeyInput() == true && InputManager.isJump == false)
        {
            Player_Jump();
        }
        // else if (InputManager.isJump == false)
        // {
        //     Player_Move();
        // }
    }

    public void Player_Move()
    {
        float movePoint = InputManager.LR_KeyInput() * (InputManager.SPEED * Time.deltaTime);
        gameObject.RectTranPosMove(movePoint, 0f, 0f);
    }
    public void Player_Jump()
    {
        InputManager.isJump = true;
        player_Rigid2D.AddForce(new Vector2((InputManager.LR_KeyInput() * (InputManager.POWER * 0.5f) / 50), InputManager.POWER), ForceMode2D.Impulse);
        player_ani.SetBool("JumpTime", true);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("BackTemp"))
        {
            InputManager.isJump = false;
            player_Rigid2D.velocity = Vector3.zero;
            player_ani.SetBool("JumpTime", false);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("RoomCheck"))
        {
            NowRoom = other.gameObject.GetComponent<RoomSet>().RoomNumber;
        }
    }

    public void Player_Die()
    {

    }
}
