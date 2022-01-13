using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CommandType
{
    RESPAWN, JUMP, MOVE, SHOOT
}
public class Command 
{

    public virtual void Execute(Game g)
    {
        throw new Exception("Command not implemented");
    }
}
