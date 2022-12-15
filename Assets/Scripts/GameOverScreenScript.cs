using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreenScript : MonoBehaviour
{
    [SerializeField] private Button RestartGame;

    private float DeathDuration = 1.5f;

    private void Awake()
    {
        RestartGame.onClick.AddListener(ReloadScene);
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

    private void ActivateThisGameobject()
    {
        gameObject.SetActive(true);
    }


}
