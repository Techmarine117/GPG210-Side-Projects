using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToCharger : state
{
    public GameObject target;

    public override void stateAction()
    {
        base.stateAction();
        getTarget();
        Debug.Log("Moving to Charger");

        // setting the velocity to zero when we reach the charging station then changing the state
        if (distanceToTarget() <= 1f)
        {
            rb.velocity = Vector3.zero;
            Brain.changeState(2);
        }
        else
        {
            Vector3 dir = target.transform.position - rumba.transform.position;
            rb.AddForce(dir.normalized * speed * Time.deltaTime, ForceMode.Impulse);

        }


    }


   
    public float distanceToTarget()
    {
        float dist = Vector3.Distance(rumba.transform.position, target.transform.position);
        return dist;
    }

    public void getTarget()
    {
        target = GameObject.Find("chargingstation");
    }
}
