using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelectorScript : MonoBehaviour
{
    private Button levelButton;
    [SerializeField] private int levelIndex;
    private void Awake()
    {
        levelButton = GetComponent<Button>();
        levelButton.onClick.AddListener(LoadLevel);
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(levelIndex);
    }
}
