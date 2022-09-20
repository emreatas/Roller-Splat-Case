using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }


    public static event Action GameWin;
    public void OnGameWin()
    {
        if (GameWin != null)
        {
            OnGameWin();
        }
    }

    public static event Action LevelChanged;
    public void OnLevelChanged()
    {
        if (LevelChanged != null)
        {
            OnLevelChanged();
        }
    }



}
