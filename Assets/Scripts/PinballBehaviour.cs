using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballBehaviour : MonoBehaviour
{
    [SerializeField] GameObject Pinball;
    Rigidbody2D rb;
    float maxSpeed = 10f;
    public int RoundsLeft;
    public Vector3 respawnCheck = new Vector3(0, 4, 0);

    // Start is called before the first frame update
    void Start()
    {
        RoundsLeft = 3;
    }

    // Update is called once per frame
    void Update()
    {
        SpeedCheck();
    }
    
    void SpeedCheck()
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
            rb.velocity = Vector2.zero;
            rb.rotation = 0;
        }
    }
}
