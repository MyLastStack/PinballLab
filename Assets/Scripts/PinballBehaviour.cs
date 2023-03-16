using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballBehaviour : MonoBehaviour
{
    [SerializeField] GameObject Pinball;
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
