using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishLine : MonoBehaviour
{
    [Header("UI Settings")]
    public GameObject winPanel;      // ลาก Panel ชนะมาใส่
    public TextMeshProUGUI winText;   // ลาก Text ใน Panel มาใส่

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            // หยุดเวลาและปลดล็อคเมาส์เหมือนตอนตาย
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (winPanel != null) winPanel.SetActive(true);

            // เช็คว่ามีด่านต่อไปไหม
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                if (winText != null) winText.text = "LEVEL COMPLETE!";
            }
            else
            {
                if (winText != null) winText.text = "GAME CLEAR!";
            }
        }
    }

    // ฟังก์ชันสำหรับปุ่ม Next Step
    public void ClickNextStep()
    {
        Time.timeScale = 1;
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // ถ้าด่านสุดท้ายแล้วกดปุ่ม ให้กลับไปหน้าเมนูหรือเริ่มใหม่
            SceneManager.LoadScene(0);
        }
    }
}