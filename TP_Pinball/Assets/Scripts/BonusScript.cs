using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusScript : MonoBehaviour
{
    private Text bonusT;
    public ScoreScript score;
    // Start is called before the first frame update
    void Start()
    {
        bonusT = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(score.GetMultiplicateur() > 1 )bonusT.text = "BONUS\nX"+score.GetMultiplicateur();
    }
}
