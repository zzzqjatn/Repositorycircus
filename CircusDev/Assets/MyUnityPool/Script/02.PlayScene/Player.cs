using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

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

        NowRoom = 0;
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
        else if(InputManager.isJump == true)
        {
            MoveLimite(gameObject.RectTrans().position.x);
        }
    }

    public void Player_Move()
    {
        if (0.0f <= gameObject.RectTrans().localPosition.x && gameObject.RectTrans().localPosition.x <= InputManager.MapMaxPos)
        {
            float movePoint = InputManager.LR_KeyInput() * (InputManager.SPEED * Time.deltaTime);
            RectTransform Result = default;
            Result = gameObject.GetComponent<RectTransform>();

            movePoint += Result.localPosition.x;

            Result.localPosition = new Vector3(
            movePoint,
            Result.localPosition.y + 0.0f,
            Result.localPosition.z + 0.0f);

            MoveLimite(gameObject.RectTrans().position.x);
        }
    }

    public void MoveLimite(float PosX)
    {
        if (gameObject.RectTrans().localPosition.x < 0.0f)
        {
            gameObject.RectTranRePos(0.0f,
                gameObject.RectTrans().localPosition.y,
                gameObject.RectTrans().localPosition.z);
        }
        else if (gameObject.RectTrans().localPosition.x > InputManager.MapMaxPos)
        {
            gameObject.RectTranRePos(InputManager.MapMaxPos,
                gameObject.RectTrans().localPosition.y,
                gameObject.RectTrans().localPosition.z);
        }
    }

    public void Player_Jump()
    {
        InputManager.isJump = true;
        player_Rigid2D.AddForce(new Vector2((InputManager.LR_KeyInput() * InputManager.POWER * 0.5f), InputManager.POWER), ForceMode2D.Impulse);
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
