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
    public Canvas canvas;

    [SerializeField] private Transform HitPosition;
    [SerializeField] private Transform HitPositionDown;
    [SerializeField] private Transform HitPositionUp;

    private float movement;
    private bool jump;
    private bool punch;

    private AudioSource audioSource;
    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;
    private CircleCollider2D circleCollider;
    private SpriteRenderer spriteRenderer;
    private Game game;
    private Vector3 spawnLocation;
    private bool isDead = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        game = GameObject.Find("Game").GetComponent<Game>();
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spawnLocation = transform.position;
        canvas.enabled = false;

        EnableMenuMode();
        spriteRenderer.enabled = false;
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
        if (isDead)
        {
            return;
        }
        movement = value.ReadValue<float>() * moveSpeed;
    }

    public void Jump(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            if (isDead)
            {
                Respawn();
            }
            if (!jump)
            {
                jump = true;
                animator.SetBool("Jump", jump);
            }
        }
    }

    public void Punch(InputAction.CallbackContext value)
    {
        if (isDead)
        {
            return;
        }
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
                if (hit.collider.transform.parent != null)
                {
                    Dog dog = hit.collider.transform.parent.GetComponent<Dog>();
                    if (dog != null)
                    {
                        dog.Kill();
                    }
                }
            }        
        }
    }

    public void Dig(InputAction.CallbackContext value)
    {
        if (isDead)
        {
            return;
        }
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
                if (hit.collider.transform.parent != null)
                {
                    Dog dog = hit.collider.transform.parent.GetComponent<Dog>();
                    if (dog != null)
                    {
                        dog.Kill();
                    }
                }
            }
        }
    }

    public void DigUp(InputAction.CallbackContext value)
    {
        if (isDead)
        {
            return;
        }
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
                if (hit.collider.transform.parent != null)
                {
                    Dog dog = hit.collider.transform.parent.GetComponent<Dog>();
                    if (dog != null)
                    {
                        dog.Kill();
                    }
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }
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
            TurnOffPhysicsAndRenderer();
        }
    }

    private void TurnOffPhysicsAndRenderer()
    {
        boxCollider.enabled = false;
        circleCollider.enabled = false;
        rigidbody.isKinematic = true;
        rigidbody.velocity = Vector3.zero;
        spriteRenderer.enabled = false;
        canvas.enabled = true;
    }

    private void TurnOnPhysicsAndRenderer()
    {
        boxCollider.enabled = true;
        circleCollider.enabled = true;
        rigidbody.isKinematic = false;
        spriteRenderer.enabled = true;
        canvas.enabled = false;
    }

    public void Respawn()
    {
        isDead = false;
        transform.position = spawnLocation;
        TurnOnPhysicsAndRenderer();
    }

    public void EnableGameMode()
    {
        foreach (var component in GetComponents<Behaviour>())
        {
            component.enabled = true;
        }
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        TurnOnPhysicsAndRenderer();
    }

    public void EnableMenuMode()
    {
        foreach (var component in GetComponents<Behaviour>())
        {
            if (component.GetType() == typeof(PlayerInput))
            {
                continue;
            }
            component.enabled = false;
        }
        rigidbody.isKinematic = true;
        rigidbody.velocity = Vector3.zero;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void MenuButtonPressed(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            game.BackToMenu();
        }
    }

}
