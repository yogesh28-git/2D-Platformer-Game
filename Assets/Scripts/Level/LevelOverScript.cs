using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelOverScript : MonoBehaviour
{
    private int currentScene;
    private int NextScene;
    [SerializeField] private GameObject levelCompleteScreen;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button homeButton;
    


    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        NextScene = (currentScene < 3)? currentScene + 1 : 0;
        nextLevelButton.onClick.AddListener(loadNextLevel);
        homeButton.onClick.AddListener(GoHomeScene);
        if (NextScene == 0)
        {
            nextLevelButton.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            LevelManager.Instance.LevelComplete();
            LevelCompleteScreen();
        }
    }

    private void LevelCompleteScreen()
    {
        levelCompleteScreen.SetActive(true);

    }
    private void GoHomeScene()
    {
        SoundManager.Instance.Play(Sounds.buttonClick);
        SceneManager.LoadScene(0);    //MyLobby scene is index 0. 
    }
    private void loadNextLevel()
    {
        SoundManager.Instance.Play(Sounds.buttonClick);
        SceneManager.LoadScene(NextScene);
    }
}
