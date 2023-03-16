using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballBehaviour : MonoBehaviour
{
    [SerializeField] GameObject Pinball;
    public int RoundsLeft;
    private bool shadowRealmed;

    // Start is called before the first frame update
    void Start()
    {
        RoundsLeft = 3;
        shadowRealmed = false;
    }

    // Update is called once per frame
    void Update()
    {
        Respawn();
    }

    void Respawn()
    {
        if (shadowRealmed && RoundsLeft != 0)
        {
            Instantiate(Pinball, new Vector3(0f, 5f, 0f), Quaternion.identity);
            shadowRealmed = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            RoundsLeft--;
            shadowRealmed = true;
            Destroy(this.gameObject);
        }
    }
}
