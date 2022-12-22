using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    private string level1 = "Level 1";
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        if(GetLevelStatus(level1) == LevelStatus.Locked)
        {
            SetLevelStatus(level1, LevelStatus.Unlocked);
        }
    }

    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelstatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
        return levelstatus;
    }
    public void SetLevelStatus(string level, LevelStatus levelstatus)
    {
        PlayerPrefs.SetInt(level, (int)levelstatus);
        Debug.Log("Setting Level: " + level + " status of " + levelstatus);
    }

    public void LevelComplete()
    {
        Scene currLevel = SceneManager.GetActiveScene();
        SetLevelStatus(currLevel.name, LevelStatus.Completed);
        int index = currLevel.buildIndex + 1;
        Scene nextLevel = SceneManager.GetSceneByBuildIndex(index);
        SetLevelStatus(nextLevel.name, LevelStatus.Unlocked);
    }
}
