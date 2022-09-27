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

        GameManager.Instance.OnStartPos(flagTile.Position);

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
        moveTiles.Add(flagTile);
        Debug.Log(flagTile);

        _changeDirCount = Random.Range(10, 20);
        for (int i = 0; i < _changeDirCount; i++)
        {

            switch (currentDir)
            {
                case Direction.Up:

                    if (flagTile._upNeighbor != null && !flagTile._upNeighbor.IsBlockDir && !flagTile._upNeighbor.isCorner)
                    {
                        while (flagTile._upNeighbor != null && !flagTile._upNeighbor.IsBlockDir && !flagTile._upNeighbor.isCorner)
                        {
                            moveTiles.Add(flagTile._upNeighbor);
                            flagTile = flagTile._upNeighbor;
                        }


                        if (moveTiles.Count != 0 && moveTiles[0]._downNeighbor != null)
                        {
                            moveTiles[0]._downNeighbor.IsBlockDir = true;
                        }

                        Debug.Log("up mtc: " + moveTiles.Count);


                        count = Random.Range(1, moveTiles.Count);
                        Debug.Log("up c: " + count);
                        for (int j = 0; j <= count; j++)
                        {
                            moveTiles[j].gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
                            moveTiles[j].IsBlock = false;
                        }

                        if (moveTiles[count]._upNeighbor != null)
                        {
                            moveTiles[count]._upNeighbor.IsBlockDir = true;
                        }

                        flagTile = moveTiles[count];
                        Debug.Log("up ft: " + flagTile);
                        moveTiles.Clear();
                        moveTiles.Add(flagTile);
                        currentDir = (Direction)Random.Range(2, 4);
                    }
                    else
                    {
                        currentDir = Direction.Down;

                    }



                    break;
                case Direction.Down:


                    if (flagTile._downNeighbor != null && !flagTile._downNeighbor.IsBlockDir && !flagTile._downNeighbor.isCorner)
                    {
                        while (flagTile._downNeighbor != null && !flagTile._downNeighbor.IsBlockDir && !flagTile._downNeighbor.isCorner)
                        {
                            moveTiles.Add(flagTile._downNeighbor);
                            flagTile = flagTile._downNeighbor;
                        }


                        if (moveTiles.Count != 0 && moveTiles[0]._upNeighbor != null)
                        {
                            moveTiles[0]._upNeighbor.IsBlockDir = true;
                        }

                        Debug.Log("down mtc: " + moveTiles.Count);


                        count = Random.Range(1, moveTiles.Count);
                        Debug.Log("down c: " + count);
                        for (int j = 0; j <= count; j++)
                        {
                            moveTiles[j].gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
                            moveTiles[j].IsBlock = false;

                        }

                        if (moveTiles[count]._downNeighbor != null)
                        {
                            moveTiles[count]._downNeighbor.IsBlockDir = true;
                        }

                        flagTile = moveTiles[count];

                        Debug.Log("down ft: " + flagTile);
                        moveTiles.Clear();
                        moveTiles.Add(flagTile);
                        currentDir = (Direction)Random.Range(2, 4);
                    }
                    else
                    {
                        currentDir = Direction.Up;

                    }
                    break;
                case Direction.Right:

                    if (flagTile._rightNeighbor != null && !flagTile._rightNeighbor.IsBlockDir && !flagTile._rightNeighbor.isCorner)
                    {
                        while (flagTile._rightNeighbor != null && !flagTile._rightNeighbor.IsBlockDir && !flagTile._rightNeighbor.isCorner)
                        {
                            moveTiles.Add(flagTile._rightNeighbor);
                            flagTile = flagTile._rightNeighbor;
                        }


                        if (moveTiles.Count != 0 && moveTiles[0]._leftNeighbor != null)
                        {
                            moveTiles[0]._leftNeighbor.IsBlockDir = true;
                        }

                        Debug.Log("right mtc: " + moveTiles.Count);


                        count = Random.Range(1, moveTiles.Count);
                        Debug.Log("right c: " + count);

                        for (int j = 0; j <= count; j++)
                        {
                            moveTiles[j].gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
                            moveTiles[j].IsBlock = false;

                        }

                        if (moveTiles[count]._rightNeighbor != null)
                        {
                            moveTiles[count]._rightNeighbor.IsBlockDir = true;
                        }

                        flagTile = moveTiles[count];

                        Debug.Log("right ft: " + flagTile);
                        moveTiles.Clear();
                        moveTiles.Add(flagTile);
                        currentDir = (Direction)Random.Range(0, 2);
                    }
                    else
                    {
                        currentDir = Direction.Left;

                    }
                    break;
                case Direction.Left:

                    if (flagTile._leftNeighbor != null && !flagTile._leftNeighbor.IsBlockDir && !flagTile._leftNeighbor.isCorner)
                    {
                        while (flagTile._leftNeighbor != null && !flagTile._leftNeighbor.IsBlockDir && !flagTile._leftNeighbor.isCorner)
                        {
                            moveTiles.Add(flagTile._leftNeighbor);
                            flagTile = flagTile._leftNeighbor;
                        }


                        if (moveTiles.Count != 0 && moveTiles[0]._rightNeighbor != null)
                        {
                            moveTiles[0]._rightNeighbor.IsBlockDir = true;
                        }

                        Debug.Log("left mtc: " + moveTiles.Count);


                        count = Random.Range(1, moveTiles.Count);
                        Debug.Log("left c: " + count);
                        for (int j = 0; j <= count; j++)
                        {
                            moveTiles[j].gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
                            moveTiles[j].IsBlock = false;

                        }

                        if (moveTiles[count]._leftNeighbor != null)
                        {
                            moveTiles[count]._leftNeighbor.IsBlockDir = true;
                        }

                        flagTile = moveTiles[count];

                        Debug.Log("left ft: " + flagTile);
                        moveTiles.Clear();
                        moveTiles.Add(flagTile);
                        currentDir = (Direction)Random.Range(0, 2);
                    }
                    else
                    {
                        currentDir = Direction.Right;

                    }
                    break;
            }



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
