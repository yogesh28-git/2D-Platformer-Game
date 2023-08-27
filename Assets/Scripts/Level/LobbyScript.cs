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
        SoundManager.Instance.Play(Sounds.buttonClick);
        levelSelector.SetActive(true);
    }
    private void QuitGame()
    {
        SoundManager.Instance.Play(Sounds.buttonClick);
        quitConfirm.SetActive(true);
    }
    private void ResetGame()
    {
        SoundManager.Instance.Play(Sounds.buttonClick);
        resetConfirm.SetActive(true);
    }
    private void YesReset()
    {
        SoundManager.Instance.Play(Sounds.buttonClick);
        PlayerPrefs.DeleteAll();
        LevelManager.Instance.SetLevelStatus("Level 1", LevelStatus.Unlocked);
        resetConfirm.SetActive(false);
    }
    private void NoReset()
    {
        SoundManager.Instance.Play(Sounds.buttonClick);
        resetConfirm.SetActive(false);
    }
    private void YesQuit()
    {
        SoundManager.Instance.Play(Sounds.buttonClick);
        Application.Quit();
    }
    private void NoQuit()
    {
        SoundManager.Instance.Play(Sounds.buttonClick);
        quitConfirm.SetActive(false);
    }
}
