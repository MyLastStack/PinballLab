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

    PinballBehaviour pinballBehaviour;
    [SerializeField] GameObject pinball;
    protected int tempHighscore;

    private void Awake()
    {
        desiredPath = Path.Combine(Application.persistentDataPath, "Pinball_Highscore.txt");
        Debug.Log(desiredPath);
    }
    private void Start()
    {

        gameState = GameObject.FindObjectOfType<GameState>();
        gameState.nhs = false;
        tempHighscore = 0;
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
        Score.text = $"Score\n{gameState.score}";
        if (gameState.score > gameState.highscore)
        {
            HighScore.text = $"HighScore\n{tempHighscore = gameState.score}";
        }
        else
        {
            HighScore.text = $"HighScore\n{gameState.highscore}";
        }
        //Lives.text = $"Lives\n{pinballBehaviour.RoundsLeft}";

        if (pinballBehaviour.RoundsLeft == 0)
        {
            if (tempHighscore > gameState.highscore)
            {
                gameState.highscore = tempHighscore;
            }
            //else
            //{
            //    gameState.nhs = false;
            //}
        }
    }

    //public void NewHighScore()
    //{

    //}
}