using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndStateCheck : MonoBehaviour
{

    public GameObject[] checkedObjects;

    private Game game;

    private void Start()
    {
        game = GameObject.Find("Game").GetComponent<Game>();
    }

    void FixedUpdate()
    {
        int aliveGameObjects = 0;
        foreach (GameObject objectChecked in checkedObjects)
        {
            if (objectChecked != null)
            {
                aliveGameObjects++;
            }
        }
        if (aliveGameObjects == 0) {
            game.NextLevel();
        }
    }
}
