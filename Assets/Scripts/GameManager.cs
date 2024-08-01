using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    private static GameManager instance;

    public static GameManager GetInstance() {  return instance; }

    public List<Level> levels;

    public Level currentLevel;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
      
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    [System.Serializable] 
    public class Level
    {
        public string levelName;
        public float levelTime;
        public int pointCollected;
        public SceneAsset scene;
        
    }
    

    public void LoadScene(SceneAsset scene)
    {
        SceneManager.LoadScene(scene.name);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public string FormatTime(int secs)
    {
        int hours = secs / 3600;
        int mins = (secs % 3600) / 60;
        secs = secs % 60;
        return string.Format("{0:D2}:{1:D2}:{2:D2}", hours, mins, secs);
    }

    public void UpdateFinishedLevel(string name, Level newLevel)
    {
        for(int i = 0; i < levels.Count; i++)
        {
            if (levels[i].levelName == name)
            {
                levels[i] = newLevel;
            }
        }
    }
}
