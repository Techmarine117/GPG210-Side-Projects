using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase : state
{
    
  

    public override void stateAction()
    {

        base.stateAction();
        ChaseAction();
        if (battery <= 20f)
        {
            Brain.changeState(1);
        }
        if (distanceToPlayer() > Brain.chaseRange)
        {
            Brain.changeState(0);
        }


    }
    

    private void ChaseAction()
    {
        // calculate direction towards the target
        Vector3 dir = Player.transform.position - rumba.transform.position;
        // we are normalizing the direction vector, in order to get a unit vector out of the direction where the magnitude is always = 1
        rb.AddForce(dir.normalized * speed * Time.deltaTime, ForceMode.Impulse);
    }
}
