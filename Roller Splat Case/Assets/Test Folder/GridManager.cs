using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField] private int _height;
    [SerializeField] private int _width;
    [SerializeField] private GameObject _tilePrefab;
    public List<Tile> _allTiles;



    private void Start()
    {
        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                GameObject go = Instantiate(_tilePrefab, new Vector3(i, 0, j), Quaternion.Euler(90, 0, 0));
                go.GetComponent<Tile>().TileX = i;
                go.GetComponent<Tile>().TileY = j;
                go.name = "Tile " + "x:" + i + "," + "y:" + j;


                _allTiles.Add(go.GetComponent<Tile>());

            }
        }

        for (int i = 0; i < _allTiles.Count; i++)
        {
            if (_allTiles[i].TileX == _width - 1 || _allTiles[i].TileX == 0)
            {
                _allTiles[i].IsBlock = true;
                _allTiles[i].GetComponent<MeshRenderer>().material.color = Color.red;

            }
            if (_allTiles[i].TileY == _height - 1 || _allTiles[i].TileY == 0)
            {
                _allTiles[i].IsBlock = true;
                _allTiles[i].GetComponent<MeshRenderer>().material.color = Color.red;

            }
        }

        CheckNeighbour();

        TestGameManager.instance.OnAllTiles(_allTiles);
    }


    private void CheckNeighbour()
    {
        for (int i = 0; i < _allTiles.Count; i++)
        {
            // if (_allTiles[i].TileX - _allTiles[i].TileX == 0 && _allTiles[i + 1].TileX < _width)
            if (_allTiles[i].TileY + 1 <= _height - 1)
            {
                _allTiles[i]._upNeighbor = _allTiles[i + 1];
            }
            if (_allTiles[i].TileY - 1 >= 0)
            {
                _allTiles[i]._downNeighbor = _allTiles[i - 1];
            }
            if (_allTiles[i].TileX + 1 <= _width - 1)
            {
                _allTiles[i]._rightNeighbor = _allTiles[i + _width];
            }
            if (_allTiles[i].TileX - 1 >= 0)
            {
                _allTiles[i]._leftNeighbor = _allTiles[i - _width];
            }
        }
    }








}
