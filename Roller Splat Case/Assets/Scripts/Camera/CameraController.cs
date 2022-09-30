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
        GameManager.LevelChanged += GameManager_LevelChanged;
    }

    private void GameManager_LevelChanged()
    {
        StartCoroutine(Cam());
    }

    private void GameManager_LevelSize(int arg1, int arg2)
    {
        _height = arg1;
        _width = arg2;
    }
    private void OnDisable()
    {
        GameManager.LevelSize -= GameManager_LevelSize;
        GameManager.LevelChanged -= GameManager_LevelChanged;


    }


    IEnumerator Cam()
    {
        yield return new WaitForFixedUpdate();
        cam = this.gameObject.GetComponent<Camera>();
        cam.transform.position = new Vector3((float)_width / 2 - .5f, _height * 1.5f, (float)_height / 2);

        cam.orthographicSize = (_height / 2) + 1;

    }
}
