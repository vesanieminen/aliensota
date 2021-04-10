using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogLegs : MonoBehaviour
{

    private Dog dog;

    private void Start()
    {
        dog = transform.parent.GetComponent<Dog>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == Game.DEFAULT_LAYER)
        {
            dog.FlipDirection();
        }
        Dog otherDog = collider.GetComponent<Dog>();
        if (otherDog != null)
        {
            Debug.Log("hit another dog: " + otherDog);
            dog.FlipDirection();
        }
    }

}
