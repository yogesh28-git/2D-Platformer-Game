using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverScript : MonoBehaviour
{
    private int currentScene;
    private int NextScene;
    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        NextScene = (currentScene < 4) ? currentScene + 1 : 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Next Level");
            SceneManager.LoadScene(NextScene);
        }
    }
}
