using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Movement player = collider.GetComponent<Movement>();
        if (player != null)
        {
            player.Die();
        }
    }

}
