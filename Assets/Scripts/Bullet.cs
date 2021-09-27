using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 8f;

    private void Start()
    {
        // Destroy the bullet after it disappears of the screen
        Destroy(gameObject,4);
    }

    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime* speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Alien"))
        {
            other.gameObject.GetComponent<Alien>().Kill();
            Destroy(gameObject);
        }
    }
}
