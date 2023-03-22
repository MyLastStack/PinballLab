using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BumperPts : MonoBehaviour
{
    PointsHolder pointsHolder;
    SpriteRenderer spriteRenderer;
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
        pointsHolder = GetComponent<PointsHolder>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.material.color = Color.white;
        timer = 0;
        stateofBumper = StateofBumper.open;
    }

    // Update is called once per frame
    void Update()
    {
        if (stateofBumper == StateofBumper.close)
        {
            timer = 0.5f;
            if (timer > 0)
            {
                spriteRenderer.material.color = Color.red;
                timer -= Time.deltaTime;
            }
            else
            {
                spriteRenderer.material.color = Color.green;
                stateofBumper = StateofBumper.open;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Pinball" && stateofBumper == StateofBumper.open)
        {
            //pointsHolder.Points += pointsGained;
            //stateofBumper = StateofBumper.close;

        }
    }
}
