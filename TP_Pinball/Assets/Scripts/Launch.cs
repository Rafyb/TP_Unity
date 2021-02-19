using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    public Rigidbody rb;
    public float launchforce = 400.0f;
    private bool isLaunch = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && !isLaunch)
        {
            Debug.Log("Launch");
            rb.AddForce(Vector3.forward*launchforce);
        }
    }

    void OnTriggerExit(Collider other)
    {
        isLaunch = true;
    }

    void OnTriggerEnter(Collider other)
    {
        isLaunch = false;
    }
}
