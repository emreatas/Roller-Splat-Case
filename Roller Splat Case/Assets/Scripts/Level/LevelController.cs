using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField] private List<int> _seed;

    private Dictionary<Vector2Int, Tile> _tiles;



    private void OnEnable()
    {
        GameManager.AllTilesPos += GameManager_AllTilesPos;
        GameManager.GameWin += GameManager_GameWin;
        GameManager.ChangeMap += GameManager_ChangeMap;


    }

    private void GameManager_ChangeMap()
    {
        GenerateLevel(GameManager.Instance.GetCurrentLevel());
    }

    private void GameManager_GameWin()
    {
        GameManager.Instance.SetCurrentLevel(GameManager.Instance.GetCurrentLevel() + 1);
    }



    private void GameManager_AllTilesPos(Dictionary<Vector2Int, Tile> obj)
    {
        _tiles = obj;
    }
    private void OnDisable()
    {
        GameManager.AllTilesPos -= GameManager_AllTilesPos;
        GameManager.GameWin -= GameManager_GameWin;
        GameManager.ChangeMap -= GameManager_ChangeMap;





    }

    public void NextLevel()
    {
        GameManager.Instance.SetCurrentLevel(GameManager.Instance.GetCurrentLevel());
        GameManager.Instance.SetLevelSeed(GameManager.Instance.GetCurrentLevel());


        ClearMap();
        GameManager.Instance.OnGenerateGrid();
        GameManager.Instance.OnGenerateMap();
        GameManager.Instance.OnLevelChanged();
    }


    public void GenerateLevel(int levelIndex)
    {
        GameManager.Instance.SetCurrentLevel(levelIndex);
        GameManager.Instance.SetLevelSeed(GameManager.Instance.GetCurrentLevel());


        ClearMap();
        GameManager.Instance.OnGenerateGrid();
        GameManager.Instance.OnGenerateMap();
        GameManager.Instance.OnLevelChanged();
    }

    public void ClearMap()
    {

        if (_tiles != null)
        {
            _tiles.Clear();
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }

            GameManager.Instance.OnAllTiles(_tiles);
        }



    }
}
