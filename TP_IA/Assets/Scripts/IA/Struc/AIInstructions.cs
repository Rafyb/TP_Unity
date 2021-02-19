using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInstructions : AINode
{

    protected List<AINode> sequence = new List<AINode>();
    protected int _index = 0;

    public override void Play()
    {
        _state = NodeState.Playing;
        _index = 0;
    }

    public override NodeState Update()
    {
        throw new System.NotImplementedException();
    }

    public void AddNode(AINode node)
    {
        sequence.Add(node);
    }

}
