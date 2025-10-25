using UnityEngine;

public class EndGame : MonoBehaviour
{
    [Header("Win Panel")]
    public WinGameUI winPanel;  // DRAG WinGamePanel từ Hierarchy

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (winPanel)
            {
                winPanel.ShowWinPanel();  // Active & set panel
            }
            // Optional: Disable player movement (thêm script PlayerController.DisableMovement(); nếu có)
        }
    }
}