using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeState
{
    Playing, Succed, Unsucced, Finished
}
public abstract class AINode 
{
    protected NodeState _state = NodeState.Finished;

    public abstract void Play();

    public abstract NodeState Update();
}
