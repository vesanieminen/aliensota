using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public static int DEFAULT_LAYER = 0;
    public static int DYNAMIC_LAYER = 7;

    public AudioClip playerDiesSound;
    public AudioClip enemyDiesSound;
    public AudioClip collectCoinSound;
    public GameObject uiCamera;

    private AudioSource audioSource;

    void Awake()
    {
        if (Application.isEditor)
            Application.runInBackground = true;

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        uiCamera.SetActive(true);
    }

    public void PlayerDies()
    {
        audioSource.PlayOneShot(playerDiesSound);
    }

    public void EnemyDies()
    {
        audioSource.PlayOneShot(enemyDiesSound);
    }

    public void CollectCoin()
    {
        audioSource.PlayOneShot(collectCoinSound);
    }

}
