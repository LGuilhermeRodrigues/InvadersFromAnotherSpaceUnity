using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public GameObject explosionPrefab;
    private GameManager gameManager;

    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void Kill()
    {
        var explosionInstance = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosionInstance, explosionInstance.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        gameObject.SetActive(false);
        gameManager.AlienKillAlert();
    }
}
