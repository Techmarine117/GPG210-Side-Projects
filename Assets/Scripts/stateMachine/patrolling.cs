using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolling : state
{
    public GameObject target;
    
    public override void stateAction()
    {
        base.stateAction();
        Debug.Log("Patrolling");
        patrol();
        if(distanceToTarget() <= 1.5f)
        {
            getTarget();
        }
        if(battery <= 20f)
        {
            //state index 1 is refering to the the second element of our states array which would return MovetoCharger
            Brain.changeState(1);
        }

        if (distanceToPlayer() <= Brain.chaseRange)
        {
            Brain.changeState(4);
        }

    }


    public void patrol()
    {
        if (!target)
        {
            getTarget();

        }
      // calculate direction towards the target
        Vector3 dir = target.transform.position - rumba.transform.position;
        // we are normalizing the direction vector, in order to get a unit vector out of the direction where the magnitude is always = 1
        rb.AddForce(dir.normalized * speed * Time.deltaTime,ForceMode.Impulse);
    }

    public float distanceToTarget()
    {
        float dist = Vector3.Distance(rumba.transform.position, target.transform.position);
        return dist;
    }

    // sets the target to be a random waypoint from the array of waypoints
    public void getTarget()
    {
        target = wayPoints[Random.Range(0, wayPoints.Length)];
    }

    //adding a the new state and deleting the current state ( script ) from the gameobject
    //public void changeState()
    //{
        
    //    //gameObject.AddComponent<moveToCharger>();
    //    //patrolling pat = gameObject.GetComponent<patrolling>();
    //    //Destroy(pat);
    //}
}
