using UnityEngine;
using TMPro; // Thêm thư viện này để dùng TextMeshPro

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Biến static để truy cập toàn cục

    public int score = 0;
    public TextMeshProUGUI scoreText; // Kéo UI Text vào đây

    public GameObject gameClearPanel; // Kéo Panel Game Clear vào đây
    public TextMeshProUGUI finalScoreText; // Kéo Text điểm cuối vào đây

    void Awake()
    {
        // Thiết lập Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gameClearPanel.SetActive(false); // Ẩn bảng Game Clear khi bắt đầu
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        if (score < 0) score = 0; // Đảm bảo điểm không bị âm (tùy bạn)
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void ShowGameClear()
    {
        gameClearPanel.SetActive(true);
        finalScoreText.text = "Final Score: " + score;
        Time.timeScale = 0f; // Dừng game
    }
}