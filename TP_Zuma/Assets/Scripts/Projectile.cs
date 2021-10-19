using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 _direction;

    public void Initialize(Vector3 direction)
    {
        _direction = direction;
    }

    void Update()
    {
        transform.position += _direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ball otherBall = collision.GetComponent<Ball>();
        if (otherBall != null)
        {
            Ball ball = GetComponent<Ball>();
            ball.enabled = true;
            ball.SetTargetNode(otherBall.GetTargetNode());

            MainGame.Instance.GetBallQueue().InsertAfter(ball, otherBall);
            
            GameObject.Destroy(this);
        }
    }
}
