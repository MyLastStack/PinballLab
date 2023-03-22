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
    public Vector3 koHole;
    float timer;

    enum KickoutTF
    {
        t,
        f
    }
    KickoutTF kickoutTF;
    // Start is called before the first frame update
    void Start()
    {
        RoundsLeft = 3;
        respawnCheck = new Vector3(2.5f, -1f, 0f);
        timer = 0;
        kickoutTF = KickoutTF.f;
        rb = Pinball.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0 && kickoutTF == KickoutTF.t)
        {
            rb.isKinematic = true;
            Pinball.transform.position = koHole;
            Debug.Log(timer);
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                kickoutTF = KickoutTF.f;
                rb.isKinematic = false;
                Pinball.transform.position = respawnCheck;
            }
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
        if (collision.transform.tag == "Bumper")
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Kickout")
        {
            timer = 2f;
            koHole = collision.transform.position;
            kickoutTF= KickoutTF.t;
        }
    }
}
