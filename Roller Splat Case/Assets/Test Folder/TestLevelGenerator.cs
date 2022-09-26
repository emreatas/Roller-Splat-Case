using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevelGenerator : MonoBehaviour
{
    public Dictionary<Vector2Int, Tile> _tiles;



    private void OnEnable()
    {
        GameManager.AllTilesPos += GameManager_AllTilesPos;
    }

    private void GameManager_AllTilesPos(Dictionary<Vector2Int, Tile> obj)
    {
        _tiles = obj;
    }
    private void OnDisable()
    {
        GameManager.AllTilesPos -= GameManager_AllTilesPos;

    }



}
