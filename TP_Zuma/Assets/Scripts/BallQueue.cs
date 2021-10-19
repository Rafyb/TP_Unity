using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallQueue
{
    public List<Ball> balls = new List<Ball>();

    public void Update(Transform[] path)
    {
        if(balls.Count > 0) balls[balls.Count-1].UpdateMove(path);
        
    }

    public void InsertAfter(Ball newBall, Ball previousBall)
    {
        int index = balls.IndexOf(previousBall);
        if (index == -1)throw new System.Exception("Can't find the ball");

                    
        balls.Insert(index+1, newBall);

        newBall.transform.position = previousBall.transform.position;

        for (int i = 0; i < balls.Count; i++)
        {
            balls[i].idx = i;
        }

        for (int i = 0; i < index; i++)
        {
            balls[i].UpdateMove(MainGame.Instance.path,MainGame.Instance.size);
        }
    }

    public Ball GetBallAfter(Ball ball)
    {
        int idx = balls.IndexOf(ball);

        if (idx == -1)
        {
            throw new System.Exception("Can't find the ball");
        }

        if (idx == 0)
        {
            return null;
        }
        else
        {
            return balls[idx - 1];
        }
    }
}
