using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyScript : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private GameObject levelSelector;

    private void Awake()
    {
        playButton.onClick.AddListener(LevelPopUp);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void LevelPopUp()
    {
        levelSelector.SetActive(true);
    }
    private void QuitGame()
    {
        Application.Quit();
    }
}
