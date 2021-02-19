using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Difficulty
{
    Easy, Normal, Hard
}
public class Settings : MonoBehaviour
{
    public static Settings Instance;

    public Difficulty difficulty;

    private Settings(){ }

    public void Awake()
    {
        if (Instance != null) Debug.LogError("Settings ne peut pas être présent plus d'une fois dans la scène");
        else Instance = this;
    }

}
