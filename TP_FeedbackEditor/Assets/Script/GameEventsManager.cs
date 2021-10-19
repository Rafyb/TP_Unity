using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    private static GameEventsManager s_instance;

    public List<GameEvent> GameEvents;

    private static Dictionary<string, GameEvent> _events;
    
    

    void Awake()
    {
        s_instance = this;
        _events = new Dictionary<string, GameEvent>(GameEvents.Count);

        foreach (GameEvent gameEvent in GameEvents)
        {
            _events.Add(gameEvent.Name, gameEvent);
        }
    }

    public static void PlayEvent(string eventName, GameObject gameObject)
    {
        //Debug.Log(_events[eventName]);
        GameEventInstance gameEvent = new GameEventInstance();
        gameEvent.GameEvent = _events[eventName];
        gameEvent.GameObject = gameObject;

        s_instance.StartCoroutine(gameEvent.Execute());
    }
    

 
}
