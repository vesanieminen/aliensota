using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImageIn : MonoBehaviour
{

    private Image image;
    public float fadeStartTime = 0f;
    private float animationStartTime;
    private float timeAlive;
    public float fadeTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        Color color = image.color;
        color.a = 0;
        image.color = color;
        animationStartTime = Time.time + fadeStartTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (animationStartTime > Time.time)
        {
            return;
        }
        timeAlive = Time.time - animationStartTime;
        Color color = image.color;
        color.a = timeAlive / fadeTime;
        image.color = color;
        if (timeAlive > fadeTime)
        {
            Destroy(this);
        }
    }
}
