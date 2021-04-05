using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    public CharacterController2D controller;
    public float moveSpeed = 40f;
    public int playerNumber;

    private float movement;
    private bool jump;


    // Update is called once per frame
    void Update()
    {
        /*movement = Input.GetAxis("Horizontal" + playerNumber) * moveSpeed;
        if (Input.GetButtonDown("Jump" + playerNumber))
        {
            jump = true;
        }*/

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>().x * moveSpeed;
        Debug.Log("Move value: " + movement);
    }

    public void OnMove2(InputValue value)
    {
        Debug.Log(value);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jump = context.ReadValue<float>() > 0;
        Debug.Log("pressed jump: "+ jump);
    }

    //public void OnMove(InputAction.CallbackContext context) => movement = context.ReadValue<Vector2>().x;

    private void FixedUpdate()
    {
        controller.Move(movement * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

}
