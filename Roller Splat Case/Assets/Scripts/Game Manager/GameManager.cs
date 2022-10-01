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

    public static event Action<int> MapSeed;
    public void OnMapSeed(int seed)
    {
        if (MapSeed != null)
        {
            MapSeed(seed);
        }
    }
    public static event Action ChangeMap;
    public void OnChangeMap()
    {
        if (ChangeMap != null)
        {
            ChangeMap();
        }
    }



    private int _lastLevelCount = 5;
    public int LastLevelCount()
    {

        return _lastLevelCount;
    }
    private int _currentLevel;

    public int GetCurrentLevel()
    {

        _currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);

        return _currentLevel;
    }
    public void SetCurrentLevel(int value)
    {
        PlayerPrefs.SetInt("CurrentLevel", value);
        if (value > _lastLevelCount)
        {
            _lastLevelCount = value;
        }
    }

    public int GetCurrentLevelSeed(int level)
    {
        return PlayerPrefs.GetInt("Level" + level, 0);
    }
    public void SetLevelSeed(int level)
    {
        PlayerPrefs.SetInt("Level" + level, level * 20);
    }

    private bool _onGamePause = false;

    public void SetGamePause(bool pause)
    {
        _onGamePause = pause;
    }

    public bool GetOnGamePause()
    {
        return _onGamePause;
    }

}
