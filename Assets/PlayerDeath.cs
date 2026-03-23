using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerDeath : MonoBehaviour
{
    [Header("Settings")]
    public Transform spawnPoint;
    public GameObject endGamePanel;
    public TextMeshProUGUI endText;

    Rigidbody rb;
    playerStat stat;
    bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stat = GetComponent<playerStat>();

        // สำคัญ: รีเซ็ตทุกอย่างให้กลับมาเล่นได้ตอนเริ่ม Scene ใหม่
        Time.timeScale = 1;
        isDead = false;

        // ล็อคเมาส์กลับเข้ากลางจอเพื่อให้หันหน้าจอได้ทันที
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (endGamePanel != null)
            endGamePanel.SetActive(false);
    }

    void Update()
    {
        // เช็คเลือดหมด
        if (stat.hp <= 0 && !isDead)
        {
            ShowEndScreen("GAME OVER");
        }
    }

    public void ShowEndScreen(string message)
    {
        if (isDead) return; // ป้องกันการเรียกซ้ำถ้าตายไปแล้ว

        isDead = true;
        if (endText != null) endText.text = message;
        if (endGamePanel != null) endGamePanel.SetActive(true);

        // หยุดเวลาและปลดล็อคเมาส์ให้กดปุ่มได้
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // หยุดแรงเฉื่อยของตัวละคร (กันบั๊กเวลาตกแมพ)
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    public void ClickRestart()
    {
        // คืนค่าเวลาก่อนโหลดฉากใหม่
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Respawn()
    {
        // ฟังก์ชันวาร์ปกลับจุดเกิด (กรณีที่ยังไม่ตาย)
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        stat.hp = 100;
    }
}