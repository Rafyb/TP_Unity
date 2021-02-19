using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public GameObject balle;
    private Vector3 startPositionBalle;
    public ScoreScript sc;
    // Start is called before the first frame update
    void Start()
    {
        startPositionBalle = balle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        balle.transform.position = startPositionBalle;
        Rigidbody myRigidbody = balle.GetComponent<Rigidbody>();
        myRigidbody.velocity = Vector3.zero;
        sc.setTilt(false);
    }
}
