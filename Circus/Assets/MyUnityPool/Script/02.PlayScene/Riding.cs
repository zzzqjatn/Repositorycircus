using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riding : MonoBehaviour
{
    private Animator Riding_Ani;
    void Start()
    {
        Riding_Ani = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        ChangeAni();
    }

    private void ChangeAni()
    {
        if (InputManager.isJump == true)
        {
            Riding_Ani.SetBool("JumpTime", true);
        }
        else if (InputManager.isJump == false)
        {
            Riding_Ani.SetBool("JumpTime", false);
        }
    }
}
