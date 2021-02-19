using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text;
    public int score;

    public void addScore()
    {
        score++;
        text.text = "Score : " + score.ToString().PadLeft(2, '0');
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        text.text = "Score : " + score.ToString().PadLeft(2, '0');
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
