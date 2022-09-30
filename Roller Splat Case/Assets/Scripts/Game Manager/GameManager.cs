using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }


    public static event Action GameWin;
    public void OnGameWin()
    {
        if (GameWin != null)
        {
            GameWin();
        }
    }

    public static event Action LevelChanged;
    public void OnLevelChanged()
    {
        if (LevelChanged != null)
        {
            LevelChanged();
        }
    }


    public static event Action<int> CurrentLevel;
    public void OnCurrentLevel(int currentLevel)
    {
        if (CurrentLevel != null)
        {
            CurrentLevel(currentLevel);
        }
    }


    public static event Action<Dictionary<Vector2Int, Tile>> AllTilesPos;
    public void OnAllTiles(Dictionary<Vector2Int, Tile> tiles)
    {
        if (AllTilesPos != null)
        {
            AllTilesPos(tiles);
        }
    }

    public static event Action<int, int> LevelSize;
    public void OnLevelSize(int _height, int _width)
    {
        if (LevelSize != null)
        {
            LevelSize(_height, _width);
        }
    }

    public static event Action<Vector2Int> StartPos;
    public void OnStartPos(Vector2Int startTile)
    {
        if (StartPos != null)
        {
            StartPos(startTile);
        }
    }

    public static event Action<int> TotalUnBlockTiles;
    public void OnTotalUnBlockTiles(int count)
    {
        if (TotalUnBlockTiles != null)
        {
            TotalUnBlockTiles(count);
        }
    }

    public static event Action GenerateGrid;
    public void OnGenerateGrid()
    {
        if (GenerateGrid != null)
        {
            GenerateGrid();
        }
    }

    public static event Action ClearGrid;
    public void OnClearGrid()
    {
        if (ClearGrid != null)
        {
            ClearGrid();
        }
    }

    public static event Action GenerateMap;
    public void OnGenerateMap()
    {
        if (GenerateMap != null)
        {
            GenerateMap();
        }
    }




}
