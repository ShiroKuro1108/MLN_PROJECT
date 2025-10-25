using UnityEngine;
using UnityEngine.UI;  // Thêm cho Button
using UnityEngine.SceneManagement;  // Thêm cho LoadScene
using TMPro;

public class WinGameUI : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI titleText;      // "GAME CLEAR!"
    public TextMeshProUGUI scoreText;      // "Final Score: X"
    public Button playAgainButton;         // Nút Play Again

    void Start()
    {
        // Đăng ký OnClick cho nút (chạy 1 lần)
        if (playAgainButton)
        {
            playAgainButton.onClick.AddListener(OnPlayAgain);
        }
    }

    public void ShowWinPanel()
    {
        // Set tổng điểm động
        int finalScore = ScoreManager.Instance.GetFinalScore();
        if (scoreText) scoreText.text = "Final Score: " + finalScore;

        // ACTIVE PANEL
        gameObject.SetActive(true);

        // TẠM DỪNG GAME
        Time.timeScale = 0f;
    }

    void OnPlayAgain()
    {
        // Resume game
        Time.timeScale = 1f;

        // Hide panel
        gameObject.SetActive(false);

        // Reload scene để chơi lại từ đầu
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Hoặc "MainScene" nếu tên khác
    }

    // Public method để hide nếu cần
    public void HidePanel()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}