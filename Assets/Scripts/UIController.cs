using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        int getScore = PlayerPrefs.GetInt("score", 0);
        if (getScore == 0)
        {
            PlayerPrefs.SetInt("score", 0);
            score = 0;
        }
        else
        {
            score = getScore;
        }
    }
    private void Start()
    {
        RefreshUI();
    }
    public void IncreaseScore(int increment)
    {
        score += increment;
        PlayerPrefs.SetInt("score", score);
        RefreshUI();
    }

    public void ResetScore()
    {
        score = 0;
        PlayerPrefs.SetInt("score", 0);
    }
    private void RefreshUI()
    {
        scoreText.text = "Score: " + score;
    }
}
