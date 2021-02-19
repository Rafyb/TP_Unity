using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAttack : ActionToDo
{
    DecisionBrain _brain;

    public ActionAttack(DecisionBrain b)
    {
        _brain = b;
    }

    public override void Play()
    {
        state = NodeState.Playing;
        _brain.entity.PlayAction("Attack");
        state = NodeState.Succed;
    }
}
