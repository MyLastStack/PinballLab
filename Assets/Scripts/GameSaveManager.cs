using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
public class GameSaveManager : MonoBehaviour
{
    protected GameState gameState;
    string desiredPath;
    // UI Reference

    private void Awake()
    {
        desiredPath = Path.Combine(Application.persistentDataPath, "Pinball_Highscore.txt");
        Debug.Log(desiredPath);
    }
    private void Start()
    {
        gameState = GameObject.FindObjectOfType<GameState>();
        // UI Reference
        LoadFromDisk();
    }
    public void LoadFromDisk()
    {
        if (File.Exists(desiredPath))
        {
            using (StreamReader streamReader = File.OpenText(desiredPath))
            {
                string jsonString = streamReader.ReadToEnd();
                JsonUtility.FromJsonOverwrite(jsonString, gameState);
            }
        }
    }
    public void SaveToDisk()
    {
        Debug.Log("Saving...");
        string jsonString = JsonUtility.ToJson(gameState, true);
        using (StreamWriter streamWriter = File.CreateText(desiredPath))
        {
            streamWriter.Write(jsonString);
            Debug.Log($"Saved {gameState.highscore}");
        }
    }

    void Update()
    {

    }

    //public void NewHighScore()
    //{

    //}
}