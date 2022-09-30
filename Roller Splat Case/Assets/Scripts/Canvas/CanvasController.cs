using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CanvasController : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.GameWin += GameManager_GameWin;
    }

    private void GameManager_GameWin()
    {

    }
    private void OnDisable()
    {
        GameManager.GameWin -= GameManager_GameWin;
    }
    public void StartButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void BackButton(Image panelImage)
    {
        panelImage.gameObject.SetActive(false);
    }
    public void OpenButton(Image panelImage)
    {
        panelImage.gameObject.SetActive(true);
    }
    public void GameMenuButton(Image panelImage)
    {
        panelImage.gameObject.SetActive(!panelImage.gameObject.activeSelf);
    }


}

