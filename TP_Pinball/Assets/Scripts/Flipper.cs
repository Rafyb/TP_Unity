using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    public float startPosition = 0f;
    public float upPosition = 45f;
    public float hitForce = 500;
    public float flipperDamper = 150f;
    HingeJoint myHinge;
    public string buttonName;
    public ScoreScript sc;
    // Start is called before the first frame update
    void Start()
    {
        myHinge = GetComponent<HingeJoint>();
        myHinge.useSpring = true;
    }

    // Update is called once per frame
    void Update()
    {
        JointSpring mySpring = new JointSpring();
        mySpring.spring = hitForce;
        mySpring.damper = flipperDamper;
        if(!sc.isTilted()){
            if(Input.GetButton(buttonName)){
                Debug.Log("fef");
                mySpring.targetPosition = upPosition;
            } else {
                mySpring.targetPosition = startPosition;
            }
            myHinge.spring = mySpring;
            myHinge.useLimits = true;
        }
    }
}
