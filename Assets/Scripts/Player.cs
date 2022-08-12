using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;

    public bool autoShoot;
    public bool smartAutoShoot;
    
    private const float MAXLeft = -9.8f;
    private const float MAXRight = 9.7f;

    public float SpaceshipSpeed = 2.5f;
    public float shotCooldown=2f;
    private bool isShooting = false;
    
    public bool BCIMode = false;
    public float BCIModeLeft = -3.83f;
    public float BCIModeRight = 3.83f;
    
    private void Update()
    {
        if (BCIMode)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                transform.localPosition = new Vector2(BCIModeLeft, transform.localPosition.y);
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                transform.localPosition = new Vector2(BCIModeRight, transform.localPosition.y);
            else
                transform.localPosition = new Vector2(0, transform.localPosition.y);
        }
        else
        {
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))  && transform.position.x > MAXLeft)
                transform.Translate(Vector2.left * Time.deltaTime* SpaceshipSpeed);
            if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && transform.position.x < MAXRight)
                transform.Translate(Vector2.right * Time.deltaTime* SpaceshipSpeed);
        }

        if ((Input.GetKey(KeyCode.Space) || autoShoot) && !isShooting)
        {
            if (smartAutoShoot)
            {
                if (transform.localPosition.x!=0)
                    StartCoroutine(Shoot());
            }
            else
            {
                StartCoroutine(Shoot());
            }
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
