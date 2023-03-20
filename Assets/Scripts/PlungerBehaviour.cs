using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlungerBehaviour : MonoBehaviour
{
    [SerializeField] SpringJoint2D plungerSlider;
    public void Pull(float amount)
    {
        plungerSlider.distance = amount * -12f;
        plungerSlider.attachedRigidbody.AddForce(Vector2.down * amount * 16);
    }
}