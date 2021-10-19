using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateFeedback : GameFeedback
{
    public GameObject Prefab;

    public override Color color()
    {
        return Color.green;
    }
    
    public override IEnumerator Execute(GameEventInstance gameEvent)
    {
        if(Prefab == null) yield break;
        Debug.Log("Test");
        GameObject.Instantiate(Prefab, gameEvent.GameObject.transform.position, Quaternion.identity);
        yield break;
    }

    public override string ToString()
    {
        if(Prefab != null) return base.ToString()+" "+Prefab.name;
        else return base.ToString();
    }
}
