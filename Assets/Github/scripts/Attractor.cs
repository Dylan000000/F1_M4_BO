using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        GameObject[] gravityObjects = GameObject.FindGameObjectsWithTag("Gravity");
        foreach (GameObject gravityObject in gravityObjects)
        {
            Attractor attractor = gravityObject.GetComponent<Attractor>();
            if (attractor != null && attractor != this)
            {

                Attract(attractor);
            }
        }
    }

    void Attract(Attractor objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;

        float distance = direction.magnitude;

        float forceMagnitude = (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);

        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);

        
    }
}
