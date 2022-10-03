using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    private int _buttonID;

    public int buttonID
    {
        get { return _buttonID; }
        set { _buttonID = value; }
    }


    public void SetLevel()
    {
        GameManager.Instance.SetCurrentLevel(buttonID);
        GameManager.Instance.OnChangeMap();
        gameObject.transform.parent.parent.parent.parent.gameObject.SetActive(false);
        GameManager.Instance.SetGamePause(false);
    }


}
