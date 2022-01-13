using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player: MonoBehaviour
{
    private Rigidbody _rb;
    private Game _game;

    public void Init(Game g)
    {
        _game = g;
        _rb = GetComponent<Rigidbody>();

        _game.controller.OnJump += Jump;
    }

    public void Destroy()
    {
        _game.controller.OnJump -= Jump;
        Destroy(gameObject);
    }

    public void Move()
    {
        
    }

    public void Jump()
    {
        _rb.velocity = Vector3.zero;
        _rb.AddForce(Vector3.up*5,ForceMode.Impulse);
    }
}

