using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private Dictionary<Vector2Int, Tile> _tiles;
    public int firstTileX;
    public int firstTileY;
    public int _height;
    public int _width;
    public int _changeDirCount = 10;
    private Vector2 direction;
    [SerializeField] private List<Tile> moveTiles;
    private Tile flagTile;


    private Vector2Int _upDir = Vector2Int.up;
    private Vector2Int _downDir = Vector2Int.down;
    private Vector2Int _rightDir = Vector2Int.right;
    private Vector2Int _leftDir = Vector2Int.left;


    enum Direction { Up, Down, Right, Left };
    private Direction[,] twoDim = new Direction[,] { { Direction.Up, Direction.Down }, { Direction.Left, Direction.Right } };



    private void OnEnable()
    {
        GameManager.AllTilesPos += GameManager_AllTilesPos;
        GameManager.LevelSize += GameManager_LevelSize;


    }

    private void GameManager_LevelSize(int arg1, int arg2)
    {
        _height = arg1;
        _width = arg2;
    }

    private void GameManager_AllTilesPos(Dictionary<Vector2Int, Tile> obj)
    {
        _tiles = obj;
    }
    private void OnDisable()
    {
        GameManager.AllTilesPos -= GameManager_AllTilesPos;
        GameManager.LevelSize -= GameManager_LevelSize;

    }
    private void Start()
    {
        StartCoroutine(Test());
    }
    private void Update()
    {

    }

    IEnumerator Test()
    {
        yield return new WaitForFixedUpdate();
        firstTileX = Random.Range(1, _width - 1);
        firstTileY = Random.Range(1, _height - 1);

        flagTile = _tiles[new Vector2Int(firstTileX, firstTileY)];

        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                Vector2Int pos = new Vector2Int(j, i);
                _tiles[pos].IsBlock = true;

            }
        }


        // direction = Random.insideUnitCircle.normalized;


        Direction currentDir = (Direction)Random.Range(0, 4);
        int count;
        currentDir = Direction.Up;

        for (int i = 0; i < _changeDirCount; i++)
        {
            switch (currentDir)
            {
                case Direction.Up:


                    while (flagTile._upNeighbor != null && !flagTile._upNeighbor.isCorner && !flagTile._upNeighbor.IsBlockDir)
                    {
                        moveTiles.Add(flagTile._upNeighbor);
                        flagTile = flagTile._upNeighbor;
                    }

                    if (moveTiles.Count != 0 && moveTiles[0]._downNeighbor != null)
                    {
                        moveTiles[0]._downNeighbor.IsBlockDir = true;

                    }

                    count = Random.Range(1, moveTiles.Count);


                    for (int j = 0; j < count; j++)
                    {
                        moveTiles[j].gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;


                    }

                    if (moveTiles[count - 1]._upNeighbor != null && !moveTiles[count - 1]._upNeighbor.IsBlockDir)
                    {
                        moveTiles[count - 1]._upNeighbor.IsBlockDir = true;

                    }

                    if (moveTiles[count - 1] != null)
                    {
                        flagTile = moveTiles[count - 1];

                    }




                    moveTiles.Clear();
                    moveTiles.Add(flagTile);

                    currentDir = (Direction)Random.Range(2, 4);
                    break;
                case Direction.Down:

                    while (flagTile._downNeighbor != null && !flagTile._downNeighbor.isCorner && !flagTile._downNeighbor.IsBlockDir)
                    {
                        moveTiles.Add(flagTile._downNeighbor);
                        flagTile = flagTile._downNeighbor;
                    }

                    if (moveTiles.Count != 0 && moveTiles[0]._upNeighbor != null)
                    {
                        moveTiles[0]._upNeighbor.IsBlockDir = true;

                    }

                    count = Random.Range(1, moveTiles.Count);


                    for (int j = 0; j < count; j++)
                    {
                        moveTiles[j].gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;


                    }

                    if (moveTiles[count - 1]._downNeighbor != null && !moveTiles[count - 1]._downNeighbor.IsBlockDir)
                    {
                        moveTiles[count - 1]._downNeighbor.IsBlockDir = true;

                    }

                    if (moveTiles[count - 1] != null)
                    {
                        flagTile = moveTiles[count - 1];

                    }




                    moveTiles.Clear();
                    moveTiles.Add(flagTile);

                    currentDir = (Direction)Random.Range(2, 4);
                    break;
                case Direction.Right:

                    while (flagTile._rightNeighbor != null && !flagTile._rightNeighbor.isCorner && !flagTile._rightNeighbor.IsBlockDir)
                    {
                        moveTiles.Add(flagTile._rightNeighbor);
                        flagTile = flagTile._rightNeighbor;
                    }

                    if (moveTiles.Count != 0 && moveTiles[0]._leftNeighbor != null)
                    {
                        moveTiles[0]._leftNeighbor.IsBlockDir = true;

                    }

                    count = Random.Range(1, moveTiles.Count);


                    for (int j = 0; j < count; j++)
                    {
                        moveTiles[j].gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;


                    }

                    if (moveTiles[count - 1]._rightNeighbor != null && !moveTiles[count - 1]._rightNeighbor.IsBlockDir)
                    {
                        moveTiles[count - 1]._rightNeighbor.IsBlockDir = true;

                    }

                    if (moveTiles[count - 1] != null)
                    {
                        flagTile = moveTiles[count - 1];

                    }




                    moveTiles.Clear();
                    moveTiles.Add(flagTile);


                    currentDir = (Direction)Random.Range(0, 2);
                    break;
                case Direction.Left:

                    while (flagTile._leftNeighbor != null && !flagTile._leftNeighbor.isCorner && !flagTile._leftNeighbor.IsBlockDir)
                    {
                        moveTiles.Add(flagTile._leftNeighbor);
                        flagTile = flagTile._leftNeighbor;
                    }

                    if (moveTiles.Count != 0 && moveTiles[0]._rightNeighbor != null)
                    {
                        moveTiles[0]._rightNeighbor.IsBlockDir = true;

                    }

                    count = Random.Range(1, moveTiles.Count);


                    for (int j = 0; j < count; j++)
                    {
                        moveTiles[j].gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;


                    }

                    if (moveTiles[count - 1]._leftNeighbor != null && !moveTiles[count - 1]._leftNeighbor.IsBlockDir)
                    {
                        moveTiles[count - 1]._leftNeighbor.IsBlockDir = true;

                    }

                    if (moveTiles[count - 1] != null)
                    {
                        flagTile = moveTiles[count - 1];

                    }




                    moveTiles.Clear();
                    moveTiles.Add(flagTile);


                    currentDir = (Direction)Random.Range(0, 2);
                    break;
            }



        }

        for (int i = 0; i < moveTiles.Count; i++)
        {
            moveTiles[i].gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }



    }





    Vector2Int direc(Direction dir)
    {
        Vector2Int pos = new Vector2Int();
        switch (dir)
        {
            case Direction.Up:
                pos = Vector2Int.up;
                break;
            case Direction.Down:
                pos = Vector2Int.down;
                break;
            case Direction.Right:
                pos = Vector2Int.right;
                break;
            case Direction.Left:
                pos = Vector2Int.left;
                break;

        }

        return pos;
    }


    Direction ReverseDir(Direction dir)
    {
        if (dir == Direction.Up || dir == Direction.Down)
        {
            return (Direction)Random.Range(2, 4);
        }
        else
        {
            return (Direction)Random.Range(0, 2);
        }


    }
    Direction BackDir(Direction dir)
    {
        switch (dir)
        {
            case Direction.Up:
                dir = Direction.Down;
                break;
            case Direction.Down:
                dir = Direction.Up;
                break;
            case Direction.Right:
                dir = Direction.Left;
                break;
            case Direction.Left:
                dir = Direction.Right;
                break;
        }

        return dir;
    }
}
