using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charging : state
{
   
    private float chargingSpeed = 5f;
    public override void stateAction()
    {
        base.stateAction();
        Debug.Log("Charging");
        if (battery >= 100f)
        {
            Brain.changeState(3);
        }
        else
        {
             rumba.GetComponent<stateMachine>().battery += Time.deltaTime * chargingSpeed;
        }

        if (distanceToPlayer() <= Brain.chaseRange)
        {
            Brain.changeState(4);
        }


    }

}
