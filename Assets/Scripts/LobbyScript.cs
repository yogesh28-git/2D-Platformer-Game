using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyScript : MonoBehaviour
{
    [SerializeField] private Button PlayButton;

    private void Awake()
    {
        PlayButton.onClick.AddListener(LoadLevel);
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
