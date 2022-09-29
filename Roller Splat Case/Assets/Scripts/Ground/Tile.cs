using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private int _tileX;
    private int _tileY;
    [SerializeField] private GameObject _wall;


    [SerializeField] private Vector2Int _position;
    [SerializeField] private bool _isBlockDir;
    [SerializeField] private bool _isCorner;

    [SerializeField] private bool _isBlock;

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

    public Vector2Int Position
    {
        get { return _position; }
        set { _position = value; }
    }

    public bool IsBlockDir
    {
        get { return _isBlockDir; }
        set
        {
            _isBlockDir = value;
            if (_isBlockDir)
            {
                // gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            }
        }
    }
    public bool isCorner
    {
        get { return _isCorner; }
        set
        {
            _isCorner = value;
            if (_isCorner)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
                _wall.SetActive(true);
                _wall.GetComponent<MeshRenderer>().material.color = Color.black;


            }
        }
    }

    public bool IsBlock
    {
        get { return _isBlock; }
        set
        {
            _isBlock = value;
            if (IsBlock && !isCorner)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                _wall.SetActive(true);
                _wall.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            else if (IsBlock && isCorner)
            {
                return;
            }
            else
            {
                gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
                _wall.SetActive(false);
            }
        }
    }




}
