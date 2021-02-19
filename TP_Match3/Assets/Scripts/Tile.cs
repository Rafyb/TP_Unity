using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public enum Direction { UP, DOWN, LEFT, RIGHT }
public enum TypeTiles { STAR, SQUARE, DIAMOND, PENTAGONE, HEART , EMPTY }

public class Tile : MonoBehaviour
{
    public int x, y;
    public Action<Tile, Direction> OnSwap;
    public Action<Boolean> OnEndMovement;
    public Action<Boolean> OnMovement;
    public Vector3 destination;
    public TypeTiles typeTiles;

    private bool dragging;
    private float startPosX;
    private float startPosY;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && !dragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPosX = mousePos.x;
            startPosY = mousePos.y;
            dragging = true;
        }
    }

    private void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0) && dragging)
        {

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float swipeX = mousePos.x - startPosX;
            float swipeY = mousePos.y - startPosY;

            if(Mathf.Abs(swipeX) > Mathf.Abs(swipeY))
            {
                if (swipeX > 0) OnSwap?.Invoke(this, Direction.RIGHT);

                else OnSwap?.Invoke(this, Direction.LEFT);
            }
            else
            {
                if (swipeY > 0) OnSwap?.Invoke(this, Direction.UP);

                else OnSwap?.Invoke(this, Direction.DOWN);
            }

            dragging = false;
        }
    }

    public void destroyTile()
    {
        Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(destination != Vector3.zero)
        {
            float distance = Vector3.Distance(destination, transform.position);
            OnMovement.Invoke(false);

            if (distance >= 0.1)
            {
                float destX = destination.x - transform.position.x;
                float destY = destination.y - transform.position.y;

                float posX = transform.position.x;
                float posY = transform.position.y;

                if (destX >= 0.01) posX += 5f * Time.deltaTime;
                if (destX < 0.01) posX -= 5f * Time.deltaTime;
                if (destY >= 0.01) posY += 5f * Time.deltaTime;
                if (destY < 0.01) posY -= 5f * Time.deltaTime;

                transform.position = new Vector3(posX, posY, 0.0f);
            }
            else
            {
                OnEndMovement.Invoke(false);
                transform.position = destination;
                destination = Vector3.zero;
            }
        }
    }
}
