using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdJump : Command
{

    public override void Execute(Game g)
    {
        g.controller.OnJump?.Invoke();
    }
}
