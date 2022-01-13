using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;


public enum Difficulty
{
    Easy, Normal, Hard
}
public class Settings : MonobehaviourSingleton
{

    public Difficulty difficulty;

    private Settings(){ }

 
}
