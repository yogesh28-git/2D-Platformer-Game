using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreenScript : MonoBehaviour
{
    [SerializeField] private Button RestartGame;

    private float DeathDuration = 0.75f;

    private void Awake()
    {
        RestartGame.onClick.AddListener(ReloadScene);
    }

    public void PlayerDead()
    {
        Invoke("ActivateThisGameobject", DeathDuration);
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
