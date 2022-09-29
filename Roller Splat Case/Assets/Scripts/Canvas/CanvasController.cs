using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CanvasController : MonoBehaviour
{


    public Scene gameScene;

    public void StartButton()
    {
        SceneManager.LoadScene("MainScene");
    }


}

