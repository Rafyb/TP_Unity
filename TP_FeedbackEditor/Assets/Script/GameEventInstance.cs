using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class GameEventInstance
    {
        public GameObject GameObject;
        public GameEvent GameEvent;

        public IEnumerator Execute()
        {
            foreach (GameFeedback gf in GameEvent.Feedbacks)
            {
                yield return gf.Execute(this);
            }
        }
    }
