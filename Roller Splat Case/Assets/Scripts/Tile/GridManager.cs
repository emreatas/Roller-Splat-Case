using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField] private int _gridWitdh;
    [SerializeField] private int _gridHeight;

    [SerializeField] private GameObject _tile;



    void Start()
    {
        GenerateGrid();
    }

    void Update()
    {

    }


    private void GenerateGrid()
    {
        for (int i = 0; i < _gridHeight; i++)
        {
            for (int j = 0; j < _gridWitdh; j++)
            {
                GameObject go;

                go = Instantiate(_tile, new Vector3(i, j), Quaternion.identity);

                go.GetComponent<Tile>().TileY = j;
                go.GetComponent<Tile>().TileX = i;

                go.transform.position = new Vector3(i, 0, j);

            }
        }
    }

}
