using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class MainEditor : MonoBehaviour
{
    public Tile selectedTile;
    public Map map;

    public static MainEditor instance;

    private Vector2Int tmp = new Vector2Int(0, 0);
    private Camera cam;
    private GridLayout grid;
    private bool locked = false;
    
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (map.Load())
        {
            Debug.Log("Loaded");
        }
        else map.FillMap();
        
        cam = Camera.main;
        cam.transform.position = new Vector3(cam.orthographicSize*cam.aspect,cam.orthographicSize,0f);

        grid = map.gameObject.GetComponent<GridLayout>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!tmp.Equals(new Vector2Int(map.width, map.height)))
        {
            tmp = new Vector2Int(map.width, map.height);
            map.FillMap();
        }
        
        if ( Input.GetMouseButton(0) && !locked)
        {
            Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
            if (!IsHoverUI(new Vector2(Input.mousePosition.x,Input.mousePosition.y)))
            {
                Vector3Int cellPosition = grid.WorldToCell(pos);
                map.PutTile(cellPosition, selectedTile);
            }
            else
            {
                locked = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.F5)) map.Save();

        if (Input.GetMouseButtonUp(0)) locked = false;
    }

    bool IsHoverUI(Vector2 position)
    {
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = position;
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, raycastResults);

        return raycastResults.Count > 0;
    }
}
