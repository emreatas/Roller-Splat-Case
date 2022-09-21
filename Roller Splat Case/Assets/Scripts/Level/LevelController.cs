using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<LevelManager> levelManagers;
    private int levelCount = 0;

    private void Start()
    {
        for (int i = 0; i < levelManagers.Count; i++)
        {
            levelManagers[i].gameObject.SetActive(false);
        }
        levelManagers[levelCount].gameObject.SetActive(true);
    }
    private void OnEnable()
    {
        GameManager.LevelChanged += GameManager_LevelChanged;
    }

    private void GameManager_LevelChanged()
    {
        if (levelCount < levelManagers.Count - 1)
        {

            levelCount++;

            for (int i = 0; i < levelManagers.Count; i++)
            {
                levelManagers[i].gameObject.SetActive(false);
            }

            levelManagers[levelCount].gameObject.SetActive(true);


        }
    }
    private void OnDisable()
    {
        GameManager.LevelChanged -= GameManager_LevelChanged;

    }
}
