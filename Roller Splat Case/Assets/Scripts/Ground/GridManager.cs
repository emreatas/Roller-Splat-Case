using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField] private int _height;
    [SerializeField] private int _width;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private GameObject levelObject;
    //public List<Tile> _allTiles;
    public Dictionary<Vector2Int, Tile> _tiles = new Dictionary<Vector2Int, Tile>();

    private void OnEnable()
    {
        GameManager.GenerateGrid += GameManager_GenerateGrid;
    }

    private void GameManager_GenerateGrid()
    {
        GenerateGrid();
    }
    private void OnDisable()
    {
        GameManager.GenerateGrid -= GameManager_GenerateGrid;

    }

    private void GenerateGrid()
    {

        _tilePrefab.GetComponent<Tile>().color = Random.ColorHSV(0, 1);


        _height = Random.Range(16, 33);
        _width = Random.Range(8, 17);
        GameManager.Instance.OnLevelSize(_height, _width);

        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                GameObject go = Instantiate(_tilePrefab, new Vector3(j, 0, i), Quaternion.Euler(90, 0, 0));
                Tile tile = go.GetComponent<Tile>();
                go.transform.SetParent(levelObject.transform);
                tile.Position = new Vector2Int(j, i);
                _tiles.Add(new Vector2Int(j, i), tile);
                go.name = "Tile " + "x:" + j + "," + "y:" + i;


            }
        }


        CheckNeighbour();
        Corner();
        GameManager.Instance.OnAllTiles(_tiles);

    }

    private void Corner()
    {
        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _width; j++)
            {

                if (_tiles[new Vector2Int(j, i)].Position.x == 0 ||
                    _tiles[new Vector2Int(j, i)].Position.y == 0 ||
                    _tiles[new Vector2Int(j, i)].Position.x == _width - 1 ||
                    _tiles[new Vector2Int(j, i)].Position.y == _height - 1)
                {
                    _tiles[new Vector2Int(j, i)].isCorner = true;
                }
                else
                {
                    _tiles[new Vector2Int(j, i)].isCorner = false;
                }

            }
        }
    }
    private void CheckNeighbour()
    {


        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                Vector2Int pos = new Vector2Int(j, i);

                if (_tiles[pos].Position.y + 1 <= _height - 1)
                {
                    _tiles[pos]._upNeighbor = _tiles[pos + new Vector2Int(0, 1)];
                }
                if (_tiles[pos].Position.y - 1 >= 0)
                {
                    _tiles[pos]._downNeighbor = _tiles[pos + new Vector2Int(0, -1)];
                }
                if (_tiles[pos].Position.x + 1 <= _width - 1)
                {
                    _tiles[pos]._rightNeighbor = _tiles[pos + new Vector2Int(1, 0)];
                }
                if (_tiles[pos].Position.x - 1 >= 0)
                {
                    _tiles[pos]._leftNeighbor = _tiles[pos + new Vector2Int(-1, 0)];
                }


            }
        }




    }








}
