using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private Dictionary<Vector2Int, Tile> _tiles;


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
    private void Start()
    {
        //  GenerateLevel();

    }
    public void GenerateLevel()
    {

        GameManager.Instance.OnGenerateGrid();
        GameManager.Instance.OnGenerateMap();
        GameManager.Instance.OnLevelChanged();
    }

    public void ClearMap()
    {
        _tiles.Clear();

        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        GameManager.Instance.OnAllTiles(_tiles);
    }
}
