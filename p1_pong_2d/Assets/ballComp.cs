using UnityEngine;

public class ballComp : MonoBehaviour
{
    [SerializeField]  Rigidbody2D rb;
    [SerializeField]  float startingSpeed = 5f;

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
}
