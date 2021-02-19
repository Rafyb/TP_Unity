using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool readyForInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput.Normalize();
        if (moveInput.sqrMagnitude > 0.5)
        {
            if (readyForInput)
            {
                readyForInput = false;
                Move(moveInput);
            }
        }
        else
        {
            readyForInput = true;
        }
    }

    public bool Move(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) < 0.5)
        {
            direction.x = 0;
        } else
        {
            direction.y = 0;
        }
        direction.Normalize();
        if (Blocked(transform.position, direction))
        {
            return false;
        } else
        {
            transform.Translate(direction);
            return true;
        }
    }

    bool Blocked(Vector3 position, Vector2 direction)
    {
        Vector2 newPos = new Vector2(position.x, position.y) + direction;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach(var wall in walls)
        {
            UnityEngine.Debug.Log((int) (wall.transform.position.x));
            UnityEngine.Debug.Log((int) (newPos.x));

            if ((int) (wall.transform.position.x) == (int) (newPos.x) && (int) (wall.transform.position.y) == (int) (newPos.y))
            {
                return true;
            }
        }
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (var box in boxes)
        {
            if ((int) (box.transform.position.x) == (int) (newPos.x) && (int) (box.transform.position.y) == (int) (newPos.y))
            {
                Box bx = box.GetComponent<Box>();
                if(bx && bx.Move(direction))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        return false;
    }
}
