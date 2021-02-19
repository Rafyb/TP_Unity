using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Entity _player;
    bool _isMoving;

    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Entity>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Move();

            if (!_isMoving) _player.PlayAction("Walk");
            _isMoving = true;
        } else {
            if (_isMoving) _player.PlayAction("Default");
            _isMoving = false;
        }
        
    }

    private void Move()
    {
        Vector3 currentPosition = _player.transform.position;

        // On récupere touches appuyées
        currentPosition.x += Input.GetAxis("Horizontal");
        currentPosition.y += Input.GetAxis("Vertical");

        _player.Move(currentPosition);


    }
}
