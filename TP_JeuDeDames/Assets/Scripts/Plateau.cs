using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plateau : MonoBehaviour
{
    public GameObject prefabWhite;
    public GameObject prefabBlack;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Vector3 position = new Vector3(i*0.32f, j * 0.32f, 1);
                if ( (i+j)%2 == 0) Instantiate(prefabBlack, position, Quaternion.identity);
                else Instantiate(prefabWhite, position, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
