using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PaddleBehaviour : MonoBehaviour
{
    [SerializeField] HingeJoint2D hinge;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.material.color = Color.white;
    }

    //private void Update()
    //{
    //    Flip(Keyboard.current.spaceKey.isPressed);
    //}
    public void Flip(bool isPressed)
    {
        hinge.useMotor = isPressed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float timer = 0;
        if (collision.transform.tag == "Pinball")
        {
            timer = 10f;
        }

        while (timer != 0)
        {
            Debug.Log(timer);
            timer -= Time.deltaTime;
        }
    }
}