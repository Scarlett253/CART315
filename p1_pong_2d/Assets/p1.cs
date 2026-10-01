using UnityEngine;

public class p1 : MonoBehaviour
{
    public float moveSpeed = 7f;

    Rigidbody2D rb;
    float movementX;
    float movementY;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movementX = 0f;
        movementY = 0f;

        if (Input.GetKey(KeyCode.W)) movementY = 1f;
        if (Input.GetKey(KeyCode.S)) movementY = -1f;
        if (Input.GetKey(KeyCode.A)) movementX = -1f;
        if (Input.GetKey(KeyCode.D)) movementX = 1f;

        rb.linearVelocity = new Vector2(movementX * moveSpeed, movementY * moveSpeed);

    }
}

 
