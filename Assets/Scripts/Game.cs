using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

    public static int DEFAULT_LAYER = 0;
    public static int DYNAMIC_LAYER = 7;
    public static string ACTION_MAP_MENU = "Menu";
    public static string ACTION_MAP_PLAYER = "Player";

    public AudioClip playerDiesSound;
    public AudioClip enemyDiesSound;
    public AudioClip collectCoinSound;
    public GameObject uiCamera;
    public GameObject splash;
    public GameObject mainMenu;

    private AudioSource audioSource;
    private InputSystemUIInputModule uiInputModule;
    private bool isGameFinished = false;
    public List<PlayerInput> playerInputs = new List<PlayerInput>();

    void Awake()
    {
        if (Application.isEditor)
            Application.runInBackground = true;

        audioSource = GetComponent<AudioSource>();
    }

    public void Finished()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    private void Start()
    {
        uiCamera.SetActive(true);
        mainMenu.SetActive(false);
        DontDestroyOnLoad(gameObject);
        uiInputModule = GetComponent<InputSystemUIInputModule>();
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
        DontDestroyOnLoad(playerInput.transform.parent.gameObject);
        playerInput.uiInputModule = uiInputModule;
        playerInputs.Add(playerInput);
        splash.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        GameObject startLocation = GameObject.FindGameObjectWithTag("Start Location");
        foreach (var playerInput in playerInputs)
        {
            if (startLocation != null)
            {
                playerInput.transform.position = startLocation.transform.position;
            }
            playerInput.GetComponent<Movement>().EnableGameMode();
            playerInput.SwitchCurrentActionMap(ACTION_MAP_PLAYER);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        foreach (var playerInput in playerInputs)
        {
            playerInput.SwitchCurrentActionMap(ACTION_MAP_MENU);
            playerInput.GetComponent<Movement>().EnableMenuMode();
        }
    }

}
