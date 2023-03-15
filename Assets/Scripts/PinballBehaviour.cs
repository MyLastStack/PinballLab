using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballBehaviour : MonoBehaviour
{
    public int RoundsLeft;

    // Start is called before the first frame update
    void Start()
    {
        RoundsLeft = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
