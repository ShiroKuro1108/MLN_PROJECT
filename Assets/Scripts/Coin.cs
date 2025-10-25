using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    public bool isGood = true; // true: tốt, false: hại
    public int value = 10; // |điểm|

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.ChangeScore(isGood ? value : -value);
            Destroy(gameObject); // Xóa coin
        }
    }
}