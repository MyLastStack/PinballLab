using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Score;
    [SerializeField] TextMeshProUGUI HighScore;

    GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.FindObjectOfType<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = $"Your Score:\n{gameState.score}";
        HighScore.text = $"Highest Score:\n{gameState.highscore}";
    }
}
