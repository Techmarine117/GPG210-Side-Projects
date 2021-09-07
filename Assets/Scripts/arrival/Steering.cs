using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Steering : MonoBehaviour
{
    public abstract SteeringData GetSteering(SteeringBase steeringbase);

    public class SteeringData
    {
        public Vector3 linear;
        public float angular;

        public SteeringData()
        {
            linear = Vector3.zero;
            angular = 0f;
        }
        
    
    }
}
