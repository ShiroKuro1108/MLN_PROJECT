using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    public Sprite openSprite; // Assign sprite cửa mở trong Inspector

    public void OpenDoor()
    {
        gameObject.SetActive(true); // ACTIVE trước nếu đang tắt
        isOpen = true;
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        if (collider) collider.enabled = false; // Mở: tắt collider
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr && openSprite) sr.sprite = openSprite;
    }
}