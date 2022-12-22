using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelectorScript : MonoBehaviour
{
    private Button levelButton;
    [SerializeField] private string levelName;
    private void Awake()
    {
        levelButton = GetComponent<Button>();
        levelButton.onClick.AddListener(LoadLevel);
    }

    private void LoadLevel()
    {
        LevelStatus levelstatus = LevelManager.Instance.GetLevelStatus(levelName);
        switch (levelstatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Can't Play this level untill you unlock it");
                break;
            case LevelStatus.Unlocked:
                SceneManager.LoadScene(levelName);
                break;
            case LevelStatus.Completed:
                SceneManager.LoadScene(levelName);
                break;
        }
    }
}
