using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISelector : AIInstructions
{
    public override NodeState Update()
    {
        if (_state != NodeState.Playing) Play();

        _state = sequence[_index].Update();

        if (_state == NodeState.Succed)_state = NodeState.Finished;
        if (_state == NodeState.Unsucced) _index++;
        if (_index <= sequence.Count) _state = NodeState.Playing;


        return _state;


    }
}
