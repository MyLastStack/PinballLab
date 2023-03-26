using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ResultScreen : MonoBehaviour
{
    protected GameState gameState;
    string desiredPath;

    [SerializeField] TextMeshProUGUI YourScore;
    [SerializeField] TextMeshProUGUI BestHighScore;

    private void Awake()
    {
        desiredPath = Path.Combine(Application.persistentDataPath, "Pinball_Highscore.txt");
    }

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.FindObjectOfType<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState.nhs)
        {
            YourScore.text = $"New High Score!\nYour Score:\n{gameState.score}";
            BestHighScore.text = "";
        }
        else
        {
            YourScore.text = $"Your Score:\n{gameState.score}";
            BestHighScore.text = $"Highest Score:\n{gameState.highscore}";
            SaveToDisk();
        }
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
        string jsonString = JsonUtility.ToJson(gameState);
        using (StreamWriter streamWriter = File.CreateText(desiredPath))
        {
            streamWriter.Write(jsonString);
            Debug.Log($"Saved {gameState.highscore}");
        }
    }
}
