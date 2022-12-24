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
        Debug.Log("awake called !!");
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
        string nextLevel = GetLevelByIndex(index);
        if(GetLevelStatus(nextLevel) == LevelStatus.Locked)
        {
            SetLevelStatus(nextLevel, LevelStatus.Unlocked);
        }

    }

    private string GetLevelByIndex(int levelIndex)
    {
        string lvlName = "";
        switch (levelIndex)
        {
            case 1: lvlName = "Level 1";
                break;
            case 2: lvlName = "Level 2";
                break;
            case 3: lvlName = "Level 3";
                break;
            case 4: lvlName = "Level 4";
                break;
            case 5: lvlName = "Level 5";
                break;
        }
        return lvlName;
    }
}
