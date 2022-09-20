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

    [SerializeField] private Vector3 _startPos;
    [SerializeField] private Vector3 _swipeDelta;

    Rigidbody _rb;


    [SerializeField] private int _speed = 20;


    private void Update()
    {
        _isTap = false;
        _isSwipeLeft = false;
        _isSwipeRight = false;
        _isSwipeUp = false;
        _isSwipeDown = false;



        if (Input.GetMouseButtonDown(0) && gameObject.GetComponent<Rigidbody>().velocity.magnitude <= 5)
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
                    Debug.Log("left");

                    gameObject.GetComponent<Rigidbody>().velocity = Vector3.left * _speed;
                }
                else
                {
                    _isSwipeRight = true;
                    Debug.Log("right");

                    gameObject.GetComponent<Rigidbody>().velocity = Vector3.right * _speed;

                }

            }
            if (Mathf.Abs(y) > Mathf.Abs(x))
            {

                if (y < 0)
                {
                    _isSwipeDown = true;
                    Debug.Log("down");

                    gameObject.GetComponent<Rigidbody>().velocity = Vector3.back * _speed;

                }

                else
                {
                    _isSwipeUp = true;
                    Debug.Log("up");

                    gameObject.GetComponent<Rigidbody>().velocity = Vector3.forward * _speed;

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




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {

            other.gameObject.GetComponent<MeshRenderer>().material.color = Color.black;


        }
    }


}
