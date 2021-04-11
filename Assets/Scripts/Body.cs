using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    private float stopTime = 3f;
    private float rigidTime;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidTime = Time.time + stopTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rigidbody.velocity.magnitude == 0f && Time.time > rigidTime)
        {
            rigidbody.isKinematic = true;
        }
    }
}
