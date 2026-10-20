using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D my_Player_Rigidbody;
    public float flapStrenght = 10f;

    [SerializeField] private AudioSource jumpSound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            my_Player_Rigidbody.linearVelocity = Vector2.up * flapStrenght;
            jumpSound.Play();

        }
    }
}
