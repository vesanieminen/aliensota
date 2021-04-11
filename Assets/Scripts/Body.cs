using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{

    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rigidbody.velocity.magnitude <= 0.01f)
        {
            rigidbody.isKinematic = true;
            Debug.Log("set kinematic: " + true);
        }
    }
}
