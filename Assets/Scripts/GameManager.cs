using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int MaxAliens = 5;
    private int AliensAlive;
    private GameObject[] Aliens;
    
    private void Start()
    {
        AliensAlive = MaxAliens;
        Aliens = GameObject.FindGameObjectsWithTag("Alien");
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void AlienKillAlert()
    {
        AliensAlive -= 1;
        if (AliensAlive==0)
        {
            foreach (var Alien in Aliens)
            {
                Alien.SetActive(true);
            }

            AliensAlive = MaxAliens;
        }
    }
}
