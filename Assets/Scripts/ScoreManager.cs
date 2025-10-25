using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ChangeScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }

    public int GetFinalScore() { return score; }
}