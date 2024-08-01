using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelItem : MonoBehaviour
{

    public GameManager.Level level;
    [SerializeField] private TextMeshProUGUI levelNameText;
    [SerializeField] private List<Image> starsImages;
    [SerializeField] private TextMeshProUGUI levelTimeText;


    // Start is called before the first frame update
    void Start()
    {
        levelNameText.text = level.levelName;
        for(int i = 0; i < level.pointCollected; i++)
        {
            starsImages[i].color = Color.white;
        }
        levelTimeText.text =  "Time: " + GameManager.GetInstance().FormatTime((int) level.levelTime);
    }


    public void PlayLevel()
    {
        GameManager.GetInstance().currentLevel = level;
        GameManager.GetInstance().LoadScene(level.scene);
    }

}
