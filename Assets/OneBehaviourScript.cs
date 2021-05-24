using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneBehaviourScript : MonoBehaviour
{
    public float initialSpeed; // [m/s] accelerate until reached
    public float initAcc;      // [m/s^2]

    private Vector3 initAccForce;
    private Rigidbody rigidBody;
    private bool isAccelerating = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        initAccForce = Vector3.right * initAcc * rigidBody.mass;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        // exit barrel once desired speed is reached
        if (rigidBody.velocity.magnitude > initialSpeed) isAccelerating = false;

        if (isAccelerating)
        {
            // accelerate
            rigidBody.AddForce(initAccForce);
        }

    }
}
