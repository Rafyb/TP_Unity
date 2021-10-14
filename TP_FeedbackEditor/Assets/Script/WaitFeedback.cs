using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitFeedback : GameFeedback
{
    public float Timer;

    public override IEnumerator Execute(GameEvent gameEvent)
    {
        yield return new WaitForSeconds(Timer);
    }
}
