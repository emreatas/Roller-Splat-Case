using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera cam;
    private int _height;
    private int _width;
    private void OnEnable()
    {
        GameManager.LevelSize += GameManager_LevelSize;
    }

    private void GameManager_LevelSize(int arg1, int arg2)
    {
        _height = arg1;
        _width = arg2;
    }
    private void OnDisable()
    {
        GameManager.LevelSize += GameManager_LevelSize;

    }
    void Start()
    {
        StartCoroutine(Cam());  
    }

    IEnumerator Cam()
    {
        yield return new WaitForFixedUpdate();
        cam = this.gameObject.GetComponent<Camera>();
        cam.transform.position = new Vector3((float)_height / 2 - 0.5f, _height * 2, (float)_width / 2 - 0.5f);

        cam.orthographicSize = (_height / 2) + 1;

    }
}
