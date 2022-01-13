using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public GameObject menu;
    
    public void SetDifficultNormal()
    {
 
        Settings.Instance.GetComponent<Settings>().difficulty = Difficulty.Normal;
        menu.SetActive(false);
    }

    public void SetDifficultHard()
    {
        Settings.Instance.GetComponent<Settings>().difficulty = Difficulty.Hard;
        menu.SetActive(false);
    }
}
