using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(- Vector2.left * transform.localScale.x * speed * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Movement player = collision.collider.GetComponent<Movement>();
        if (player != null)
        {
            player.Die();
        }
        Destroy(gameObject);
    }

}
