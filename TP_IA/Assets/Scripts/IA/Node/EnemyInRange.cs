using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInRange : ConditionToDo
{
    DecisionBrain _brain;


    public EnemyInRange(DecisionBrain b)
    {
        _brain = b;
    }

    public override void Play()
    {
        state = NodeState.Playing;
        if (Vector3.Distance(_brain.entity.transform.position, Vector3.zero) < _brain.attackRange) state = NodeState.Succed;
        else state = NodeState.Unsucced;
    }

}
