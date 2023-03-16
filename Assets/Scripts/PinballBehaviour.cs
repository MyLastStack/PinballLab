using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballBehaviour : MonoBehaviour
{
    [SerializeField] GameObject Pinball;
    public int RoundsLeft;
    public bool shadowRealmed;

    // Start is called before the first frame update
    void Start()
    {
        RoundsLeft = 3;
        shadowRealmed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            Destroy(this.gameObject);
            RoundsLeft--;
            shadowRealmed = true;
        }

        if (shadowRealmed && RoundsLeft != 0)
        {
            Instantiate(Pinball, new Vector3(0f, 5f, 0f), Quaternion.identity);
            shadowRealmed = false;
        }
    }
}
