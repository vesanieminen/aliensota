using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public CharacterController2D controller;
    public float moveSpeed = 40f;

    private float movement;
    private bool jump;

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * moveSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(movement * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

}
