using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BumperPts : MonoBehaviour
{
    [SerializeField] GameObject Bumper;
    SpriteRenderer spriteRenderer;

    protected GameState gameState;

    public int pointsGained = 5;

    private enum StateofBumper
    {
        open,
        close
    }
    StateofBumper stateofBumper;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        stateofBumper = StateofBumper.open;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.material.color = Color.cyan;
        gameState = GameObject.FindObjectOfType<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0 && stateofBumper == StateofBumper.close)
        {
            spriteRenderer.material.color = Color.red;
            timer -= Time.deltaTime;
        }
        else
        {
            spriteRenderer.material.color = Color.cyan;
            stateofBumper = StateofBumper.open;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Pinball" && stateofBumper == StateofBumper.open)
        {
            timer = 0.1f;
            stateofBumper = StateofBumper.close;
            gameState.score += pointsGained;
            //pointsHolder.Points += pointsGained;
            //stateofBumper = StateofBumper.close;
        }
    }
}
