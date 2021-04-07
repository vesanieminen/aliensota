using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    public float moveSpeed = 40f;
    public float hitBackForce = 1000f;
    public float hitUpForce = 250f;
    public AudioClip punchClip;

    [SerializeField] private Transform HitPosition;

    private float movement;
    private bool jump;
    private bool punch;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void PlayPunch()
    {
        audioSource.PlayOneShot(punchClip);

    }

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
            RaycastHit2D hit = Physics2D.Raycast(HitPosition.position, - Vector2.left * transform.localScale.x, 0.5f);
            if (hit.collider != null)
            {
                hit.collider.gameObject.SendMessage("Hit", transform.localScale.x);
            }
            

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

    public void Hit(float direction)
    {
        GetComponent<Rigidbody2D>().AddForce(-Vector2.left * direction * hitBackForce + Vector2.up * hitUpForce);
        PlayPunch();

    }

}
