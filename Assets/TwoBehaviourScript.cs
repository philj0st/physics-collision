using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            //if we're not colliding with the Plane
            if (contact.otherCollider.CompareTag("Three"))
            {
                
                FixedJoint joint = gameObject.AddComponent<FixedJoint>() as FixedJoint;
                joint.connectedBody = contact.otherCollider.attachedRigidbody;
                joint.enableCollision = false;
            }
        }
        if (collision.relativeVelocity.magnitude > 2) { }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
