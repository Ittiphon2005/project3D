using UnityEngine;

public class playerStat : MonoBehaviour
{
    public int hp = 100;

    private Renderer playerRenderer;

    void Start()
    {
        playerRenderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 🔥 Enemy = ตายทันที
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hp = 0;
            return;
        }
    }
}