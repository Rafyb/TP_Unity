using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using UnityEngine;
using Random = UnityEngine.Random;

public class MainGame : MonoBehaviour
{
    public Transform[] path;
    public GameObject[] prefabBalls;
    public int count;
    public GameObject frog;
    public float size = 0.7f;
    
    private BallQueue _ballQueue = new BallQueue();

    public static MainGame Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _ballQueue = new BallQueue();

        for (int i = 0; i < count; i++)
        {
            GameObject prefabBall = prefabBalls[Random.Range(0, prefabBalls.Length-1)];
            GameObject go = GameObject.Instantiate(prefabBall, path[0].position, Quaternion.identity);
            Ball ball = go.GetComponent<Ball>();
            _ballQueue.balls.Add(ball);
            ball.idx = i;
            ball.UpdateMove(path, size * (float)(count-i));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        _ballQueue.Update(path);

        Vector3 worldMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = worldMouse - frog.transform.position;
        direction.z = 0;

        float angle = Mathf.Atan2(direction.y, direction.x);
        
        frog.transform.localRotation = Quaternion.Euler(0,0,angle * Mathf.Rad2Deg + 90);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = GameObject.Instantiate(prefabBalls[0]);
            go.transform.position = frog.transform.position;
            go.GetComponent<Ball>().enabled = false;
            
            direction.Normalize();
            go.AddComponent<Projectile>().Initialize(direction);
        }

    }

    public BallQueue GetBallQueue()
    {
        return _ballQueue;
    }
}
