using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonobehaviourSingleton : MonoBehaviour
{
    public static GameObject Instance;

    private void Awake()
    {
        if (Instance != null) throw new Exception("Une instance de la classe existe deja");
        
        Instance = this.gameObject;
    }
    
}
