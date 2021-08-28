using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public Transform[] nodes;
    AgentState currentState;
    public float Speed;
    public float Battery;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentState.StateUpdate(this);

    }

    public void nextState(AgentState newState)
    {
        currentState = newState;
    }
}
