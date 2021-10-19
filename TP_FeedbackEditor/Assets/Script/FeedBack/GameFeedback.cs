using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameFeedback
{
    public virtual Color color()
    {
        return Color.white;
    }
    
    public virtual IEnumerator Execute(GameEventInstance gameEvent)
    {
        yield break;
    }
}
