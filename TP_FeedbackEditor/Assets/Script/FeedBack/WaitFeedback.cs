using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitFeedback : GameFeedback
{
    public float Timer;

    
    public override IEnumerator Execute(GameEventInstance gameEvent)
    {
        yield return new WaitForSeconds(Timer);
    }
    
    public override string ToString()
    {
        return base.ToString()+" "+Timer;
    }
    
    public override Color color()
    {
        return Color.blue;
    }
}
