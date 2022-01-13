using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdSpawn : Command
{
    public float Time;
    public override void Execute(Game g)
    {
        g.OnDie.Invoke();
        
    }
}
