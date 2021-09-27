using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;

    public bool autoShoot;
    
    private const float MAXLeft = -9.8f;
    private const float MAXRight = 9.7f;

    public float SpaceshipSpeed = 2.5f;
    public float shotCooldown=2f;
    private bool isShooting = false;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > MAXLeft)
        {
            transform.Translate(Vector2.left * Time.deltaTime* SpaceshipSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < MAXRight)
        {
            transform.Translate(Vector2.right * Time.deltaTime* SpaceshipSpeed);
        }

        if ((Input.GetKey(KeyCode.Space)||autoShoot) && !isShooting)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        isShooting = true;
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(shotCooldown);
        isShooting = false;
    }
}
