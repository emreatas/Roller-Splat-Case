using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasController : MonoBehaviour
{
    public TextMeshProUGUI text;
    private void OnEnable()
    {
        GameManager.CurrentLevel += GameManager_CurrentLevel;
    }

    private void GameManager_CurrentLevel(int obj)
    {
        text.text = (obj + 1).ToString();
    }
    private void OnDisable()
    {
        GameManager.CurrentLevel -= GameManager_CurrentLevel;

    }
}

