using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _groundObject;
    [SerializeField] private List<Ground> _grounds;
    private int _coloredGround = 0;



    private void Start()
    {
        for (int i = 0; i < _groundObject.transform.childCount; i++)
        {
            _grounds.Add(_groundObject.transform.GetChild(i).GetComponent<Ground>());
        }
    }



    private void OnEnable()
    {
        GameManager.GameWin += GameManager_GameWin;
    }


    private void GameManager_GameWin()
    {
        GameManager.Instance.OnLevelChanged();
    }

    private void OnDisable()
    {
        GameManager.GameWin -= GameManager_GameWin;
    }

    private void LevelWinCheck()
    {
        if (_grounds.Count == _coloredGround)
        {

            GameManager_GameWin();
        }
    }


    private void Update()
    {





        if (_grounds.Count > 0)
        {
            for (int i = 0; i < _grounds.Count; i++)
            {
                if (_grounds[i].isColored && !_grounds[i].isCounted)
                {

                    _grounds[i].isCounted = true;
                    _coloredGround++;

                }
            }
            LevelWinCheck();

        }




    }




}
