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

        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        stat.hp = 90;   // รีเลือดใหม่

        Invoke(nameof(ResetRespawn), 0.1f);
    }

    void ResetRespawn()
    {
        isRespawning = false;
    }
}