using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoiceUI : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI questionText;
    public Button buttonA, buttonB;

    public Door doorA, doorB;
    public Checkpoint currentCheckpoint;  // Checkpoint hiện tại

    public void SetupUI(string question, string answerA, string answerB, Door aDoor, Door bDoor, Checkpoint cp)
    {
        // Set text
        if (questionText) questionText.text = question;
        if (buttonA)
        {
            TextMeshProUGUI textA = buttonA.GetComponentInChildren<TextMeshProUGUI>();
            if (textA) textA.text = answerA;
        }
        if (buttonB)
        {
            TextMeshProUGUI textB = buttonB.GetComponentInChildren<TextMeshProUGUI>();
            if (textB) textB.text = answerB;
        }

        // Set doors & checkpoint
        doorA = aDoor;
        doorB = bDoor;
        currentCheckpoint = cp;

        // Active buttons
        if (buttonA) buttonA.interactable = true;
        if (buttonB) buttonB.interactable = true;

        // HIỆN PANEL
        gameObject.SetActive(true);
    }

    void Start()
    {
        // Đăng ký listeners (chỉ 1 lần)
        if (buttonA) buttonA.onClick.AddListener(OnChooseA);
        if (buttonB) buttonB.onClick.AddListener(OnChooseB);
    }

    void OnChooseA() { ChooseDoor(true); }   // A: Đúng
    void OnChooseB() { ChooseDoor(false); }  // B: Sai

    void ChooseDoor(bool isCorrect)
    {
        // Mở cửa tương ứng
        Door selectedDoor = isCorrect ? doorA : doorB;
        if (selectedDoor)
        {
            selectedDoor.OpenDoor();  // Active + Mở
        }

        // Khóa buttons
        if (buttonA) buttonA.interactable = false;
        if (buttonB) buttonB.interactable = false;

        // DISABLE PANEL (sẵn sàng cho lần sau)
        gameObject.SetActive(false);
    }

    // Public method để reset nếu cần (tùy chọn)
    public void ResetUI()
    {
        gameObject.SetActive(false);
    }
}