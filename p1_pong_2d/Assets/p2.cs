using UnityEngine;

public class p2 : MonoBehaviour
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

        if (Input.GetKey(KeyCode.UpArrow)) movementY = 1f;
        if (Input.GetKey(KeyCode.DownArrow)) movementY = -1f;
        if (Input.GetKey(KeyCode.LeftArrow)) movementX = -1f;
        if (Input.GetKey(KeyCode.RightArrow)) movementX = 1f;


        rb.linearVelocity = new Vector2(movementX * moveSpeed, movementY * moveSpeed);
    }
}
