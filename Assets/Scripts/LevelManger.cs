using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float timer = 0;
    [SerializeField] private int level = 1;
    [SerializeField] private Transform spawnTranform;
    
    public int colectedPoint = 0;

    //UI
    [SerializeField] TextMeshProUGUI timerText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        timerText.text = GameManager.GetInstance().FormatTime((int)timer);

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject player = GameObject.Find("Player");
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.transform.position = spawnTranform.transform.position;
        }
    }



    public void FinishLevel()
    {
        GameManager.Level finishedLevel = GameManager.GetInstance().currentLevel;
        finishedLevel.levelTime = timer;
        finishedLevel.pointCollected = colectedPoint;
        GameManager.GetInstance().UpdateFinishedLevel(finishedLevel.levelName, finishedLevel);
        GameManager.GetInstance().LoadScene("MainMenu");
    }
}
