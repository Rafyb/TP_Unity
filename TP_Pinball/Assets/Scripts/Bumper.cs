using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    private Vector3 forceDir = Vector3.zero;
    public float forcePower = 400;
    public ScoreScript myScoreScript;
    private float startTimer=0;
    public float activateTime = 1;
    private bool isActivate = false;
    public GameObject golight;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
        if(isActivate) if(Time.time > startTimer + activateTime){
            isActivate = false;
            golight.SetActive(false);
        }
    }

    void OnCollisionEnter( Collision other )
    {
        if(!myScoreScript.isTilted()){
        forceDir = new Vector3(other.transform.position.x -transform.position.x, 0 , other.transform.position.z -transform.position.z);
        forceDir = forceDir.normalized;
        Debug.Log("touché "+forceDir);
        other.rigidbody.AddForce(forceDir * forcePower);
        myScoreScript.AddScore(10);
        startTimer = Time.time;
        isActivate = true;
        golight.SetActive(true);
        }
    }
}
