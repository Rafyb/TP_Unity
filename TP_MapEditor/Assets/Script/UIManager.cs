using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class UIManager : MonoBehaviour
{
    public GameObject content;
    public GameObject buttonPrefab;

    public List<Tile> liste;
    
    void Start()
    {
        foreach (Tile tile in liste)
        {
            GameObject newButton = Instantiate(buttonPrefab) as GameObject;
            newButton.GetComponent<TileButton>().SetTile(tile);
            newButton.transform.SetParent(content.transform, false);
        }
    }

    
}
