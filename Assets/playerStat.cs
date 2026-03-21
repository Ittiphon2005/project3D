using UnityEngine;

public class playerStat : MonoBehaviour
{
    public int hp = 90;

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

        // 🔥 Enemy2 = ลดเลือดปกติ
        if (!collision.gameObject.CompareTag("Enemy2"))
            return;

        Color c = playerRenderer.material.color;

        int damage;
        if (c == Color.green) damage = 1;
        else if (c == Color.yellow) damage = 10;
        else if (c == Color.red) damage = 20;
        else damage = 15;

        hp -= damage;

        if (hp < 0)
            hp = 0;
    }
}