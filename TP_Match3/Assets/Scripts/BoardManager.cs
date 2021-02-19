using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    private Board board;
    public Transform start;
    public GameObject tiles1;
    public GameObject tiles2;
    public GameObject tiles3;
    public GameObject tiles4;
    public GameObject tiles5;
    public GameObject emptyTile;
    public Boolean lockMove;
    public Boolean checkOnMove;
    public Score score;

    public GameObject newTile(int x, int y)
    {
        float posX = start.position.x + 2 * x;
        float posY = start.position.y - 2 * y;
        Vector3 thePosition = new Vector3(posX, posY, 0.0f);
        GameObject tile = tiles1;
        GameObject instantiated;

        int TAS = UnityEngine.Random.Range(1, 6);
        if (TAS == 2) tile = tiles2;
        if (TAS == 3) tile = tiles3;
        if (TAS == 4) tile = tiles4;
        if (TAS == 5) tile = tiles5;

        instantiated = Instantiate(tile, thePosition, Quaternion.identity);

        Tile noIdea = instantiated.GetComponent<Tile>();
        noIdea.x = x;
        noIdea.y = y;
        noIdea.OnSwap += OnTileSwapEvent;
        noIdea.OnEndMovement += animationEndEvent;
        noIdea.OnMovement += dontMove;


        return instantiated;
    }

    public GameObject spawnEmpty(int x, int y)
    {
        float posX = start.position.x + 2 * x;
        float posY = start.position.y - 2 * y;
        Vector3 thePosition = new Vector3(posX, posY, 0.0f);
        GameObject tile = emptyTile;
        GameObject instantiated = Instantiate(tile, thePosition, Quaternion.identity);

        Tile noIdea = instantiated.GetComponent<Tile>();
        noIdea.x = x;
        noIdea.y = y;
        noIdea.OnEndMovement += animationEndEvent;
        noIdea.OnMovement += dontMove;

        return instantiated;
    }

    private void dontMove(Boolean check)
    {
        lockMove = true;
    }

    private void animationEndEvent(Boolean check)
    {
        lockMove = false;
        if (!check && checkOnMove)
        {
            checkOnMove = false;
            board.checkMatch();
        }
    }

    private void OnTileSwapEvent(Tile tile, Direction direction)
    {
        checkOnMove = true;
        OnTileSwap(tile, direction);
    }

    public void OnTileSwap(Tile tile, Direction direction)
    {
        
        int destX = tile.x;
        int destY = tile.y;

        if (direction == Direction.RIGHT) destX++;
        if (direction == Direction.LEFT) destX--;
        if (direction == Direction.DOWN) destY++;
        if (direction == Direction.UP) destY--;

        if (destX < 0 || destX > board.lengthX - 1 || destY < 0 || destY > board.lengthY - 1 || lockMove)
        {
            return;
        }

        lockMove = true;

        GameObject tileSelected = tile.gameObject;
        GameObject tileSwapped = board.getTile(destX, destY);

        tileSwapped.GetComponent<Tile>().destination = new Vector3 (tileSelected.transform.position.x, tileSelected.transform.position.y, 0.0f);
        tile.destination = new Vector3(tileSwapped.transform.position.x, tileSwapped.transform.position.y, 0.0f);

        board.swapTile(tile.x, tile.y, destX, destY);
    }

    private void Score(Score score)
    {
        score.addScore();
    }

    // Start is called before the first frame update
    void Start()
    {
        board = new Board(GetComponent<BoardManager>());
        board.matchEvent += Score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
