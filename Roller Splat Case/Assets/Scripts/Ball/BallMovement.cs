using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    [SerializeField] private bool _isTap;
    [SerializeField] private bool _isSwipeLeft;
    [SerializeField] private bool _isSwipeRight;
    [SerializeField] private bool _isSwipeUp;
    [SerializeField] private bool _isSwipeDown;
    [SerializeField] private bool _isDragging = false;
    [SerializeField] private bool _isMoving = false;

    [SerializeField] private Vector3 _startPos;
    [SerializeField] private Vector3 _swipeDelta;



    [SerializeField] private int _speed = 1;


    public Dictionary<Vector2Int, Tile> tiles;
    public Tile currentTile;
    public List<Tile> movementTiles;
    private int _pathWayCurrentIndex = 0;
    private int _totalUnblockTileCount = 0;
    private int _coloredTile = 0;

    private void OnEnable()
    {
        GameManager.AllTilesPos += GameManager_AllTilesPos;
        GameManager.StartPos += GameManager_StartPos;
        GameManager.TotalUnBlockTiles += GameManager_TotalUnBlockTiles;
        LevelGenerator.OnTotalUnBlockTiles += LevelGenerator_OnTotalUnBlockTiles;
    }


    private void GameManager_TotalUnBlockTiles(int obj)
    {
        //_totalUnblockTileCount = obj;

    }

    private void GameManager_AllTilesPos(Dictionary<Vector2Int, Tile> obj)
    {
        tiles = obj;


    }
    private void GameManager_StartPos(Vector2Int obj)
    {

        currentTile = tiles[obj];
        gameObject.transform.position = currentTile.transform.position;
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z);

    }
    private void OnDisable()
    {
        GameManager.AllTilesPos -= GameManager_AllTilesPos;
        GameManager.StartPos -= GameManager_StartPos;
        GameManager.TotalUnBlockTiles -= GameManager_TotalUnBlockTiles;
        LevelGenerator.OnTotalUnBlockTiles -= LevelGenerator_OnTotalUnBlockTiles;

    }

    private void Start()
    {
        //Debug.Log("total colored tile" + _totalUnblockTileCount);
    }
    public static event Action<int> TotalUnBlockTiles;

    private void LevelGenerator_OnTotalUnBlockTiles(int obj)
    {
        _totalUnblockTileCount = 0;
        _coloredTile = 0;
        _totalUnblockTileCount = obj;


    }


    private void Update()
    {

        if (GameManager.Instance.GetOnGamePause())
        {
            return;
        }


        _isTap = false;
        _isSwipeLeft = false;
        _isSwipeRight = false;
        _isSwipeUp = false;
        _isSwipeDown = false;



        if (Input.GetMouseButtonDown(0))
        {
            _isTap = true;
            _isDragging = true;

            _startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Reset();
        }



        _swipeDelta = Vector3.zero;
        if (_isDragging)
        {
            if (Input.GetMouseButton(0))
            {
                _swipeDelta = Input.mousePosition - _startPos;
            }
        }

        if (_swipeDelta.magnitude > 50)
        {
            float x = _swipeDelta.x;
            float y = _swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {

                if (x < 0)
                {
                    _isSwipeLeft = true;
                    MoveAxis();

                    //  gameObject.GetComponent<Rigidbody>().velocity = Vector3.left * _speed;
                }
                else
                {
                    _isSwipeRight = true;
                    MoveAxis();

                    //  gameObject.GetComponent<Rigidbody>().velocity = Vector3.right * _speed;

                }

            }
            if (Mathf.Abs(y) > Mathf.Abs(x))
            {

                if (y < 0)
                {
                    _isSwipeDown = true;

                    MoveAxis();

                    // gameObject.GetComponent<Rigidbody>().velocity = Vector3.back * _speed;

                }

                else
                {
                    _isSwipeUp = true;
                    MoveAxis();
                    //gameObject.GetComponent<Rigidbody>().velocity = Vector3.forward * _speed;

                }

            }




            Reset();
        }




    }

    private void Reset()
    {
        _isTap = false;
        _isDragging = false;

        _startPos = Vector3.zero;
        _swipeDelta = Vector3.zero;
    }

    private void MoveAxis()
    {
        if (_isMoving)
        {
            return;
        }
        movementTiles.Clear();
        movementTiles.Add(currentTile);

        if (_isSwipeUp)
        {
            while (currentTile._upNeighbor != null && !currentTile._upNeighbor.IsBlock)
            {

                movementTiles.Add(currentTile._upNeighbor);
                currentTile = currentTile._upNeighbor;

            }


        }

        if (_isSwipeDown)
        {
            while (currentTile._downNeighbor != null && !currentTile._downNeighbor.IsBlock)
            {

                movementTiles.Add(currentTile._downNeighbor);
                currentTile = currentTile._downNeighbor;

            }
        }

        if (_isSwipeRight)
        {
            while (currentTile._rightNeighbor != null && !currentTile._rightNeighbor.IsBlock)
            {

                movementTiles.Add(currentTile._rightNeighbor);
                currentTile = currentTile._rightNeighbor;

            }
        }

        if (_isSwipeLeft)
        {
            while (currentTile._leftNeighbor != null && !currentTile._leftNeighbor.IsBlock)
            {

                movementTiles.Add(currentTile._leftNeighbor);
                currentTile = currentTile._leftNeighbor;

            }
        }
        _isMoving = true;

        StartCoroutine(MoveBallToTarget(movementTiles));
    }





    IEnumerator MoveBallToTarget(List<Tile> path)
    {
        yield return new WaitForFixedUpdate();

        if (path.Count > 0 && gameObject.transform.position != path[path.Count - 1].transform.position)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
                path[_pathWayCurrentIndex].transform.position, _speed * Time.deltaTime);

            StartCoroutine(MoveBallToTarget(path));

            if (gameObject.transform.position == path[_pathWayCurrentIndex].transform.position &&
                _pathWayCurrentIndex < path.Count)
            {
                if (!path[_pathWayCurrentIndex].IsColored)
                {
                    path[_pathWayCurrentIndex].IsColored = true;
                    _coloredTile++;
                }
                _pathWayCurrentIndex++;
            }

            if (_totalUnblockTileCount == _coloredTile)
            {
                _isMoving = false;
                movementTiles.Clear();
                currentTile = null;
                GameManager.Instance.OnGameWin();

            }
        }
        else
        {
            StopCoroutine(MoveBallToTarget(path));
            _pathWayCurrentIndex = 0;
            _isMoving = false;

        }



    }


}
