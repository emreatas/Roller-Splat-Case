using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private int _tileX;
    private int _tileY;
    private bool isBlock;

    public Tile _upNeighbor;
    public Tile _downNeighbor;
    public Tile _leftNeighbor;
    public Tile _rightNeighbor;


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

    public bool IsBlock
    {
        get { return isBlock; }
        set { isBlock = value; }
    }




}
