using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class softTilt : MonoBehaviour
{
    public Rigidbody ball;
    public float softForce = 100f;
    private bool activable = true;
    // Start is called before the first frame update
    public float tilstAdd = 40;
    public float tiltMax = 100;
    public float tiltDecrease = 1;
    private float currentTilt = 0;
    public ScoreScript sc;
    void Start()
    {
        ball = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTilt >= tiltMax){
            sc.setTilt(true);
            currentTilt = 0;
        }
        if(currentTilt > 0){
            currentTilt -= tiltDecrease;
        }
        if(Input.GetAxis("Horizontal") < 0){
            if(activable){
                activable = false;
                ball.AddForce(Vector3.left * softForce);
                currentTilt += tilstAdd;
            }
        } else if(Input.GetAxis("Horizontal") > 0){
            if(activable){
                activable = false;
                ball.AddForce(Vector3.right * softForce);
                currentTilt += tilstAdd;
            }
        } else {
            activable = true;
        }
        
    }
}
