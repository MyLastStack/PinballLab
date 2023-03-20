using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] PaddleBehaviour leftPaddle;
    [SerializeField] PaddleBehaviour rightPaddle;
    [SerializeField] PlungerBehaviour plunger;
    [SerializeField] InputAction useLeft;
    [SerializeField] InputAction useRight;
    [SerializeField] InputAction pullPlunger;

    public float pullSTR = 0;
    private void OnEnable()
    {
        useLeft.Enable();
        useRight.Enable();
        pullPlunger.Enable();
    }
    private void OnDisable()
    {
        useLeft.Disable();
        useRight.Disable();
        pullPlunger.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        leftPaddle.Flip(useLeft.IsPressed());
        rightPaddle.Flip(useRight.IsPressed());
        //PlungerPull(pullPlunger.IsPressed());
        if (pullPlunger.IsPressed())
        {
            Debug.Log(pullPlunger.ReadValue<float>());
        }
        if (pullPlunger.ReadValue<float>() > 0)
        {
            pullSTR = pullPlunger.ReadValue<float>() * -1;
        }
        plunger.Pull(pullSTR / 300);
        pullSTR= 0;
    }

    //void PlungerPull(bool ToF)
    //{
    //    //if (pullPlunger.ReadValue<float>() > 0)
    //    //{
    //    //    pullSTR = pullPlunger.ReadValue<float>() * -1;
    //    //}
    //    plunger.Pull(pullSTR / 300);
    //}
}