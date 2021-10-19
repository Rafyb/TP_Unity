using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public GameObject prefab;
        
    // Start is called before the first frame update
    void Start()
    {
        GameObject a = GameObject.Instantiate(prefab,new Vector3(-5,0,0),Quaternion.identity);
        GameEventsManager.PlayEvent("SpawnEffect", a);
        
        GameObject b = GameObject.Instantiate(prefab,new Vector3(5,0,0),Quaternion.identity);
        GameEventsManager.PlayEvent("SpawnEffect", b);
    }

    
}
