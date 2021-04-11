using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHead : MonoBehaviour
{

    private Game game;
    private Dog dog;

    private void Start()
    {
        game = GameObject.Find("Game").GetComponent<Game>();
        dog = transform.parent.GetComponent<Dog>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Movement player = collider.GetComponent<Movement>();
        if (player != null)
        {
            dog.Kill();
        }
    }

}
