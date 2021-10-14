using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameEvent")]
[Serializable]
public class GameEvent : ScriptableObject
{
    public GameObject GameObject;
    public string Name;
    [SerializeReference]
    public List<GameFeedback> Feedbacks = new List<GameFeedback>();

    public IEnumerator Execute()
    {
        foreach (GameFeedback gf in Feedbacks)
        {
            yield return gf.Execute(this);
        }
    }
}
