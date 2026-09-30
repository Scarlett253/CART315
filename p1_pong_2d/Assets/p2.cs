using UnityEngine;

public class p2 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;

    private Rigidbody2D rb;
    private float movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            movement = 1f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            movement = -1f;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0f, movement * moveSpeed);
    }
}
