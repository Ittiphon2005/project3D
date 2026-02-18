using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Transform spawnPoint;

    Rigidbody rb;
    bool isRespawning = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isRespawning)
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

        Invoke(nameof(ResetRespawn), 0.1f);
    }

    void ResetRespawn()
    {
        isRespawning = false;
    }
}
