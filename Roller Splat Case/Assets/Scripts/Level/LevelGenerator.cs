using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance;

    private void Awake()
    {
        Instance = this;
    }


    [SerializeField] private Dictionary<Vector2Int, Tile> _tiles;
    public int firstTileX;
    public int firstTileY;
    public int _height;
    public int _width;
    public int _changeDirCount = 10;
    [SerializeField] private List<Tile> moveTiles;
    private Tile flagTile;

    enum Direction { Up, Down, Right, Left };

    public static event System.Action<int> OnTotalUnBlockTiles;

    private void OnEnable()
    {
        GameManager.AllTilesPos += GameManager_AllTilesPos;
        GameManager.LevelSize += GameManager_LevelSize;
        GameManager.GenerateMap += GameManager_GenerateMap;
        GameManager.LevelChanged += GameManager_LevelChanged;

    }

    private void GameManager_LevelChanged()
    {
        moveTiles.Clear();
    }

    private void GameManager_GenerateMap()
    {
        MapGenerator();
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
        GameManager.GenerateMap -= GameManager_GenerateMap;
        GameManager.LevelChanged -= GameManager_LevelChanged;





    }



    //private void Start()
    //{
    //    //StartCoroutine(Test());
    //    MapGenerator();


    //}



    public void MapGenerator()
    {
        firstTileX = Random.Range(1, _width - 1);
        firstTileY = Random.Range(1, _height - 1);



        flagTile = _tiles[new Vector2Int(firstTileX, firstTileY)];

        // flagTile.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;

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

        _changeDirCount = Random.Range(10, 100);

        for (int i = 0; i < _changeDirCount; i++)
        {

            switch (currentDir)
            {
                case Direction.Up:

                    if (flagTile._upNeighbor != null && flagTile._upNeighbor.IsBlock && !flagTile._upNeighbor.IsBlockDir && !flagTile._upNeighbor.isCorner)
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



                        count = Random.Range(1, moveTiles.Count);
                        for (int j = 0; j <= count; j++)
                        {
                            moveTiles[j].IsBlock = false;
                        }

                        if (moveTiles[count]._upNeighbor != null && !moveTiles[count]._upNeighbor.IsBlock)
                        {

                            moveTiles[count - 1]._upNeighbor.IsBlockDir = true;
                            moveTiles[count].IsBlock = true;

                            flagTile = moveTiles[count - 1];
                        }
                        else
                        {
                            if (moveTiles[count]._upNeighbor != null)
                            {
                                moveTiles[count]._upNeighbor.IsBlockDir = true;
                                flagTile = moveTiles[count];

                            }

                        }

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


                    if (flagTile._downNeighbor != null && flagTile._downNeighbor.IsBlock && !flagTile._downNeighbor.IsBlockDir && !flagTile._downNeighbor.isCorner)
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




                        count = Random.Range(1, moveTiles.Count);





                        for (int j = 0; j <= count; j++)
                        {
                            moveTiles[j].IsBlock = false;

                        }

                        if (moveTiles[count]._downNeighbor != null && !moveTiles[count]._downNeighbor.IsBlock)
                        {

                            moveTiles[count - 1]._downNeighbor.IsBlockDir = true;
                            moveTiles[count].IsBlock = true;

                            flagTile = moveTiles[count - 1];
                        }
                        else
                        {
                            if (moveTiles[count]._downNeighbor != null)
                            {
                                moveTiles[count]._downNeighbor.IsBlockDir = true;
                                flagTile = moveTiles[count];

                            }

                        }



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

                    if (flagTile._rightNeighbor != null && flagTile._rightNeighbor.IsBlock && !flagTile._rightNeighbor.IsBlockDir && !flagTile._rightNeighbor.isCorner)
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




                        count = Random.Range(1, moveTiles.Count);

                        for (int j = 0; j <= count; j++)
                        {
                            moveTiles[j].IsBlock = false;

                        }

                        if (moveTiles[count]._rightNeighbor != null && !moveTiles[count]._rightNeighbor.IsBlock)
                        {

                            moveTiles[count - 1]._rightNeighbor.IsBlockDir = true;
                            moveTiles[count].IsBlock = true;

                            flagTile = moveTiles[count - 1];
                        }
                        else
                        {
                            if (moveTiles[count]._rightNeighbor != null)
                            {
                                moveTiles[count]._rightNeighbor.IsBlockDir = true;
                                flagTile = moveTiles[count];

                            }

                        }

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

                    if (flagTile._leftNeighbor != null && flagTile._leftNeighbor.IsBlock && !flagTile._leftNeighbor.IsBlockDir && !flagTile._leftNeighbor.isCorner)
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



                        count = Random.Range(1, moveTiles.Count);
                        for (int j = 0; j <= count; j++)
                        {
                            moveTiles[j].IsBlock = false;

                        }

                        if (moveTiles[count]._leftNeighbor != null && !moveTiles[count]._leftNeighbor.IsBlock)
                        {
                            moveTiles[count - 1]._leftNeighbor.IsBlockDir = true;
                            moveTiles[count].IsBlock = true;

                            flagTile = moveTiles[count - 1];
                        }
                        else
                        {
                            if (moveTiles[count]._leftNeighbor != null)
                            {
                                moveTiles[count]._leftNeighbor.IsBlockDir = true;
                                flagTile = moveTiles[count];

                            }

                        }

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
        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                if (_tiles[new Vector2Int(j, i)]._upNeighbor != null &&
                    _tiles[new Vector2Int(j, i)]._downNeighbor != null &&
                    _tiles[new Vector2Int(j, i)]._leftNeighbor != null &&
                    _tiles[new Vector2Int(j, i)]._rightNeighbor != null &&
                    _tiles[new Vector2Int(j, i)]._upNeighbor.IsBlock &&
                    _tiles[new Vector2Int(j, i)]._downNeighbor.IsBlock &&
                    _tiles[new Vector2Int(j, i)]._leftNeighbor.IsBlock &&
                    _tiles[new Vector2Int(j, i)]._rightNeighbor.IsBlock)
                {
                    _tiles[new Vector2Int(j, i)].IsBlock = true;
                }
            }
        }

        //  _tiles[new Vector2Int(firstTileX, firstTileY)].gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;

        int unBlockTileCount = 0;
        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                if (!_tiles[new Vector2Int(j, i)].IsBlock)
                {
                    unBlockTileCount++;
                }
            }
        }

        GameManager.Instance.OnTotalUnBlockTiles(unBlockTileCount);
        LevelGenerator.OnTotalUnBlockTiles?.Invoke(unBlockTileCount);


        //int a = 0;
        //for (int i = 0; i < _height; i++)
        //{                                                                    
        //    for (int j = 0; j < _width; j++)                                 
        //    {                                                                
        //        if (!_tiles[new Vector2Int(j, i)].IsBlock)                   
        //        {                                                            
        //            a++;                                                     
        //        }                                                            
        //    }                                                                
        //}                                                                    
        //Debug.Log(a);                                                        
        //if (a < 20)                                                          
        //{                                                                    
        //    for (int i = 0; i < _height; i++)                                
        //    {                                                                
        //        for (int j = 0; j < _width; j++)                             
        //        {                                                            
        //            _tiles[new Vector2Int(j, i)].IsBlock = true;             
        //        }                                                            
        //    }
        //    MapGenerator();
        //    a = 0;
        //}

        //Debug.Log("c");

    }


    //IEnumerator Test()
    //{
    //    yield return new WaitForFixedUpdate();
    //    firstTileX = Random.Range(1, _width - 1);
    //    firstTileY = Random.Range(1, _height - 1);

    //    flagTile = _tiles[new Vector2Int(firstTileX, firstTileY)];

    //    GameManager.Instance.OnStartPos(flagTile.Position);

    //    for (int i = 0; i < _height; i++)
    //    {
    //        for (int j = 0; j < _width; j++)
    //        {
    //            Vector2Int pos = new Vector2Int(j, i);
    //            _tiles[pos].IsBlock = true;

    //        }
    //    }


    //    // direction = Random.insideUnitCircle.normalized;


    //    Direction currentDir = (Direction)Random.Range(0, 4);
    //    int count;
    //    moveTiles.Add(flagTile);
    //    Debug.Log(flagTile);

    //    _changeDirCount = Random.Range(10, 20);
    //    for (int i = 0; i < _changeDirCount; i++)
    //    {

    //        switch (currentDir)
    //        {
    //            case Direction.Up:

    //                if (flagTile._upNeighbor != null && flagTile._upNeighbor.IsBlock && !flagTile._upNeighbor.IsBlockDir && !flagTile._upNeighbor.isCorner)
    //                {
    //                    while (flagTile._upNeighbor != null && !flagTile._upNeighbor.IsBlockDir && !flagTile._upNeighbor.isCorner)
    //                    {
    //                        moveTiles.Add(flagTile._upNeighbor);
    //                        flagTile = flagTile._upNeighbor;
    //                    }


    //                    if (moveTiles.Count != 0 && moveTiles[0]._downNeighbor != null)
    //                    {
    //                        moveTiles[0]._downNeighbor.IsBlockDir = true;
    //                    }

    //                    Debug.Log("up mtc: " + moveTiles.Count);


    //                    count = Random.Range(1, moveTiles.Count);
    //                    Debug.Log("up c: " + count);
    //                    for (int j = 0; j <= count; j++)
    //                    {
    //                        moveTiles[j].IsBlock = false;
    //                    }

    //                    if (moveTiles[count]._upNeighbor != null && !moveTiles[count]._upNeighbor.IsBlock)
    //                    {
    //                        Debug.Log("up girdi");

    //                        moveTiles[count - 1]._upNeighbor.IsBlockDir = true;
    //                        moveTiles[count].IsBlock = true;

    //                        flagTile = moveTiles[count - 1];
    //                    }
    //                    else
    //                    {
    //                        if (moveTiles[count]._upNeighbor != null)
    //                        {
    //                            moveTiles[count]._upNeighbor.IsBlockDir = true;
    //                            flagTile = moveTiles[count];

    //                        }

    //                    }
    //                    Debug.Log("up mt max:" + moveTiles[count]);
    //                    Debug.Log("up ft: " + flagTile);
    //                    moveTiles.Clear();
    //                    moveTiles.Add(flagTile);

    //                    currentDir = (Direction)Random.Range(2, 4);


    //                }
    //                else
    //                {
    //                    currentDir = Direction.Down;

    //                }



    //                break;
    //            case Direction.Down:


    //                if (flagTile._downNeighbor != null && flagTile._downNeighbor.IsBlock && !flagTile._downNeighbor.IsBlockDir && !flagTile._downNeighbor.isCorner)
    //                {
    //                    while (flagTile._downNeighbor != null && !flagTile._downNeighbor.IsBlockDir && !flagTile._downNeighbor.isCorner)
    //                    {
    //                        moveTiles.Add(flagTile._downNeighbor);
    //                        flagTile = flagTile._downNeighbor;
    //                    }


    //                    if (moveTiles.Count != 0 && moveTiles[0]._upNeighbor != null)
    //                    {
    //                        moveTiles[0]._upNeighbor.IsBlockDir = true;
    //                    }

    //                    Debug.Log("down mtc: " + moveTiles.Count);


    //                    count = Random.Range(1, moveTiles.Count);

    //                    Debug.Log("down c: " + count);



    //                    for (int j = 0; j <= count; j++)
    //                    {
    //                        moveTiles[j].IsBlock = false;

    //                    }

    //                    if (moveTiles[count]._downNeighbor != null && !moveTiles[count]._downNeighbor.IsBlock)
    //                    {
    //                        Debug.Log("down girdi");

    //                        moveTiles[count - 1]._downNeighbor.IsBlockDir = true;
    //                        moveTiles[count].IsBlock = true;

    //                        flagTile = moveTiles[count - 1];
    //                    }
    //                    else
    //                    {
    //                        if (moveTiles[count]._downNeighbor != null)
    //                        {
    //                            moveTiles[count]._downNeighbor.IsBlockDir = true;
    //                            flagTile = moveTiles[count];

    //                        }

    //                    }


    //                    Debug.Log("down mt max:" + moveTiles[count]);

    //                    Debug.Log("down ft: " + flagTile);
    //                    moveTiles.Clear();
    //                    moveTiles.Add(flagTile);
    //                    currentDir = (Direction)Random.Range(2, 4);
    //                }
    //                else
    //                {
    //                    currentDir = Direction.Up;

    //                }
    //                break;
    //            case Direction.Right:

    //                if (flagTile._rightNeighbor != null && flagTile._rightNeighbor.IsBlock && !flagTile._rightNeighbor.IsBlockDir && !flagTile._rightNeighbor.isCorner)
    //                {
    //                    while (flagTile._rightNeighbor != null && !flagTile._rightNeighbor.IsBlockDir && !flagTile._rightNeighbor.isCorner)
    //                    {
    //                        moveTiles.Add(flagTile._rightNeighbor);
    //                        flagTile = flagTile._rightNeighbor;
    //                    }


    //                    if (moveTiles.Count != 0 && moveTiles[0]._leftNeighbor != null)
    //                    {
    //                        moveTiles[0]._leftNeighbor.IsBlockDir = true;
    //                    }

    //                    Debug.Log("right mtc: " + moveTiles.Count);


    //                    count = Random.Range(1, moveTiles.Count);
    //                    Debug.Log("right c: " + count);

    //                    for (int j = 0; j <= count; j++)
    //                    {
    //                        moveTiles[j].IsBlock = false;

    //                    }

    //                    if (moveTiles[count]._rightNeighbor != null && !moveTiles[count]._rightNeighbor.IsBlock)
    //                    {
    //                        Debug.Log("right girdi");

    //                        moveTiles[count - 1]._rightNeighbor.IsBlockDir = true;
    //                        moveTiles[count].IsBlock = true;

    //                        flagTile = moveTiles[count - 1];
    //                    }
    //                    else
    //                    {
    //                        if (moveTiles[count]._rightNeighbor != null)
    //                        {
    //                            moveTiles[count]._rightNeighbor.IsBlockDir = true;
    //                            flagTile = moveTiles[count];

    //                        }

    //                    }
    //                    Debug.Log("right mt max:" + moveTiles[count]);

    //                    Debug.Log("right ft: " + flagTile);
    //                    moveTiles.Clear();
    //                    moveTiles.Add(flagTile);
    //                    currentDir = (Direction)Random.Range(0, 2);
    //                }
    //                else
    //                {
    //                    currentDir = Direction.Left;

    //                }
    //                break;
    //            case Direction.Left:

    //                if (flagTile._leftNeighbor != null && flagTile._leftNeighbor.IsBlock && !flagTile._leftNeighbor.IsBlockDir && !flagTile._leftNeighbor.isCorner)
    //                {
    //                    while (flagTile._leftNeighbor != null && !flagTile._leftNeighbor.IsBlockDir && !flagTile._leftNeighbor.isCorner)
    //                    {
    //                        moveTiles.Add(flagTile._leftNeighbor);
    //                        flagTile = flagTile._leftNeighbor;
    //                    }


    //                    if (moveTiles.Count != 0 && moveTiles[0]._rightNeighbor != null)
    //                    {
    //                        moveTiles[0]._rightNeighbor.IsBlockDir = true;
    //                    }

    //                    Debug.Log("left mtc: " + moveTiles.Count);


    //                    count = Random.Range(1, moveTiles.Count);
    //                    Debug.Log("left c: " + count);
    //                    for (int j = 0; j <= count; j++)
    //                    {
    //                        moveTiles[j].IsBlock = false;

    //                    }

    //                    if (moveTiles[count]._leftNeighbor != null && !moveTiles[count]._leftNeighbor.IsBlock)
    //                    {
    //                        Debug.Log("left girdi");
    //                        moveTiles[count - 1]._leftNeighbor.IsBlockDir = true;
    //                        moveTiles[count].IsBlock = true;

    //                        flagTile = moveTiles[count - 1];
    //                    }
    //                    else
    //                    {
    //                        if (moveTiles[count]._leftNeighbor != null)
    //                        {
    //                            moveTiles[count]._leftNeighbor.IsBlockDir = true;
    //                            flagTile = moveTiles[count];

    //                        }

    //                    }
    //                    Debug.Log("left mt max:" + moveTiles[count]);

    //                    Debug.Log("left ft: " + flagTile);
    //                    moveTiles.Clear();
    //                    moveTiles.Add(flagTile);
    //                    currentDir = (Direction)Random.Range(0, 2);
    //                }
    //                else
    //                {
    //                    currentDir = Direction.Right;

    //                }
    //                break;
    //        }
    //    }

    //    int a = 0;
    //    for (int i = 0; i < _height; i++)
    //    {
    //        for (int j = 0; j < _width; j++)
    //        {
    //            if (!_tiles[new Vector2Int(j, i)].IsBlock)
    //            {
    //                a++;
    //            }
    //        }
    //    }
    //    Debug.Log(a);
    //    if (a < 50)
    //    {
    //        for (int i = 0; i < _height; i++)
    //        {
    //            for (int j = 0; j < _width; j++)
    //            {
    //                _tiles[new Vector2Int(j, i)].IsBlock = true;
    //            }
    //        }
    //        StartCoroutine(Test());
    //        a = 0;
    //    }
    //    else
    //    {
    //        StopCoroutine(Test());
    //    }

    //}
}
