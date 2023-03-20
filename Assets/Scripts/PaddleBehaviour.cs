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

    void Update()
    {
        if (timer > 0)
        {
            spriteRenderer.material.color = Color.red;
            timer -= Time.deltaTime;
        }
        else
        {
            spriteRenderer.material.color = Color.white;
        }
    }

    public void Flip(bool isPressed)
    {
        hinge.useMotor = isPressed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Pinball")
        {
            timer = 0.5f;
        }
    }
}