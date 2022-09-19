using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private int _tileX;
    [SerializeField] private int _tileY;



    public int TileX
    {
        get { return _tileX; }
        set { _tileX = value; }
    }

    public int TileY
    {
        get { return _tileY; }
        set { _tileY = value; }
    }



}
