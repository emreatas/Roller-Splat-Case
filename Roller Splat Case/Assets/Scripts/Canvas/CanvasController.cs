using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CanvasController : MonoBehaviour
{

    [SerializeField] Image winPanel;

    public Text levelText;
    public Button level;
    public GameObject content;
    public TextMeshProUGUI levelHeader;

    private void OnEnable()
    {
        GameManager.GameWin += GameManager_GameWin;
    }

    private void GameManager_GameWin()
    {
        winPanel.gameObject.SetActive(true);
        levelText.text = GameManager.Instance.GetCurrentLevel().ToString();
    }
    private void OnDisable()
    {
        GameManager.GameWin -= GameManager_GameWin;
    }


    private void Start()
    {
        LevelPanel();
        GameManager.Instance.SetGamePause(true);
    }

    private void Update()
    {
        levelHeader.text = "LEVEL " + GameManager.Instance.GetCurrentLevel().ToString();
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
        GameManager.Instance.SetGamePause(true);
    }
    public void GameMenuButton(Image panelImage)
    {
        panelImage.gameObject.SetActive(true);
        GameManager.Instance.SetGamePause(true);

    }


    public void ResumeButton(Image panelImage)
    {
        panelImage.gameObject.SetActive(false);
        GameManager.Instance.SetGamePause(false);
    }
    public void LevelPanel()
    {


        for (int i = 0; i < content.transform.childCount; i++)
        {
            Destroy(content.transform.GetChild(i).gameObject);
        }




        // Debug.Log(GameManager.Instance.LastLevelCount());

        for (int i = 0; i < GameManager.Instance.GetLastLevelCount(); i++)
        {
            Button button = Instantiate(level);
            button.GetComponent<ButtonScript>().buttonID = i + 1;
            button.transform.SetParent(content.transform);
            button.GetComponentInChildren<TextMeshProUGUI>().text = "Level " + (i + 1);
        }
    }

}

