using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
    private Text scoreT;

    private bool isTilt = false;

    private static int multiplicateur = 1;
    // Start is called before the first frame update
    void Start()
    {
        scoreT = GetComponent<Text>();
    }

    public void AddMultiplicateur(int bonus){
        multiplicateur += bonus;
    }

    public int GetMultiplicateur(){
        return multiplicateur;
    }

    public void AddScore(int scoreToAdd){
        scoreValue += (scoreToAdd * multiplicateur );
    }

    // Update is called once per frame
    void Update()
    {
        scoreT.text = "Score : "+scoreValue;
    }

    public void setTilt(bool b){
        isTilt = b;
    }

    public bool isTilted(){
        return isTilt;
    }
}
