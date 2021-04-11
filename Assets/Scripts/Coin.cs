using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private Game game;
    private void Start()
    {
        game = GameObject.Find("Game").GetComponent<Game>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Movement player = collider.GetComponent<Movement>();
        if (player != null)
        {
            game.CollectCoin();
            Destroy(gameObject);
        }
    }


}
