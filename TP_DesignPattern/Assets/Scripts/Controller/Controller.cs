using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct KeyBinding
{
    public KeyCode key;
    public CommandType command;
}


public class Controller : MonoBehaviour
{
   public List<KeyBinding> keyBinding;
   private Dictionary<KeyCode, Command> _keys;
   private Game _game;
   
   public Action OnJump;


   public void Init(Game g)
   {
       _game = g;
       _keys = new Dictionary<KeyCode, Command>();

       ControllerFactory factory = new ControllerFactory();
       
       foreach (KeyBinding pair in keyBinding)
       {
           Command cmd = factory.Create(pair.command);
           _keys.Add(pair.key,cmd);
           
       }
   }
   

   private void Update()
   {
       
       foreach (KeyValuePair<KeyCode,Command> pair in _keys)
       {
           if(Input.GetKeyDown(pair.Key)) pair.Value.Execute(_game);
       }
       
   }
}
