using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform bulletSpawnPosition;
    public Transform bullet;
    public float bulletSpawnInterval = 2f;

    private float nextBulletSpawnTime;
    private AudioSource audioSource;

    private void Start()
    {
        nextBulletSpawnTime = Time.time + bulletSpawnInterval + Random.value * bulletSpawnInterval;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Time.time > nextBulletSpawnTime)
        {
            nextBulletSpawnTime = Time.time + bulletSpawnInterval;
            Transform newBullet = Instantiate(bullet);
            newBullet.position = bulletSpawnPosition.position;
            newBullet.localScale = transform.localScale;
            if (GetComponent<Renderer>().isVisible)
            {
                audioSource.Play();
            }
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
