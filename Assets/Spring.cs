using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public float length;    // [m] length of the spring
    public float springStiffness;
    public GameObject leftObj;
    public GameObject rightObj;

    // Start is called before the first frame update
    void Start()
    {
        leftObj = GameObject.FindWithTag("One");
        rightObj = GameObject.FindWithTag("Two");
    }

    private void FixedUpdate()
    {
        Rigidbody left = this.leftObj.GetComponent<Rigidbody>();
        Rigidbody right = this.rightObj.GetComponent<Rigidbody>();
        // once bodies are close enough
        float distance = Mathf.Abs(left.position.x - right.position.x) - 1;
        if (distance <= length)
        {
            // apply force in opposite directions relative to the spring's contraction
            float springForce = distance * springStiffness;
            left.AddForce(Vector3.left * springForce);
            right.AddForce(Vector3.right * springForce);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
