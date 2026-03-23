using UnityEngine;
using UnityEngine.SceneManagement;

public class playerStat : MonoBehaviour
{
    public int hp = 100;

    private void OnCollisionEnter(Collision collision)
    {
        // เช็คว่าชนวัตถุที่ติด Tag "Enemy" หรือไม่ (อย่าลืมไปเปลี่ยน Tag ใน Unity นะครับ)
        if (collision.gameObject.CompareTag("Enemy"))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            if (currentSceneIndex == 0) // ด่าน 1 (Level1)
            {
                hp -= 50;
            }
            else // ด่านอื่นๆ รวมถึงด่าน 2 (Level2)
            {
                hp = 0; // ชนแล้วตายทันที
            }

            if (hp < 0) hp = 0;
        }
    }
}