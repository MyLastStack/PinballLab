using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PaddleBehaviour : MonoBehaviour
{
    [SerializeField] HingeJoint2D hinge;
    SpriteRenderer spriteRenderer;
    public float timer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.material.color = Color.white;
        timer = 0;
    }

    public void Flip(bool isPressed)
    {
        hinge.useMotor = isPressed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Pinball")
        {
            timer = 10f;
        }

        if (timer > 0)
        {
            spriteRenderer.material.color = Color.red;
            Debug.Log(timer);
            timer -= Time.deltaTime;
        }
        else
        {
            spriteRenderer.material.color = Color.white;
        }
    }
}