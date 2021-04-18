using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{

    public float moveSpeed = 3f;

    private Game game;
    private Rigidbody2D rigidbody;
    private bool isGrounded = false;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        game = GameObject.Find("Game").GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector2(Mathf.Sign(transform.localScale.x) * moveSpeed, rigidbody.velocity.y);
    }

    public void FlipDirection()
    {
        float oldValueX = transform.localScale.x;
        Vector2 scale = new Vector2(-transform.localScale.x, transform.localScale.y);
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Movement player = collision.collider.GetComponent<Movement>();
        Dog otherDog = collision.collider.GetComponent<Dog>();
        if (otherDog != null)
        {
            FlipDirection();
        }
        int layer = collision.collider.gameObject.layer;
        if (player != null)
        {
            player.Die();
        }
        else if (layer == Game.DYNAMIC_LAYER) 
        {
            FlipDirection();
        }
    }

    public void SetGrounded(bool isGrounded)
    {
        this.isGrounded = isGrounded;
    }

    public void Kill()
    {
        game.EnemyDies();
        Destroy(gameObject);
    }

}
