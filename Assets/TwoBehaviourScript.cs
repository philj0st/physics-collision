using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoBehaviourScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        
        //if we're not colliding with the Plane
        if (collision.collider.CompareTag("Three"))
        {
            // cling to other body and disable collision
            FixedJoint joint = this.gameObject.AddComponent<FixedJoint>() as FixedJoint;
            joint.connectedBody = collision.collider.attachedRigidbody;
            joint.enableCollision = false;

            Debug.DrawRay(joint.anchor, Vector3.up * joint.massScale, Color.cyan);

            // maybe unnessecary
            //this.GetComponent<Rigidbody>().ResetCenterOfMass();
            //joint.connectedBody.ResetCenterOfMass();
        }
        
        if (collision.relativeVelocity.magnitude > 2) { }
    }


    private void FixedUpdate()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        //Debug.DrawRay(rb.worldCenterOfMass,Vector3.up* this.GetComponent<Rigidbody>().mass/1000, Color.cyan);
    }
}
