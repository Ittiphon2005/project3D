using UnityEngine;
using UnityEngine.InputSystem;

public class CubeMove : MonoBehaviour
{
    public float speed = 5f;
    public float sprintMultiplier = 1.8f;
    public float jumpForce = 5f;
    public float fallOfMap = -20f;

    Rigidbody rb;
    PlayerDeath playerDeath;

    bool isGrounded = false;
    bool jumpQueued = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerDeath = GetComponent<PlayerDeath>();
    }

    void Update()
    {
        // ตรวจสอบการตกแมพ
        if (transform.position.y < fallOfMap)
        {
            playerDeath.Respawn();
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            jumpQueued = true;
        }
    }

    void FixedUpdate()
    {
        Vector2 dir = Vector2.zero;

        if (Keyboard.current.aKey.isPressed) dir.x -= 1;
        if (Keyboard.current.dKey.isPressed) dir.x += 1;
        if (Keyboard.current.wKey.isPressed) dir.y += 1;
        if (Keyboard.current.sKey.isPressed) dir.y -= 1;

        float currentSpeed = speed;
        if (Keyboard.current.leftShiftKey.isPressed)
            currentSpeed *= sprintMultiplier;

        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        forward.y = 0;
        right.y = 0;

        Vector3 move = (forward * dir.y + right * dir.x).normalized;

        rb.MovePosition(
            rb.position + move * currentSpeed * Time.fixedDeltaTime
        );

        if (jumpQueued && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        jumpQueued = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}
