using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform camera;

    // Update is called once per frame
    void Update()
    {
        var pos = camera.transform.position;
        pos.x = transform.position.x;
        camera.transform.position = pos;
    }
}
