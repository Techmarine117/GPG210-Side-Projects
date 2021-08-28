using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chargerToPatrol : state
{
    public GameObject target;

    public override void stateAction()
    {
        base.stateAction();
        getTarget();
        Debug.Log("ChargerToPatrolling");
        if (distanceToTarget() <= 1f)
        {
            rb.velocity = Vector3.zero;
            Brain.changeState(0);
        }
        else
        {
            Vector3 dir = target.transform.position - rumba.transform.position;
            rb.AddForce(dir.normalized * speed * Time.deltaTime, ForceMode.Impulse);

        }
        if (distanceToPlayer() <= Brain.chaseRange)
        {
            Brain.changeState(4);
        }


    }



    public float distanceToTarget()
    {
        float dist = Vector3.Distance(rumba.transform.position, target.transform.position);
        return dist;
    }

    public void getTarget()
    {
        target = GameObject.Find("wayPoint1");
    }
}
