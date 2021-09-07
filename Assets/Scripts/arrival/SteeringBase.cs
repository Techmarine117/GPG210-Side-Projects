using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Steering;

public class SteeringBase : MonoBehaviour
{
    private Rigidbody rb;
    private Steering[] steerings;
    public float maxAcceleration = 10f;
    public float maxAngularAcceleration = 3f;
    public float drag = 1f;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        steerings = GetComponents<Steering>();
        rb.drag = drag;
    }


    public void FixedUpdate()
    {
        Vector3 accelaration = Vector3.zero;
        float rotation = 0f;
        foreach(Steering behavior in steerings)
        {
            SteeringData steering = behavior.GetSteering(this);
            accelaration += steering.linear;
            rotation += steering.angular;
        }

        if(accelaration.magnitude > maxAcceleration)
        {
            accelaration.Normalize();
            accelaration *= maxAcceleration;
        }
        rb.AddForce(accelaration);

        if(rotation != 0)
        {
            rb.rotation = Quaternion.Euler(0, rotation, 0);
        }
    }
}
