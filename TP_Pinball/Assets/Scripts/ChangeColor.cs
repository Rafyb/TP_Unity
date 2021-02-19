using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Material material;
    public float timeToChange = 0.1f;
    private float timeSinceChange = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceChange += Time.deltaTime;
        if(material != null && timeSinceChange >= timeToChange){
            Color newColor = new Color(
                Random.value,
                Random.value,
                Random.value
            );
            material.color = newColor;
            material.SetColor("_EmissionColor", newColor);
            timeSinceChange = 0f;
        }
        
    }
}
