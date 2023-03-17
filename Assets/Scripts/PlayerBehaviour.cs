using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] PaddleBehaviour leftPaddle;
    [SerializeField] PaddleBehaviour rightPaddle;
    //[SerializeField] PlungerBehaviour plunger;

    [SerializeField] InputAction useLeft;
    [SerializeField] InputAction useRight;
    //[SerializeField] InputAction usePlunger;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        useLeft.Enable();
        useRight.Enable();
        //usePlunger.Enable();
    }

    private void OnDisable()
    {
        useLeft.Disable();
        useRight.Disable();
        //usePlunger.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        leftPaddle.Flip(useLeft.IsPressed());
        rightPaddle.Flip(useRight.IsPressed());
        //plunger.Pull(pullPlunger.ReadValue<float>);
    }
}
