using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public abstract class treeNode 
{
    protected nodeState state;
    public nodeState _nodestate { get { return state; } }

    public abstract nodeState Evaluate();
}

public enum nodeState
{
    Run,Success,failure
}
