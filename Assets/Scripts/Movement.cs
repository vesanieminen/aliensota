using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    public float moveSpeed = 40f;
    public int playerNumber;

    private float movement;
    private bool jump;

    // Update is called once per frame
    void Update()
    {
 
    }

    public void Move(InputAction.CallbackContext value)
    {
        movement = value.ReadValue<float>() * moveSpeed;
        animator.SetFloat("Speed", Mathf.Abs(movement));
    }

    public void Jump(InputAction.CallbackContext value)
    {
        jump = true;
        animator.SetBool("Jump", jump);
    }

    private void FixedUpdate()
    {
        controller.Move(movement * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void OnLand()
    {
        animator.SetBool("Jump", false);
    }

}
