using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    private Game game;
    private void Start()
    {
        game = GameObject.Find("Game").GetComponent<Game>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        game = GameObject.Find("Game").GetComponent<Game>();
        if (game != null)
        {
            Movement player = collision.GetComponent<Movement>();
            if (player != null)
            {
                game.NextLevel();
            }
        }
    }

}
