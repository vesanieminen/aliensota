using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        movement = Input.GetAxis("Horizontal" + playerNumber) * moveSpeed;
        animator.SetFloat("Nopeus", Mathf.Abs(movement));
        if (Input.GetButtonDown("Jump" + playerNumber))
        {
            jump = true;
            animator.SetBool("Hypp‰‰", true);
        }
    }

    private void FixedUpdate()
    {
        controller.Move(movement * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void OnLand()
    {
        animator.SetBool("Hypp‰‰", false);
    }

}
