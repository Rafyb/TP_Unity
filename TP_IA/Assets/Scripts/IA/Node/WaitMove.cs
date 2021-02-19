using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitMove : ConditionToDo
{
    DecisionBrain _brain;
    float _timerMove;

    public WaitMove(DecisionBrain b)
    {
        _brain = b;
    }

    public override bool Play()
    {
        if(_timerMove >= _brain.beforeMove)
        {
            _timerMove = 0f;
            //_timerMove = Random.Range(0f, 2f);
            return true;
        }
        _timerMove += Time.deltaTime;
        return false;
    }
}
