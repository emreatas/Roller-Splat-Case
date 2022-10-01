using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuCanvs : MonoBehaviour
{

    public void StartButton()
    {
        SceneManager.LoadScene("MainScene");

    }
    public void OpenButton(Image panelImage)
    {
        panelImage.gameObject.SetActive(true);
        GameManager.Instance.SetGamePause(true);
    }
    public void BackButton(Image panelImage)
    {
        panelImage.gameObject.SetActive(false);

    }
}
