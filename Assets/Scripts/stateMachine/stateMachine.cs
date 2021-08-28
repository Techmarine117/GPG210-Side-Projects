using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stateMachine : MonoBehaviour
{
    public  float battery;
    public float maxBattery;
    public Text BatteryText;
    private int stateIndex;
    public float chaseRange;

    state currentState;

    state[] states = new state[] { new patrolling(), new moveToCharger(), new charging(), new chargerToPatrol(), new chase() };

    // Start is called before the first frame update
    void Start()
    {
        // sets state components
        foreach (var state in states)
        {
            state.Player = GameObject.FindGameObjectWithTag("Player");
            state.rumba = gameObject;
            state.Brain = gameObject.GetComponent<stateMachine>();
            state.rb = state.rumba.GetComponent<Rigidbody>();
            state.wayPoints = GameObject.FindGameObjectsWithTag("waypoint");
        }
        //gameObject.AddComponent<patrolling>();
        currentState = states[0];
        BatteryText = GameObject.Find("text").GetComponent<Text>();
        battery = maxBattery;
    }

    // Update is called once per frame
    void Update()
    {
        
        BatteryText.text = "Battery = " + battery.ToString();
        // if we are not charging then drain the battery
        if (currentState != states[2])
        {
            battery -= Time.deltaTime;
        }

        currentState.stateAction();
    }

   

    public void changeState(int stateIndex)
    {
        currentState = states[stateIndex];

    }
}
