using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

    public static int DEFAULT_LAYER = 0;
    public static int DYNAMIC_LAYER = 7;

    public AudioClip playerDiesSound;
    public AudioClip enemyDiesSound;
    public AudioClip collectCoinSound;
    public GameObject uiCamera;

    private AudioSource audioSource;
    private GameObject startLocation;
    private bool isGameFinished = false;

    void Awake()
    {
        if (Application.isEditor)
            Application.runInBackground = true;

        audioSource = GetComponent<AudioSource>();
        startLocation = GameObject.FindGameObjectWithTag("Start Location");
    }

    public void Finished()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    private void Start()
    {
        uiCamera.SetActive(true);
        DontDestroyOnLoad(gameObject);
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

    private void OnPlayerJoined(PlayerInput playerInput)
    {
        if (startLocation != null)
        {
            playerInput.transform.position = startLocation.transform.position;
        }
        
    
    }

}
