using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{


    [SerializeField] Transform levelsContainter;
    [SerializeField] GameObject levelPrefab;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameManager.Level level in GameManager.GetInstance().levels)
        {
            SelectLevelItem levelItem = Instantiate(levelPrefab, levelsContainter).GetComponent<SelectLevelItem>();
            levelItem.level = level;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
