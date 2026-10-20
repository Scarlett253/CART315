using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D my_Player_Rigidbody;
    public float flapStrenght = 10f;
    public float rotateSpeed = 360f;

    [SerializeField] private AudioSource jumpSound;

    private bool isSpinning = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            my_Player_Rigidbody.linearVelocity = Vector2.up * flapStrenght;
            jumpSound.Play();

        }

        //Spin
        if (isSpinning)
        {
            transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
        }
    }

    //collision with obstacles
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ObsTop") || collision.gameObject.CompareTag("ObsBottom"))
        {
            isSpinning = true;
        }
    }
}
