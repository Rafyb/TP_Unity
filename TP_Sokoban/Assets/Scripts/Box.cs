using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Box : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Move(Vector2 direction)
    {
        if (BoxBlocked(transform.position, direction))
        {
            return false;
        }
        else
        {
            transform.Translate(direction);
            //TestForOnCross();
            return true;
        }
        
    }

    bool BoxBlocked(Vector3 position, Vector2 direction)
    {
        Vector2 newPos = new Vector2(position.x, position.y) + direction;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var wall in walls)
        {
            if ((int)(wall.transform.position.x) == (int)(newPos.x) && (int)(wall.transform.position.y) == (int)(newPos.y))
            {
                return true;
            }
        }
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (var box in boxes)
        {
            if ((int)(box.transform.position.x) == (int)(newPos.x) && (int)(box.transform.position.y) == (int)(newPos.y))
            {
                return true;
            }
        }
        return false;
    }

}
