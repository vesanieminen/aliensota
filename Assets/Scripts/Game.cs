using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public AudioClip playerDiesSound;
    public AudioClip enemyDiesSound;

    private AudioSource audioSource;

    void Awake()
    {
        if (Application.isEditor)
            Application.runInBackground = true;

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayerDies()
    {
        audioSource.PlayOneShot(playerDiesSound);
    }

    public void EnemyDies()
    {
        audioSource.PlayOneShot(enemyDiesSound);
    }

}
