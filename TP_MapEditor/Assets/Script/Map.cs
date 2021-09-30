using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using UnityEngine.Windows.Speech;
using Random = UnityEngine.Random;

public class Map : MonoBehaviour
{
    public int height = 0;
    public int width = 0;
    public List<Tile> baseTiles;
    private int[,] tab;
    
    private Tilemap map;

    private void Start()
    {
        map = GetComponentInChildren<Tilemap>();
    }

    public void PutTile(Vector3Int pos, Tile tile)
    {
        map.SetTile(pos, tile);
        tab[pos.x, pos.y] = GetTileIndex(tile);
    }

    public void FillMap()
    {
        map.ClearAllTiles();
        Vector3Int pos;
        tab = new int[width,height];
        for (int h = 0; h < height; h++)
        {
            for (int w = 0; w < width; w++)
            {
                pos = new Vector3Int(w, h, 0);
                Tile tile = baseTiles[(int)Random.Range(0,baseTiles.Count-1)];
                PutTile(pos,tile);
                
            }
        }
    }

    int GetTileIndex(Tile tile)
    {
        int idx;
        idx = baseTiles.IndexOf(tile);
        return idx;
    }

    public void Save()
    {
        MapInfos data = new MapInfos();
        data.height = height;
        data.width = width;
        data.tab = new int[height*width];

        int idx = 0;
        for (int h = 0; h < height; h++)
        {
            for (int w = 0; w < width; w++)
            {
                data.tab[idx] = tab[w, h];
                idx++;
            }
        }
        
        
        XmlSerializer xs = new XmlSerializer(typeof(MapInfos));
        using (var stream = new FileStream(Application.persistentDataPath+"/map.xml", FileMode.Create))
        {
            xs.Serialize(stream, data);
            print("succesfully saved " + data + " at " + Application.persistentDataPath+"/map.xml");
        }
        
    }
}
