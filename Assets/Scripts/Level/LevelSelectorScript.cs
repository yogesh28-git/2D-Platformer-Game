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
        if(levelName == "back")
        {
            this.transform.parent.gameObject.SetActive(false);
            return;
        }
        LevelStatus levelstatus = LevelManager.Instance.GetLevelStatus(levelName);
        switch (levelstatus)
        {
            case LevelStatus.Locked:
                SoundManager.Instance.Play(Sounds.wrongButton);
                Debug.Log("Can't Play this level untill you unlock it");
                break;
            case LevelStatus.Unlocked:
                SoundManager.Instance.Play(Sounds.buttonClick);
                SceneManager.LoadScene(levelName);
                break;
            case LevelStatus.Completed:
                SoundManager.Instance.Play(Sounds.buttonClick);
                SceneManager.LoadScene(levelName);
                break;
        }
    }
}
