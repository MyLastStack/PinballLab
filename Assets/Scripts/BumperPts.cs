using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperPts : MonoBehaviour
{
    PointsHolder pointsHolder;
    [SerializeField] GameObject bumper;
    public int pointsGained = 5;

    private enum StateofBumper
    {
        open,
        close
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Pinball")
        {
            
        }
    }
}
