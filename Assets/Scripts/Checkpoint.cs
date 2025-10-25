using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [Header("Câu Hỏi & Trả Lời")]
    public string question = "Câu hỏi mặc định?";
    public string answerA = "Đúng";  // A: Đúng → DoorA tốt
    public string answerB = "Sai";   // B: Sai → DoorB xấu

    [Header("UI & Doors")]
    public ChoiceUI choicePanel;     // DRAG ChoicePanel DUY NHẤT từ Hierarchy
    public Door doorA, doorB;
    public GameObject backDoor;      // BackDoor (inactive ban đầu)
    public bool canTrigger = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canTrigger)
        {
            canTrigger = false;

            // ACTIVE BACKDOOR NGAY (đóng cửa sau)
            if (backDoor) backDoor.SetActive(true);

            // Setup & ACTIVE PANEL CHUNG
            if (choicePanel)
            {
                choicePanel.SetupUI(question, answerA, answerB, doorA, doorB, this);
            }

            // DISABLE CHECKPOINT VĨNH VIỄN
            gameObject.SetActive(false);
        }
    }
}