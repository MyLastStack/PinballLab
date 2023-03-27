using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextScripting : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Score;
    [SerializeField] TextMeshProUGUI HighScore;
    [SerializeField] TextMeshProUGUI Lives;

    PinballBehaviour pinballBehaviour;
    GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        pinballBehaviour = GameObject.FindObjectOfType<PinballBehaviour>();
        gameState = GameObject.FindObjectOfType<GameState>();
        gameState.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = $"Score\n{gameState.score}";
        if (gameState.score > gameState.highscore)
        {

            HighScore.text = $"HighScore\n{gameState.highscore = gameState.score}";
        }
        else
        {
            HighScore.text = $"HighScore\n{gameState.highscore}";
        }
        Lives.text = $"Lives\n{pinballBehaviour.RoundsLeft}";
    }
}
