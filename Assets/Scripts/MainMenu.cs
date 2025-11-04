using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Để dùng Button

public class MainMenu : MonoBehaviour
{
    public Button startButton;  // Assign StartButton trong Inspector

    void Start()
    {
        if (startButton)
        {
            startButton.onClick.AddListener(StartGame);
        }
    }

    void StartGame()
    {
        SceneManager.LoadScene("SampleScene");  // Tên scene game chính
    }
}