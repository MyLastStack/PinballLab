using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BumperPts : MonoBehaviour
{
    [SerializeField] GameObject Bumper;
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
        timer = 0;
        stateofBumper = StateofBumper.open;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.material.color = Color.cyan;
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
            timer = 0.5f;
            stateofBumper = StateofBumper.close;
            //pointsHolder.Points += pointsGained;
            //stateofBumper = StateofBumper.close;
        }
    }
}
