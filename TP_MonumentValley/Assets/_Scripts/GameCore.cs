using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameCore : MonoBehaviour
{
    public static GameCore Instance;
    public GameObject player;
    public Cube startCube;
    private Animator anim;

    public float speed = 2f;
    public bool isMoving = false;

    private Cube _currentCube;
    private List<Cube> _path;
    private List<Cube> _visited = new List<Cube>();


    private GameCore() { }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        anim = player.GetComponent<Animator>();
        player.transform.position = startCube.transform.position + startCube.TopOffset;
        _currentCube = startCube;
    }

    public void GeneratePath(Cube destination)
    {
        _visited.Clear();
        _path = GetPath(_currentCube,destination);
        _path.Reverse();
    }

    private List<Cube> GetPath(Cube here, Cube dest)
    {
        _visited.Add(here);
        List<Cube> path = new List<Cube>();

        if(here == dest)
        {
            path.Add(here);
            return path;
        }

        foreach(Cube n in here.Neighbours)
        {
            if (_visited.Contains(n)) continue;

            path = GetPath(n, dest);
            if(path != null)
            {
                path.Add(here);
                return path;
            }
        }

        return null;
    }

    public void Move()
    {
        anim.SetBool("walking", true);
        isMoving = true;

        _currentCube = _path[0];
        _path.RemoveAt(0);

        // Calcul destination
        Vector3 destination = _currentCube.transform.position + _currentCube.TopOffset;
        // Calcul direction
        Vector3 direction = (destination - player.transform.position).normalized;
        // Calcul distance
        float distance = Vector3.Distance(player.transform.position, destination);

        // Oriente le perso
        player.transform
            .DORotateQuaternion(Quaternion.LookRotation(-direction, Vector3.up), 0.3f);

        // BOuge le perso
        player.transform
            .DOMove(destination, distance / speed)
            .SetEase(Ease.Linear)
            .OnComplete( ()=> {
                if (_path.Count == 0)
                {
                    anim.SetBool("walking", false);
                    isMoving = false;
                } else {
                    Move();
                }

            } );

        
    }


    void Update()
    {
        
    }
}
