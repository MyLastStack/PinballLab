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

        #region used mouse coordinates
        // did this to understand how inputAction values worked
        //PlungerPull(pullPlunger.IsPressed());
        //if (pullPlunger.ReadValue<float>() > 0)
        //{
        //    pullSTR = pullPlunger.ReadValue<float>() * -1;
        //}
        //plunger.Pull(pullSTR / 300);
        //pullSTR= 0;
        #endregion

        plunger.Pull(pullPlunger.ReadValue<float>());
    }
