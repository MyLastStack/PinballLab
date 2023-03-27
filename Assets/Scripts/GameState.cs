using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameState : MonoBehaviour
{
    public int score = 0;
    public int highscore = 0;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameState");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}