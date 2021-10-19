using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameEvent")]
[Serializable]
public class GameEvent : ScriptableObject
{
    public string Name;
    [SerializeReference]
    public List<GameFeedback> Feedbacks = new List<GameFeedback>();
    
}
