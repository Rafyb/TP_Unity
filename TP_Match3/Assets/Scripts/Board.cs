using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    private GameObject[,] board;
    private BoardManager manager;
    public Action<int> matchEvent;
    public int lengthX = 8;
    public int lengthY = 5;

    public Board(BoardManager manager)
    {
        this.manager = manager;
        board = new GameObject[lengthX, lengthY];
        for (int i = 0; i < lengthX; i++)
        {
            for (int j = 0; j < lengthY; j++)
            {
                board[i, j] = manager.newTile(i, j);
            }
        }
    }

    public GameObject getTile(int x, int y)
    {
        return board[x, y];
    }

    public void swapTile(int x1, int y1, int x2, int y2)
    {
        GameObject tile1 = board[x1, y1];
        GameObject tile2 = board[x2, y2];

        board[x1, y1] = tile2;
        board[x2, y2] = tile1;

        tile2.GetComponent<Tile>().x = x1;
        tile1.GetComponent<Tile>().x = x2;
        tile2.GetComponent<Tile>().y = y1;
        tile1.GetComponent<Tile>().y = y2;
    }

    public void checkDead()
    {
        Boolean isDead = false;

        for (int i = 0; i < lengthX; i++)
        {
            for (int j = lengthY - 1; j >= 0; j--)
            {
                if (board[i, j].GetComponent<Tile>().typeTiles == TypeTiles.EMPTY)
                {
                    if (j == 0)
                    {
                        board[i, j].GetComponent<Tile>().destroyTile();
                        board[i, j] = manager.newTile(i, j);
                        checkDead();
                        return;
                    }

                    isDead = true;

                    swapTile(i, j, i, j - 1);
                    float posX = manager.start.position.x + 2 * i;
                    float posY = manager.start.position.y - 2 * (j + 1);
                    float posY2 = manager.start.position.y - 2 * j;

                    board[i, j-1].GetComponent<Tile>().destination = new Vector3(posX, posY, 0.0f);
                    board[i, j].GetComponent<Tile>().destination = new Vector3(posX, posY2, 0.0f);

                }
            }
        }
        if (isDead)
        {
            checkDead();
        }
        else
        {
            checkMatch();
        }
    }


    public void checkMatch()
    {
        for (int i = 0; i < lengthX; i++)
        {
            for(int j = 0; j < lengthY; j++)
            {
                checkTiles(i, j);
            }
        }
    }

    private void checkTiles(int posX, int posY)
    {
        TypeTiles currType = board[posX, posY].GetComponent<Tile>().typeTiles;
        int newX = posX;
        int newY = posY;
        int counter = 1;
        List<Tile> tileList = new List<Tile>();
        Boolean isDestroyed = false;

        while (--newX >= 0 && currType == board[newX, newY].GetComponent<Tile>().typeTiles)
        {
            counter++;
            tileList.Add(board[newX, newY].GetComponent<Tile>());
        }

        newX = posX;
        newY = posY;

        while (++newX < lengthX && currType == board[newX, newY].GetComponent<Tile>().typeTiles)
        {
            counter++;
            tileList.Add(board[newX, newY].GetComponent<Tile>());
        }

        if(counter >= 3)
        {
            isDestroyed = true;
            foreach (Tile toDelete in tileList)
            {
                board[toDelete.x, toDelete.y] = manager.spawnEmpty(toDelete.x, toDelete.y);
                toDelete.destroyTile();
            }
        }

        counter = 1;
        tileList.Clear();
        newX = posX;
        newY = posY;

        while (--newY >= 0 && currType == board[newX, newY].GetComponent<Tile>().typeTiles)
        {
            counter++;
            tileList.Add(board[newX, newY].GetComponent<Tile>());
        }

        newX = posX;
        newY = posY;

        while (++newY < lengthY && currType == board[newX, newY].GetComponent<Tile>().typeTiles)
        {
            counter++;
            tileList.Add(board[newX, newY].GetComponent<Tile>());
        }

        if (counter >= 3)
        {
            isDestroyed = true;
            foreach (Tile toDelete in tileList)
            {
                board[toDelete.x, toDelete.y] = manager.spawnEmpty(toDelete.x, toDelete.y);
                toDelete.destroyTile();
            }
        }

        if(isDestroyed)
        {
            board[posX, posY].GetComponent<Tile>().destroyTile();
            board[posX, posY] = manager.spawnEmpty(posX, posY);
            matchEvent?.Invoke(1);
            checkDead();
            return;
        }
    }
}
