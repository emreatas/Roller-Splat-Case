using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    public int maxHeight;
    public int maxWidth;


    [SerializeField] private GameObject _tilePrefab;


    [SerializeField] private List<Tile> _tiles;




    private void Start()
    {
        for (int i = 0; i < maxHeight; i++)
        {
            for (int j = 0; j < maxWidth; j++)
            {
                GameObject go = Instantiate(_tilePrefab, new Vector3(j, 0, i), Quaternion.Euler(90, 0, 0));
                go.GetComponent<Tile>().TileX = j;
                go.GetComponent<Tile>().TileY = i;
                _tiles.Add(go.GetComponent<Tile>());
            }
        }



        for (int i = 0; i < _tiles.Count; i++)
        {
            for (int j = 0; j < _tiles.Count; j++)
            {
                if (j + 1 <= maxWidth)
                {
                    if (_tiles[i].TileX == _tiles[j + 1].TileX && _tiles[i].TileY == _tiles[j + 1].TileY && _tiles[j + 1].TileX != maxWidth)
                    {
                        _tiles[i]._neighborTiles.Add(_tiles[j].gameObject);
                    }
                }

            }
        }
    }






}
