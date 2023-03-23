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

    [SerializeField] TextMeshProUGUI Score;
    [SerializeField] TextMeshProUGUI HighScore;
    [SerializeField] TextMeshProUGUI Lives;

    PinballBehaviour pinballBehaviour;
    [SerializeField] GameObject pinball;
    

    private void Awake()
    {
        desiredPath = Path.Combine(Application.persistentDataPath, "Pinball_Highscore.txt");
    }
    private void Start()
    {
        gameState = GameObject.FindObjectOfType<GameState>();
        pinballBehaviour = pinball.GetComponent<PinballBehaviour>();
        // UI Reference
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
        string jsonString = JsonUtility.ToJson(gameState);
        using (StreamWriter streamWriter = File.CreateText(desiredPath))
        {
            streamWriter.Write(jsonString);
        }
    }

    void Update()
    {
        Score.text = $"Score\n{gameState.score}";
        if ()
        {

        }
        Lives.text = $"Lives\n{pinballBehaviour.RoundsLeft}";
    }
}