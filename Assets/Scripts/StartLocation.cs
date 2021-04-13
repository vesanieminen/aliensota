using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLocation : MonoBehaviour
{

    void Start()
    {
        Destroy(GetComponent<SpriteRenderer>());
    }

}
