using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeColor
{
    Red,
    Blue,
    Green,
    Yellow
}
public class Ball : MonoBehaviour
{
    private int _idxTargetNode;
    //private List<Ball> _collideWith = new List<Ball>();
    
    public float speed = 2;
    [HideInInspector] public int idx;
    public TypeColor type;

    public void UpdateMove(Transform[] path)
    {
        Vector3 target = path[_idxTargetNode].transform.position;
        Vector3 direction = target - transform.position;

        float moveStep = speed * Time.deltaTime;
        float distance = Vector3.Distance(target, transform.position);

        while ( moveStep > distance)
        {
            _idxTargetNode++;

            if (_idxTargetNode >= path.Length)
            {
                Destroy(gameObject);
                return;
            }

            target = path[_idxTargetNode].transform.position;
            moveStep = speed * Time.deltaTime;
            distance = Vector3.Distance(target, transform.position);
            direction = target - transform.position;
        }
        
        direction.Normalize();
        transform.position += moveStep * direction;

        Ball ballAfter = MainGame.Instance.GetBallQueue().GetBallAfter(this);
        if (ballAfter != null)
        {
            if (Vector3.Distance(transform.position, ballAfter.transform.position) < MainGame.Instance.size)
            {
                ballAfter.UpdateMove(path);
            }
        }
    }
    

    public void UpdateMove(Transform[] path,float distance)
    {
        while (distance > 0)
        {
            distance -= speed * Time.deltaTime;
            UpdateMove(path);
        }
    }
    
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ball otherBall = collision.GetComponent<Ball>();
        if (otherBall != null)
        {
            _collideWith.Add(otherBall);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        Ball otherBall = collision.GetComponent<Ball>();
        if (otherBall != null)
        {
            _collideWith.Remove(otherBall);
        }
    }*/


    public void SetTargetNode(int idxTargetNode)
    {
        _idxTargetNode = idxTargetNode;
    }

    public int GetTargetNode()
    {
        return _idxTargetNode;
    }
}
