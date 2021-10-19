using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeFeedback : GameFeedback
{
    public float Timer;
    public override IEnumerator Execute(GameEventInstance gameEvent)
    {
        //yield return null;
        Camera.main.clearFlags = CameraClearFlags.Nothing;
        yield return new WaitForSeconds(Timer);
        Camera.main.cullingMask = 0;
        
    }

    public override Color color()
    {
        return Color.black;
    }

    public override string ToString()
    {
        return base.ToString() + " " + Timer;
    }
}
