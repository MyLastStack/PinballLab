using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballBehaviour : MonoBehaviour
{
    [SerializeField] GameObject Pinball;
    Rigidbody2D rb;
    float maxSpeed = 10f;
    public int RoundsLeft;
    public Vector3 respawnCheck;

    // Start is called before the first frame update
    void Start()
    {
        RoundsLeft = 3;
        respawnCheck = new Vector3(2.5f, -1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity.Normalize();
            rb.velocity *= maxSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "DeathZone")
        {
            RoundsLeft--;
            if (RoundsLeft == 0)
            {
                Destroy(this.gameObject);
            }
            Pinball.transform.position = respawnCheck;
        }
    }
}
