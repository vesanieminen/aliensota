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
    public AudioClip swooshClip;
    public AudioClip diggy1;
    public AudioClip diggy2;
    public Transform bodyPrefab;

    [SerializeField] private Transform HitPosition;
    [SerializeField] private Transform HitPositionDown;
    [SerializeField] private Transform HitPositionUp;

    private float movement;
    private bool jump;
    private bool punch;

    private AudioSource audioSource;
    private Game game;
    private bool isDead = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        game = GameObject.Find("Game").GetComponent<Game>();
    }

    void PlayPunch()
    {
        audioSource.PlayOneShot(punchClip);

    }

    void PlaySwoosh()
    {
        audioSource.PlayOneShot(swooshClip);

    }

    void PlayDiggy()
    {
        audioSource.PlayOneShot(Random.value > 0.5f ? diggy1 : diggy2);
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
            PlaySwoosh();
            RaycastHit2D hit = Physics2D.Raycast(HitPosition.position, - Vector2.left * transform.localScale.x, 0.5f);
            if (hit.collider != null)
            {
                Movement player = hit.collider.gameObject.GetComponent<Movement>();
                Rigidbody2D rock = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                if (player != null)
                {
                    player.Hit(transform.localScale.x, hitUpForce);
                }         
                else if (rock != null) {
                    rock.AddForce(-Vector2.left * transform.localScale.x * hitBackForce * 0.5f + Vector2.up * hitUpForce * 2);
                    PlayPunch();
                }
                Tile tile = hit.collider.gameObject.GetComponent<Tile>();
                if (tile != null)
                {
                    tile.Hit(new Vector2(hit.point.x - 0.01f * hit.normal.x, hit.point.y - 0.01f * hit.normal.y));
                    PlayDiggy();
                }
                Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.Die();
                }
            }        
        }
    }

    public void Dig(InputAction.CallbackContext value)
    {
        float inputValue = value.ReadValue<float>();
        if (inputValue == 1 && !punch)
        {
            punch = true;
            animator.SetTrigger("Punch");
            PlaySwoosh();
            RaycastHit2D hit = Physics2D.Raycast(HitPositionDown.position, -Vector2.up, 0.5f);
            if (hit.collider != null)
            {
                Movement player = hit.collider.gameObject.GetComponent<Movement>();
                if (player != null)
                {
                    player.Hit(transform.localScale.x, 0);
                }
                Tile tile = hit.collider.gameObject.GetComponent<Tile>();
                if (tile != null)
                {
                    tile.Hit(new Vector2(hit.point.x - 0.01f * hit.normal.x, hit.point.y - 0.01f * hit.normal.y));
                    PlayDiggy();
                }
                Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.Die();
                }
            }
        }
    }

    public void DigUp(InputAction.CallbackContext value)
    {
        float inputValue = value.ReadValue<float>();
        if (inputValue == 1 && !punch)
        {
            punch = true;
            animator.SetTrigger("Punch");
            PlaySwoosh();
            RaycastHit2D hit = Physics2D.Raycast(HitPositionUp.position, Vector2.up, 0.5f);
            if (hit.collider != null)
            {
                Movement player = hit.collider.gameObject.GetComponent<Movement>();
                if (player != null)
                {
                    player.Hit(transform.localScale.x, hitUpForce * 1.5f);
                }
                Tile tile = hit.collider.gameObject.GetComponent<Tile>();
                if (tile != null)
                {
                    tile.Hit(new Vector2(hit.point.x - 0.01f * hit.normal.x, hit.point.y - 0.01f * hit.normal.y));
                    PlayDiggy();
                }
                Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.Die();
                }
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

    public void Hit(float direction, float upForce)
    {
        GetComponent<Rigidbody2D>().AddForce(-Vector2.left * direction * hitBackForce + Vector2.up * upForce);
        PlayPunch();
    }

    public void Die()
    {
        if (!isDead) {
            game.PlayerDies();
            Transform body = Instantiate(bodyPrefab);
            body.position = transform.position;
            isDead = true;
            Destroy(gameObject);
        }
    }

    private void TurnOffPhysicsAndRenderer()
    {

    }

}
