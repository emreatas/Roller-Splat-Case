using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _groundObject;
    [SerializeField] private List<Ground> _grounds;



    private void Start()
    {
        GameManager_LevelChanged();
    }

    private void OnEnable()
    {
        GameManager.LevelChanged += GameManager_LevelChanged;
    }

    private void GameManager_LevelChanged()
    {
        _grounds.Clear();
        for (int i = 0; i < _groundObject.transform.childCount; i++)
        {
            _grounds.Add(_groundObject.transform.GetChild(i).GetComponent<Ground>());
        }


    }
    private void OnDestroy()
    {
        GameManager.LevelChanged -= GameManager_LevelChanged;
    }




}
