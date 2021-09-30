using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TileButton : MonoBehaviour
{
    public Tile tile;
    public Image img;

    public void SetTile(Tile t)
    {
        tile = t;
        img.sprite = t.sprite;
    }

    public void OnClick()
    {
        MainEditor.instance.selectedTile = tile;
    }
    
    
}
