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
    private bool punch;

    // Update is called once per frame
    void Update()
    {
 
    }

    public void Move(InputAction.CallbackContext value)
    {
        movement = value.ReadValue<float>() * moveSpeed;
    }

    public void Jump(InputAction.CallbackContext value)
    {
        if (!jump)
        {
            jump = true;
            animator.SetBool("Jump", jump);
        }
    }

    public void Punch(InputAction.CallbackContext value)
    {
        float inputValue = value.ReadValue<float>();
        if (inputValue == 1 && !punch)
        {
            punch = true;
            animator.SetTrigger("Punch");
        }
    }

    private void FixedUpdate()
    {
        controller.Move(movement * Time.fixedDeltaTime, false, jump);
        animator.SetFloat("Speed", Mathf.Abs(movement));
        jump = false;
        punch = false;
    }

    public void OnLand()
    {
        animator.SetBool("Jump", false);
    }

}
