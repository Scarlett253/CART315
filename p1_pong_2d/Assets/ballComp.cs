using UnityEngine;

public class ballComp : MonoBehaviour
{
    Rigidbody2D rb;
    float startingSpeed = 5f;
    public float spinSpeed = 180f;

     void Awake()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

     void Start()
    {
        float xDirection = Random.value < 0.5f ? -1f : 1f;
        float yDirection = Random.Range(-0.75f, 0.75f);

        Vector2 direction = new Vector2(xDirection, yDirection).normalized;
        rb.linearVelocity = direction * startingSpeed;

    }

    void Update()
    {
        transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (Mathf.Abs(rb.linearVelocity.x) < 1f)
        {
            float dir = Random.value < 0.5f ? 1f : -1f;
            rb.linearVelocity = new Vector2(dir * 2f, rb.linearVelocity.y);
        }

        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, startingSpeed * 2f);
    }
}
