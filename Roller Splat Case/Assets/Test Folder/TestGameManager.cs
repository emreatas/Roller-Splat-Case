using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestGameManager : MonoBehaviour
{
    public static TestGameManager instance;

    private void Awake()
    {
        instance = this;
    }




    public static event Action<List<Tile>> AllTiles;
    public void OnAllTiles(List<Tile> tiles)
    {
        if (AllTiles != null)
        {
            AllTiles(tiles);
        }
    }

}
