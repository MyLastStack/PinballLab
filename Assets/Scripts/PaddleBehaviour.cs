using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleBehaviour : MonoBehaviour
{
    [SerializeField] HingeJoint2D hinge;

    // Update is called once per frame
    void Update()
    {
        Flip(Keyboard.current.spaceKey.isPressed);
    }

    public void Flip(bool isPressed)
    {
        hinge.useMotor = isPressed;
    }
}
