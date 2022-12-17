using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreenScript : MonoBehaviour
{
    [SerializeField] private Button restartGame;
    [SerializeField] private Button homeButton;

    private float DeathDuration = 1.5f;

    private void Awake()
    {
        restartGame.onClick.AddListener(ReloadScene);
        homeButton.onClick.AddListener(GoHomeScene);
    }

    public void PlayerDead(GameObject player)
    {
        Invoke("ActivateThisGameobject", DeathDuration);
        //Destroy(player, DeathDuration);
        player.GetComponent<PlayerController>().enabled = false;
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GoHomeScene()
    {
        SceneManager.LoadScene(0);    //MyLobby scene is index 0. 
    }

    private void ActivateThisGameobject()
    {
        gameObject.SetActive(true);
    }


}
