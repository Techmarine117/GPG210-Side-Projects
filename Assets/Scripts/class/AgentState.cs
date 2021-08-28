using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AgentState : MonoBehaviour
{
    public abstract void StateUpdate(Agent owner);
}
