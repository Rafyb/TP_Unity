using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISequence : AIInstructions
{
    public override NodeState Update()
    {
        if (_state != NodeState.Playing) Play();

        _state = sequence[_index].Update();

        if(_state == NodeState.Succed) _index++;
        if(_index <= sequence.Count) _state = NodeState.Playing;
        

        return _state;


    }


}
