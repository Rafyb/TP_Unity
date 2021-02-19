using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cible : MonoBehaviour
{
    public ScoreScript myScoreScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter( Collision other )
    {
        myScoreScript.AddMultiplicateur(1);
        this.gameObject.SetActive(false);
    }
}
