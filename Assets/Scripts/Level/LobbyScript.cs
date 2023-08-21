using UnityEngine;
using UnityEngine.UI;

public class LobbyScript : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button resetButton;
    [SerializeField] private GameObject levelSelector;
    [SerializeField] private GameObject resetConfirm;
    [SerializeField] private GameObject quitConfirm;
    [SerializeField] private Button yesReset;
    [SerializeField] private Button noReset;
    [SerializeField] private Button yesQuit;
    [SerializeField] private Button noQuit;

    private void Awake()
    {
        playButton.onClick.AddListener(LevelPopUp);
        quitButton.onClick.AddListener(QuitGame);
        resetButton.onClick.AddListener(ResetGame);
        yesReset.onClick.AddListener(YesReset);
        noReset.onClick.AddListener(NoReset);
        yesQuit.onClick.AddListener(YesQuit);
        noQuit.onClick.AddListener(NoQuit);
    }

    private void LevelPopUp()
    {
        levelSelector.SetActive(true);
    }
    private void QuitGame()
    {
        quitConfirm.SetActive(true);
    }
    private void ResetGame()
    {
        resetConfirm.SetActive(true);
    }
    private void YesReset()
    {
        PlayerPrefs.DeleteAll();
        LevelManager.Instance.SetLevelStatus("Level 1", LevelStatus.Unlocked);
        resetConfirm.SetActive(false);
    }
    private void NoReset()
    {
        resetConfirm.SetActive(false);
    }
    private void YesQuit()
    {
        Application.Quit();
    }
    private void NoQuit()
    {
        quitConfirm.SetActive(false);
    }
}
