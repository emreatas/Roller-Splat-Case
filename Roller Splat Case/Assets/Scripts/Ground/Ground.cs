using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    private bool _isColored;
    private bool _isCounted;

    public bool isColored
    {

        get { return _isColored; }

    }


    public bool isCounted
    {
        get { return _isCounted; }
        set { _isCounted = value; }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            _isColored = true;
            gameObject.GetComponent<MeshRenderer>().material.color = Color.black;

        }
    }



}
