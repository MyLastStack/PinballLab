using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

[System.Serializable]
public struct SaveDataContainer
{
    public string Date;
    public int Score;

    public SaveDataContainer(string date, int score)
    {
        Date = DateTime.Now.ToString();
        Score = score;
    }
}
