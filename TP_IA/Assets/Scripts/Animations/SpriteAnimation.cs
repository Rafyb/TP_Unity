using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeAnim
{
    Idle, Walk, Attack, Hurt, Die
}

[Serializable]
public class SpriteAnimation
{
    public string name;
    public TypeAnim type;
    public float Framerate = 0.1f;
    public List<Sprite> Sprites;

}
