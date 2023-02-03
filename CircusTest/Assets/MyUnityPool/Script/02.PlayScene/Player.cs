using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D player_BoxCollider2D;
    private Rigidbody2D player_Rigid2D;
    private Animator player_ani;

    public float playerX;
    public float playerY;

    void Start()
    {
        player_BoxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        player_Rigid2D = gameObject.GetComponent<Rigidbody2D>();
        player_ani = gameObject.GetComponent<Animator>();

        player_Rigid2D.velocity = Vector3.zero;
        player_BoxCollider2D.offset = new Vector2(0, -25);
        player_BoxCollider2D.size = new Vector2(40, 120);

        gameObject.RectTranRePos(-570.0f, 0, 0f);

        playerX = 0.0f;
        playerY = 0.0f;
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
        float movePoint = InputManager.LR_KeyInput() * (InputManager.SPEED * Time.deltaTime);
        playerX += movePoint;

        if (playerX <= 0) playerX = 0.0f;
        else if (playerX >= 8000.0f) playerX = 8000.0f;

        if ((0.0f < playerX && playerX < 130.0f) || (7650.0f < playerX && playerX < 8000.0f))
        {
            InputManager.isMapMove = false;
            gameObject.RectTranPosMove(movePoint, 0f, 0f);
        }
        else
        {
            InputManager.isMapMove = true;
        }
    }
    public void Player_Jump()
    {
        InputManager.isJump = true;
        player_Rigid2D.AddForce(new Vector2((InputManager.LR_KeyInput() * (InputManager.POWER * 0.5f) / 50), InputManager.POWER), ForceMode2D.Impulse);
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
