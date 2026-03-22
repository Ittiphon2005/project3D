using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Transform spawnPoint;
    Rigidbody rb;
    playerStat stat;
    bool isRespawning = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stat = GetComponent<playerStat>();
    }

    void Update()
    {
        if (stat.hp <= 0 && !isRespawning)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        isRespawning = true;

        // วาร์ปไปที่จุดเกิด
        transform.position = spawnPoint.position;
        // หันหน้าไปตามทิศของจุดเกิด (ปรับทิศทางใน Unity ได้ที่ตัว SpawnPoint)
        transform.rotation = spawnPoint.rotation;

        // หยุดแรงพุ่งทั้งหมด
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // รีเซ็ตเลือดเป็น 100
        stat.hp = 100;

        Invoke(nameof(ResetRespawn), 0.1f);
    }

    void ResetRespawn()
    {
        isRespawning = false;
    }
}