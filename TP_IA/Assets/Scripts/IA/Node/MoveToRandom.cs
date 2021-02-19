using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToRandom : ActionToDo
{
    DecisionBrain _brain;

    public MoveToRandom(DecisionBrain b)
    {
        _brain = b;
    }

    public override void Play()
    {
        state = NodeState.Playing;
        _brain.entity.Move(RandomPosition());
        return true;
    }

    public Vector3 RandomPosition()
    {
        Vector3 initPos = _brain.entity.GetInitialPos();
        float posX = Random.Range(initPos.x, initPos.x - _brain.disanceMaxMove);
        float posY = Random.Range(initPos.y, initPos.y - _brain.disanceMaxMove);
        Vector3 pos = new Vector3(posX, posY, 0);
        return pos;
    }
}
