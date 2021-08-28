using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller))]
[RequireComponent(typeof(movementconverter))]

public class AiController : MonoBehaviour
{
    public  GameObject[] wayPoints;
    public  float speed;
    GameObject target;
    Controller controller;
    // Start is called before the first frame update
    void Start()
    {
      controller =  gameObject.GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
       // patrol();
        // checking if the distance to the target is lower than a certain amount,
        // if yes, we call get target to get a new target
        //if (distanceToTarget() <= 1.5f)
        //{
        //    getNewTarget();
        //}
    }

    private void Inputs()
    {
        char[] Chars = new char[4] {' ',' ',' ',' '};
        if (Input.GetKey(KeyCode.W))
        {
            Chars[0] = 'W';
            
        }

        if (Input.GetKey(KeyCode.S))
        {
            Chars[1] = 'S';
        }

        if (Input.GetKey(KeyCode.A))
        {
            Chars[2] = 'A';
        }

        if (Input.GetKey(KeyCode.D))
        {
            Chars[3] = 'D';
        }
       
        string message = new string(Chars);
        Debug.Log(message);
        controller.Move(message,speed);

    }

    //public void patrol()
    //{
    //    if (!target)
    //    {
    //        getNewTarget();

    //    }

    //    // calculate direction towards the target 
    //    Vector3 dir = target.transform.position - transform.position;
    //    // Normalizeing dir to return a unit vector3
    //    dir.Normalize();
    //    dir = dir * speed;
    //    controller.Move(dir);

    //}

    //public float distanceToTarget()
    //{
    //    float dist = Vector3.Distance(transform.position, target.transform.position);
    //    return dist;
    //}

    //public void getNewTarget()
    //{
    //    // sets the target to a Random element  of  the waypoint array
    //    target = wayPoints[Random.Range(0, wayPoints.Length)];
    //}

}