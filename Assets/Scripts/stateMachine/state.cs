using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class state 
{
    public Rigidbody rb;
    public GameObject[] wayPoints;
    public GameObject chargingStation;
    public GameObject rumba;
    public float speed = 15f;
    public float battery;
    public stateMachine Brain;
    public GameObject Player;
  public virtual void stateAction()
    {
        battery = rumba.GetComponent<stateMachine>().battery;
    }

    public virtual float distanceToPlayer()
    {
        float dist = Vector3.Distance(rumba.transform.position, Player.transform.position);
        return dist;
    }
    


}
