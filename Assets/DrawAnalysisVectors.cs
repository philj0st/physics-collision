using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawAnalysisVectors : MonoBehaviour
{
    public List<GameObject> objects;
    private List<Rigidbody> rigidbodies;


    // Start is called before the first frame update
    void Start() 
    {
        rigidbodies = new List<Rigidbody>();
        foreach (GameObject obj in objects)
        {
            rigidbodies.Add(obj.GetComponent<Rigidbody>());
        }
    }

    private void FixedUpdate()
    {
        // draw center of mass
        Vector3 centerOfMass = new Vector3();
        Vector3 totalMomentum = new Vector3();
        Vector3 totalAngMom = new Vector3();

        float sumOfMasses = 0;
        foreach (Rigidbody rb in rigidbodies)
        {
            // calculate center of mass
            centerOfMass += rb.worldCenterOfMass * rb.mass;
            sumOfMasses += rb.mass;

            // calculate total momentum
            totalMomentum += rb.velocity * rb.mass;
        }
        centerOfMass /= sumOfMasses;

        // draw each body's angular momentum with respect to the center of mass
        foreach (Rigidbody rb in rigidbodies)
        {
            // momentum of the body
            Vector3 momentum = rb.velocity * rb.mass;

            // scale down by mass to see the vector
            Color funky = new Color((rb.position.x % 255) / 255, ((255 - rb.position.x) % 255) / 255, ((255 / 2 + rb.position.x) % 255) / 255);
            Debug.DrawRay(rb.worldCenterOfMass, momentum / rb.mass, funky);
            
            // draw angular momentum
            // cross product from COM to body with momentum
            Vector3 angMom = Vector3.Cross((rb.position - centerOfMass), momentum);
            Debug.DrawRay(rb.worldCenterOfMass, angMom/rb.mass, Color.yellow);
            totalAngMom += angMom;
        }

        // draw total angular momentum
        Debug.DrawRay(centerOfMass, totalAngMom/sumOfMasses, Color.red,0,false);

        // draw momentum
        Debug.DrawRay(centerOfMass, totalMomentum/sumOfMasses, Color.green, 0.1f, false);
    }
}
